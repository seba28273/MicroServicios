using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Entidades.Claro.Request
{
    public class requestSearchClaro
    {
        public string reqGatewayLoginId { get; set; }
        public string reqGatewayPassword { get; set; }
        public string reqGatewayCode { get; set; }
        public string reqGatewayType { get; set; }
        public string servicePort { get; set; }//"190"
        public string sourceType { get; set; }//"JSON"
        public datasearch data { get; set; }

    }

}
