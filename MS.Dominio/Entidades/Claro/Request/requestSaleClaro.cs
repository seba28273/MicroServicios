using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Entidades.Claro.Request
{
    public class requestSaleClaro
    {
        public string reqGatewayLoginId { get; set; }
        public string reqGatewayPassword { get; set; }
        public string reqGatewayCode { get; set; }
        public string reqGatewayType { get; set; }
        public string servicePort { get; set; }
        public string sourceType { get; set; }
        public data data { get; set; }

    }
}
