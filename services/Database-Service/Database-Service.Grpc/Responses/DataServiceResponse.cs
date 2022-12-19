using ProtoBuf;

namespace Database_Service.Grpc.Responses
{
    [ProtoContract]
    public class DataServiceResponse<T>
    {
        public DataServiceResponse()
        {

        }
        public DataServiceResponse(string msg,T data,bool isSuccess)
        {
            Message = msg;
            Data = data;
            IsSuccess = isSuccess;
        }

        [ProtoMember(1)]
        public bool IsSuccess { get; set; }

        [ProtoMember(2)]
        public string Message { get; set; } = string.Empty;

        [ProtoMember(3)]
        public T Data { get; set; }

    }
}
