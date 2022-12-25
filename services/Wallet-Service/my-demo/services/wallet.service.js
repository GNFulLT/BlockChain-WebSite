"use strict"
const grpc = require('grpc');
const protoLoader = require('@grpc/proto-loader');
const path = require("path");





/**
 * @typedef {import('moleculer').ServiceSchema} ServiceSchema Moleculer's Service Schema
 * @typedef {import('moleculer').Context} Context Moleculer's Context
 */

/** @type {ServiceSchema} */
const walletService = 
{   
    name:"wallet",

    settings:{
        
    },
    dependencies:[
        "discovery"
    ],
    protoClient:{},
    //!: REST Method Handler Definitions
    actions:
    {
        getWalletByUserId:{
            rest:{
                method:"POST",
                path:"/getWalletByUserId"
            },
            params:{
                userId:"number"
            },
            async handler(ctx)
            {
                let walletClient = this.protoClient;
                try
                {
                    let mainRes = await new Promise((resolve, reject) => {
                        walletClient.GetByUserId({Id:ctx.params.userId}, (err, res) => {
                          if(err)
                            console.log(err);
                          resolve(res);
                        });
                      });
                    return mainRes;
                }
                catch(ex)
                {
                    this.logger.error(ex);
                    return Promise.reject({ code: 500, message: "Unknown Exception" });
                }

            }
        },
        getWalletById:{
            rest:{
                method:"POST",
                path:"/getWalletById"
            },
            params:{
                Id:"number"
            },
            async handler(ctx)
            {
                let walletClient = this.protoClient;
                
                try
                {
                    let mainRes = await new Promise((resolve, reject) => {
                        walletClient.Get({Id:ctx.params.Id}, (err, res) => {
                          if(err)
                            console.log(err);
                          resolve(res);
                        });
                      });
                    return mainRes.Data;
                }
                catch(ex)
                {
                    this.logger.error(ex);
                    return Promise.reject({ code: 500, message: "Unknown Exception" });
                }
            }
        },
        createWallet:{

            rest:{
                method:"POST",
                path:"/createWallet"
            },
            params:{
                userId:"number"
            },
            /**
             * 
             * @returns String Message
             */
            async handler(ctx)
            {
                try
                {
                    let user = await ctx.call("wallet.getWalletByUserId",{userId});
                    if(user)
                        return Promise.reject({ code: 400, message: "There is already created wallet for that user" });

                }
                catch(ex)
                {
                    return Promise.reject({ code: 500, message: "Unknown Exception" });
                }
                let walletClient = this.protoClient;
                const request = {
                    Id: 1,
                    Data: {
                      Id: 1,
                      CarbonPoint: 0,
                      UserId: 10,
                    },
                  };
                let mainRes;
                try
                {
                    mainRes = await new Promise((resolve, reject) => {
                        walletClient.Create(request, (err, res) => {
                          if(err)
                            console.log(err);
                          resolve(res);
                        });
                      });
                }
                catch(ex)
                {
                    console.log(ex.message)
                    mainRes = "Couldn't get";
                }
                  
                return mainRes;
            }
            
        }
    },
    async started() {
        this.logger.info("Loading Wallet Proto File");
        let protoPath = path.join(__dirname,`/../protos/WalletDataService.proto`);
        const proto = new grpc.loadPackageDefinition(protoLoader.loadSync(protoPath, {
            keepCase: true,
            longs: String,
            enums: String,
            defaults: true,
            oneofs: true
          }));
        this.logger.info("Successfully Loaded");
        this.logger.info("Trying to connect to DataService");
        let homePageUrl = "localhost:3333";
        console.log(homePageUrl);
        this.protoClient = new proto.Database_Service.Grpc.DataServices.WalletDataService(homePageUrl,grpc.credentials.createInsecure());

    }
}


module.exports = walletService;