using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Service.Grpc.Requests
{
    [ProtoContract]
    public class DataServiceRequestWithEntity<T>
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public T Data { get; set; }
    }
}
