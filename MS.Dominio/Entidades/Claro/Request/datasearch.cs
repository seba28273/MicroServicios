using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Entidades.Claro.Request
{
    public class datasearch
    {
        public string date { get; set; }
        public string extnwcode { get; set; }//"AR"
        public string msisdn { get; set; }
        public string pin { get; set; }
        public string loginid { get; set; }
        public string password { get; set; }
        public string extcode { get; set; }
        public string extrefnum { get; set; }//ref operador
        public string catcode { get; set; }//   "catcode":"SM", 
        public string srvtype { get; set; }
        public string sendermsisdn { get; set; }

        public string msisdn2 { get; set; }
        public datamsisdn data { get; set; }

    }
}
