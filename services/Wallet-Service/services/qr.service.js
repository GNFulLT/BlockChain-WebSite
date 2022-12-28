"use strict"
const grpc = require('grpc');
const protoLoader = require('@grpc/proto-loader');
const path = require("path");
const axios = require("axios")
var fs = require("fs");
/**
 * @typedef {import('moleculer').ServiceSchema} ServiceSchema Moleculer's Service Schema
 * @typedef {import('moleculer').Context} Context Moleculer's Context
 */

/** @type {ServiceSchema} */
const qrService = {
    name:"qr",

    settings:{
        
    },
    dependencies:[
        "discovery"
    ],
    qrApiUri:"https://api.qrserver.com/v1/create-qr-code/?size=150x150",
    protoClient:{},
    imageFolder:"images",
    //!: REST Method Handler Definitions
    actions:{
        getQrCode:{
            rest:{
                path:"/getQrCode",
                method:"POST"
            },
            params:{
                username:"string"
            },
            async handler(ctx)
            {
                let qrClient = this.protoClient;
                let qrImagePath = `./${this.imageFolder}/${ctx.params.username}.png`;
                
                try
                {
                    let isFile = fs.lstatSync(qrImagePath).isFile();
                    console.log("Check is it an file")
                    if(isFile)
                    {
                        console.log("Trying to read image");
                        ctx.meta.$responseType =  'image/jpeg';
                        return fs.createReadStream(qrImagePath);
                        
                    }
                }
                catch(ex)
                {
                    console.log(ex);
                    return ""
                }
            }
        },
        createQrCode:{
            rest:{
                path:"/createQrCode",
                method:"POST"
            },
            params:{
                username:"string"
            },
            async handler(ctx)
            {
                let qrClient = this.protoClient;
                let url = new URL(this.qrApiUri);
                let qrImagePath = `./${this.imageFolder}/${ctx.params.username}.png`;
                url.searchParams.append("data",ctx.params.username);
                try
                {
                    let image = await axios.get(url.href,{ responseType: 'stream'});
                    image.data.pipe(fs.createWriteStream(qrImagePath));
                    return "";
                }
                catch(ex)
                {
                    return Promise.reject({ code: 500, message: "Unknown Exception" });
                }
                /*
                try
                {/*
                    let mainRes = await new Promise((resolve, reject) => {
                        qrClient.Create({Data:{QrImagePath:qrImagePath}}, (err, res) => {
                          if(err)
                            console.log(err);
                          resolve(res);
                        });
                      });
                      */
/*                }
                catch(ex)
                {

                }*/
            },
        }
    },
    async started() {
        this.qrApiUri = "https://api.qrserver.com/v1/create-qr-code/?size=150x150";
        this.imageFolder = "images";
        this.logger.info("Loading Qr Proto File");
        let protoPath = path.join(__dirname,`/../protos/QrDataService.proto`);
        const proto = new grpc.loadPackageDefinition(protoLoader.loadSync(protoPath, {
            keepCase: true,
            longs: String,
            enums: String,
            defaults: true,
            oneofs: true
        }));
        this.logger.info("Successfully Loaded");
        this.logger.info("Trying to connect to DataService");
        let homePageUrl = "host.docker.internal:3333";
        console.log(homePageUrl);
        this.protoClient = new proto.Database_Service.Grpc.DataServices.QrDataService(homePageUrl,grpc.credentials.createInsecure());

        try
        {
            this.logger.info("Checking there is an image folder");
            let isDirectory = fs.lstatSync(`./${this.imageFolder}`).isDirectory();
            if(!isDirectory)
            {
                this.logger.error("Unexpected condition");
            }
        }
        catch(ex)
        {
            if(ex.code == 'ENOENT'){
                //no such file or directory
                //do something
                this.logger.info("There is no image folder. Creating");
                fs.mkdirSync(`./${this.imageFolder}`);
                this.logger.info("Image folder created");
              }else {
                //do something else
                this.logger.error("Unknown error occured while trying to create folder");
                return Promise.reject({ code: 500, message: "Unknown Exception" });
              }
        }
    }
}

module.exports = qrService;