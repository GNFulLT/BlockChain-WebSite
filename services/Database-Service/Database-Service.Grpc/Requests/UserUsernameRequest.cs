using ProtoBuf;

namespace Database_Service.Grpc.Requests
{
   [ProtoContract]
   public class UserUsernameRequest
   {    
        [ProtoMember(1)]
        
        public string Username { get; set; }

   }
}
