using MS.Aplicaciones.Interfaces.Claro;
using MS.Dominio.Entidades.Claro.Request;
using MS.Dominio.Entidades.Claro.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MS.Aplicaciones.Servicios.Claro
{
    public class ClaroServiceSearchSale : IOperacionesClaroSearchSale<requestSearchClaro, responseSaleClaro>
    {
        public responseSaleClaro GetSale(requestSearchClaro entidad)
        {
            //URL WEB	https://test-recargas.claro.com.ar/pretups/

            //URL Servicios	https://test-recargas-ws-ar.claro.amx


            //https://recargas-ws-ar.claro.amx/pretups/rest/c2s-rest-receiver/rctrf
            //https://test-recargas-ws-ar.claro.amx/pretups/rest/c2s-rest-receiver/rctrf

            string sUrlRequest = "https://170.51.249.207/pretups/rest/opt-rest-receiver/c2strfenq";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(sUrlRequest);

            httpWebRequest.ContentType = "application/json";

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);



            httpWebRequest.Method = "POST";


            var jsonBodyConsulta = JsonConvert.SerializeObject(entidad);
            //string jsonString = JsonConvert.SerializeObject(ores.@return.Rubros);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(jsonBodyConsulta);

                streamWriter.Flush();

            }

            responseSaleClaro oRes = new responseSaleClaro();
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    var result = streamReader.ReadToEnd();


                    oRes = JsonConvert.DeserializeObject<responseSaleClaro>(result);

                    return oRes;


                }
            }
            catch (Exception e)
            {
                oRes.statusCode = 500;
                oRes.dataObject.txnid = "0";
                oRes.dataObject.message = e.Message;
                oRes.dataObject.errorcode = "500";
                return oRes;
            }

        }

      
        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
