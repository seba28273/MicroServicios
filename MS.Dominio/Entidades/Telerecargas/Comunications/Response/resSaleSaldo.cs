using System;
using System.Collections.Generic;
using System.Text;
using MS.Domain.Telerecargas.Comunications.Request;
namespace MS.Domain.Telerecargas.Comunications.Response
{

    public partial class resSaleSaldo : ResponseBase
    {

       
        public int respuesta { get; set; }

       
        public string mensaje { get; set; }

 
        public string nroTransaccionProveedor { get; set; }
    }
}
