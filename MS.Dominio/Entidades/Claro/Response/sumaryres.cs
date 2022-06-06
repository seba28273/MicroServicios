using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Entidades.Claro.Response
{
    public class sumaryres
    {
        public string transactionid { get; set; }
        public string txndate { get; set; }
        public string network { get; set; }
        public string sendermsisdn { get; set; }
        public string msisdn { get; set; }
        public string subservice { get; set; }
        public string usrtype { get; set; }
        public string entrytype { get; set; }
        public string transvalue { get; set; }
        public string trfdate { get; set; }

        public string extrefnum { get; set; }
    }
}
