using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Domain.Telerecargas.Comunications.Request
{
    public class reqGetBalance : RequestBase
    {
        public string usuario { get; set; }

        public string password { get; set; }
        public int cliente { get; set; }

        public int cuenta { get; set; }

        public string terminalNumber { get; set; }

        public string terminalType { get; set; }
    }

}
