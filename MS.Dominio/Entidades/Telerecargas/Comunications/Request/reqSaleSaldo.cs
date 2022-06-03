using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Domain.Telerecargas.Comunications.Request
{
    public class reqSaleSaldo : RequestBase
    {


        public string usuario { get; set; }


        public string password { get; set; }


        public int cliente { get; set; }


        public int cuenta { get; set; }


        public string nroTransaccionExt { get; set; }


        public string terminalNumber { get; set; }


        public string terminalType { get; set; }


        public int producto { get; set; }


        public string prefijoPais { get; set; }


        public string codigoArea { get; set; }


        public string numeroTelefono { get; set; }


        public string datosRecarga { get; set; }


        public int importe { get; set; }

    }
}
