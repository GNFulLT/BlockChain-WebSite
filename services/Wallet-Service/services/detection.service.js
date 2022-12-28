const axios = require("axios")
const FormData = require('form-data');
const Busboy = require('busboy');
const formidable = require('formidable');


/**
 * @typedef {import('moleculer').ServiceSchema} ServiceSchema Moleculer's Service Schema
 * @typedef {import('moleculer').Context} Context Moleculer's Context
 */

/** @type {ServiceSchema} */

const detectionService = {
    name : "detection",
    settings:{
        
    },
    dependencies:[
        "discovery"
    ],
    actions:
    {
        detect:
        {
            rest:
            {
                method:"POST",
                path:"/detectObject"
            },
            params:{
                walletId:"number",
                productName:"string"
            },
            async handler(ctx)
            {
                let walletId = ctx.params.walletId;
                let productName = ctx.params.productName;
                                
                let gainedCarbon = 50;
                if(productName == "bottle")
                {
                    gainedCarbon = 100;
                }
                else if(productName == "can")
                {
                    gainedCarbon = 80;
                }
                else if(productName == "cup")
                {
                    gainedCarbon = 150;
                }
                try
                {
                    let walletRes = await ctx.call("wlt.postCarbonPointToWallet",{walletId,carbonAmount:gainedCarbon});
                    return {gainedCarbonPoint:gainedCarbon};
                }
                catch(ex)
                {
                    return Promise.reject({ code: 500, message: "CARBON POINT WALLET A BISEYLER OLDU" });

                }
            }
        }
    }
}

module.exports = detectionService;