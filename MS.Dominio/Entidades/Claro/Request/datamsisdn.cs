using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Entidades.Claro.Request
{
    public class datamsisdn
    {
        public string fromdate { get; set; }
        public string todate { get; set; }//"AR"
        public string transactionid { get; set; }
        public string extrefnum { get; set; }//ref operador 
    }
}
