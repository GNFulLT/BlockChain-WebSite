"use strict"
const grpc = require('grpc');
const protoLoader = require('@grpc/proto-loader');
const path = require("path");
const Web3 = require('web3');





/**
 * @typedef {import('moleculer').ServiceSchema} ServiceSchema Moleculer's Service Schema
 * @typedef {import('moleculer').Context} Context Moleculer's Context
 */

/** @type {ServiceSchema} */
const walletService = 
{   
    name:"wlt",

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
                    return mainRes;
                }
                catch(ex)
                {
                    this.logger.error(ex);
                    return Promise.reject({ code: 500, message: "Unknown Exception" });
                }
            }
        },
        carbonPointToAXT:{
            rest:{
                method:"POST",
                path:"/carbonPointToAXT"
            },
            params:{
                walletId:"number",
                toAddress:"string",
                carbonAmount:"number"
            },
            async handler(ctx)
            {
                let walletId = ctx.params.walletId;
                let carbonAmount = ctx.params.carbonAmount;
                let toAddress = ctx.params.toAddress;

                let wallet = await ctx.call("wlt.getWalletById",{Id:walletId});
                this.logger.info("WALLER FOUND");
                console.log(wallet);
                if(!wallet.IsSuccess)
                    return Promise.reject({ code: 400, message: "Unknown error bro" });

                wallet = wallet.Data;
                
                let convertedCarbonAmount = Math.min(wallet.CarbonPoint,carbonAmount);

                await ctx.call("wlt.postCarbonPointToWallet",{walletId,carbonAmount:-convertedCarbonAmount});
                
                //! Wallet:
                const Web3js = new Web3(new Web3.providers.HttpProvider('https://goerli.infura.io/v3/c2ee6d071c09457cb404dfda6c6da025'))
                
                //!: Main WALLET kEY
                const privateKey = '8e66ec2e694be533b4cf80718133a4ebdab3603b7187b347d543ccbee63eeec3';
                //!: Main Wallet Address
                let tokenAddress = '0xb3d7A1b25B16f2995d9B843E8be7734FA9948d5e'

                //!: Main Wallet Address
                let fromAddress = '0xc337948787a1970aDEbEA6b38B184cd6a21Ae6aa' // your wallet

                let contractABI = [

                    // transfer
                 
                    {
                 
                        'constant': false,
                 
                        'inputs': [
                 
                            {
                 
                                'name': '_to',
                 
                                'type': 'address'
                 
                            },
                 
                            {
                 
                                'name': '_value',
                 
                                'type': 'uint256'
                 
                            }
                 
                        ],
                 
                        'name': 'transfer',
                 
                        'outputs': [
                 
                            {
                 
                                'name': '',
                 
                                'type': 'bool'
                 
                            }
                 
                        ],
                 
                        'type': 'function'
                 
                    }
                 
                 ]
                 let values = carbonAmount;

                 let contract = new Web3js.eth.Contract(contractABI, tokenAddress, { from: fromAddress })

                 let amount = Web3js.utils.toHex(Web3js.utils.toWei(`${values}`)); //1 DEMO Token

                 let data = contract.methods.transfer(toAddress, amount).encodeABI()

                 let txObj = {

                    gas: Web3js.utils.toHex(100000),
             
                    "to": tokenAddress,
             
                    "value": "0x00",
             
                    "data": data,
             
                    "from": fromAddress
             
                }
                let signedTx;
                try
                {
                    signedTx = await Web3js.eth.accounts.signTransaction(txObj, privateKey)

                }
                catch(ex)
                {
                    this.logger.error("ERROR WHILE TRYING TO signTransaction");
                    this.logger.error(err)
                    return Promise.reject({ code: 500, message: "CARBON POINT WALLET A BISEYLER OLDU" });
                }
             
                console.log(signedTx)
                let rRes;
                try
                {
                    rRes = await Web3js.eth.sendSignedTransaction(signedTx.rawTransaction);

                }
                catch(ex)
                {
                    this.logger.error("ERROR WHILE TRYING TO sendSignedTransaction");
                    this.logger.error(ex)
                    return Promise.reject({ code: 500, message: "CARBON POINT WALLET A BISEYLER OLDU" });
                }         
                                
                console.log(rRes)
                return rRes;
        
            }
        },
        postCarbonPointToWallet:{
            rest:{
                method:"POST",
                path:"/postCarbonPointToWallet"
            },
            params:{
                walletId:"number",
                carbonAmount:"number"
            },

            async handler(ctx)
            {
                let walletId = ctx.params.walletId;
                let carbonAmount = ctx.params.carbonAmount;

                let wallet = await ctx.call("wlt.getWalletById",{Id:walletId});
                this.logger.info("WALLER FOUND");
                console.log(wallet);
                if(!wallet.IsSuccess)
                    return Promise.reject({ code: 400, message: "Unknown error bro" });
                
                wallet = wallet.Data;
                let walletClient = this.protoClient;
                const request = {
                    Id: walletId,
                    Data:{
                        Id:walletId,
                        CarbonPoint:(wallet.CarbonPoint + carbonAmount),
                        UserId:wallet.UserId,
                        CreatedAt:(wallet.CreatedAt)
                    }
                };

                try
                {
                    let mainRes =  await new Promise((resolve, reject) => {
                        walletClient.Update(request, (err, res) => {
                          if(err)
                            console.log(err);
                          resolve(res);
                        });
                      });

                      return mainRes;
                }
                catch(ex)
                {
                    this.logger.error("HATA VAR LANNNNN")
                    this.logger.error(ex);
                    return Promise.reject({ code: 400, message: "Unknown error bro" });

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
                    let user = await ctx.call("wlt.getWalletByUserId",ctx.params.userId);
                    if(user)
                        return Promise.reject({ code: 400, message: "There is already created wallet for that user" });

                }
                catch(ex)
                {
                }
                let walletClient = this.protoClient;
                const request = {
                    Id: 1,
                    Data: {
                      Id: 1,
                      CarbonPoint: 0,
                      UserId: ctx.params.userId,
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
        let homePageUrl = "host.docker.internal:3333";
        console.log(homePageUrl);
        this.protoClient = new proto.Database_Service.Grpc.DataServices.WalletDataService(homePageUrl,grpc.credentials.createInsecure());

    }
}


module.exports = walletService;