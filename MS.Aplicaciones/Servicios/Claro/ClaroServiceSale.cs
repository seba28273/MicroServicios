using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.Text;
using MS.Aplicaciones.Interfaces.Claro;
using MS.Dominio.Entidades.Claro.Request;
using MS.Dominio.Entidades.Claro.Response;
using Newtonsoft.Json;

namespace MS.Aplicaciones.Servicios.Claro
{
    public class ClaroServiceSale : IOperacionesClaroSale<requestSaleClaro, responseSaleClaro>
    {
        public responseSaleClaro Sale(requestSaleClaro entidad)
        {
            //URL WEB	https://test-recargas.claro.com.ar/pretups/

            //URL Servicios	https://test-recargas-ws-ar.claro.amx


            //https://recargas-ws-ar.claro.amx/pretups/rest/c2s-rest-receiver/rctrf
            //https://test-recargas-ws-ar.claro.amx/pretups/rest/c2s-rest-receiver/rctrf

            string sUrlRequest = "https://test-ariris-ws.claro.amx/webaxn/IRIS/c2sservice";//"https://test-ariris-ws.claro.amx/webaxn/IRIS/c2sservice";

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(sUrlRequest);

            httpWebRequest.ContentType = "application/json";

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);



            httpWebRequest.Method = "POST";

            //httpWebRequest.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
            //               new X509ServiceCertificateAuthentication()
            //               {
            //                   CertificateValidationMode = X509CertificateValidationMode.None,
            //                   RevocationMode = X509RevocationMode.NoCheck
            //               };

            

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

        private string TranslateMessage(string pCode)
        {
            switch (pCode)
            {
                case "": return "La Venta se realizo con exito";
                case "6010": return "Proveedor No Disponible(5)";//No dispone de suficiente saldo para realizar la venta de ARS {0}. (Cod: 6010)
                case "7002": return "Ud No esta habilitado para realizar transacciones"; //Lo sentimos, usted se encuentra temporalmente suspendido. Gracias por utilizar el servicio de Recargas de Claro. (Cod: 7002) 
                case "7013": return "Usted no esta autorizado a utilizar este servicio";//Usted no esta autorizado a utilizar este servicio. Contactese con su Administrador. (Cod: 7013)
                case "7015": return "PIN invalido";//El PIN Ingresado no es correcto. (Cod: 7015)

                case "7025": return "Lo sentimos, no estan permitidas las transferencias a este perfil. (Cod: 7025) ";
                case "7042": return "Su Pin ha sido bloqueado. Pongase en contacto con su agencia para desbloquearlo. (Cod: 7042)";
                case "7043": return "Esta intentando utilizar un conjunto de rangos de recarga suspendido. Intente con otro monto. (Cod: 7043)";

                case "7517": return "No se ha encontrado ninguna transferencia. (Cod: 7517)";
                case "8512": return "Limite de venta superado";//"El punto de venta supero el limite de venta permitido. (Cod: 8512)";
                case "9007": return "";//Se produjo un error procesando su solicitud. Intente nuevamente mas tarde. Gracias por utilizar el servicio de Recargas de Claro. (Cod: 9007)

                case "11101": return "Numero invalido para la compania";//La longitud del numero no es valida. (Cod: 11101)
                case "11103": return "Numero invalido para la compania";//El numero ingresado no es valido para la red de Claro Argentina. (Cod: 11103)
                case "11104": return "Longitud de Pin invalido";// La longitud del PIN no es válida. (Cod: 11104) 

                case "25034": return "No posee permisos para acceder al menu. Contactese con el Administrador. (Cod: 25034) ";
                case "3006201": return "La Venta ya existe";//Venta duplicada, ya se ha registrado una venta al numero {0} con el mismo monto. Aguarde 5 minutos si desea realizar esta venta nuevamente. (Cod: 3006201) 
                case "17005_R": return "Error al procesar la recarga. Intente mas tarde";//Su solicitud no puede ser procesada en este momento. Gracias por utilizar el servicio de Recargas de Claro. (Cod: 17005_R) 
                case "17017_R": return "Numero invalido para la compania";// "El suscriptor informado no existe, revise los datos ingresados e intente nuevamente. (Cod: 17017_R)";
                case "2071": return "Monto Invalido";//El monto ARS {0} no es valido. Ingrese un monto valido para realizar la recarga. (Cod: 2071)
                case "2124": return "Usuario o Contrasenia incorrectos";//El usuario de acceso a servicios es incorrecto. (Cod: 2124)
                case "2206": return "Usuario o Contrasenia incorrectos";//La contraseña del usuario de acceso al servicio es incorrecta. (Cod: 2206)";

                default:
                    pCode = "9999";
                    return "No se obtuvo respuesta de la compania";
            }


        }

        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }
}
