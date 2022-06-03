using MS.Domain.Telerecargas.Comunications.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Domain.Telerecargas.Comunications.Response
{
    public class resGetBalance : ResponseBase
    {
        public int Respuesta { get; set; }

        public string Mensaje { get; set; }
        public int Saldo { get; set; }

    }
}
