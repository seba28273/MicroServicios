using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Domain.Telerecargas.Comunications.Request
{
    public class RequestBase
    {
    }
    public class ResponseBase
    {
    }


    public class BodyBase
    {
        public int cliente { get; set; }
        public int cuenta { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
    }

}
