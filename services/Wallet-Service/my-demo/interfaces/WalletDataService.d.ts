export interface DataServiceRequest {
    Id: number
}

export interface DataServiceRequestWithEntity_Wallet {
    Id: number
    Data: Wallet
}

export interface DataServiceResponse_Wallet {
    IsSuccess: boolean
    Message: string
    Data: Wallet
}

export interface Wallet {
    Id: number
    CarbonPoint: number
    UserId: number
}

export interface WalletDataService
{
    Create(req:DataServiceRequestWithEntity_Wallet):Promise<DataServiceResponse_Wallet>,
    Delete(req:DataServiceRequest):Promise<DataServiceResponse_Wallet>,
    Get(req:DataServiceRequest):Promise<DataServiceResponse_Wallet>,
    Update(req:DataServiceRequestWithEntity_Wallet):Promise<DataServiceResponse_Wallet>,

}

 