using Luse.Telerecargas.Services;
using MS.Aplicaciones.Interfaces;
using MS.Domain.Telerecargas.Comunications.Request;
using MS.Domain.Telerecargas.Comunications.Response;
using MS.Dominio.Interfaces;
using ServiceTR;
using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

namespace MS.Aplicaciones.Servicios.Telerecargas
{
    public class TRServicioBalance : IOperacionesTelerecargasBalance<ResponseBase>
    {
        public ResponseBase GetBalance()
        {
            resGetBalance oResBalance = new resGetBalance();
            try
            {

                consultaSaldoRequest oReq = new consultaSaldoRequest();
                consultaSaldoResponse oRes = new consultaSaldoResponse();

                IpsGvWebServiceSoapClient oSerTR = new IpsGvWebServiceSoapClient();


                consultaSaldoRequestBody obody = new consultaSaldoRequestBody();

                
                #region body
                BodyTR oBodyTR = new BodyTR();
                BodyBase oBodyreq = new BodyBase();
                oBodyreq = oBodyTR.GetBodyTR();
                obody.cliente = oBodyreq.cliente;
                obody.cuenta = oBodyreq.cuenta;
                obody.usuario = oBodyreq.usuario;
                obody.password = oBodyreq.password;
                oReq.Body = obody;
                #endregion

                #region security
                BasicHttpBinding result = new BasicHttpBinding();
                result.Security.Mode = BasicHttpSecurityMode.Transport;
                result.Security.Transport = new HttpTransportSecurity { ClientCredentialType = HttpClientCredentialType.None };

                oSerTR.Endpoint.Binding = result;

                oSerTR.ClientCredentials.ServiceCertificate.SslCertificateAuthentication =
                            new X509ServiceCertificateAuthentication()
                            {
                                CertificateValidationMode = X509CertificateValidationMode.None,
                                RevocationMode = X509RevocationMode.NoCheck
                            };

                
                CustomBinding binding = new CustomBinding(new CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11), new HttpsTransportBindingElement()); //Or  HttpsTransportBindingElement

                oSerTR.Endpoint.Binding = binding;

                #endregion

                oRes = oSerTR.consultaSaldo(oReq);
                oResBalance.Mensaje = oRes.Body.mensaje;
                oResBalance.Respuesta = oRes.Body.respuesta;
                oResBalance.Saldo = oRes.Body.saldo;
                //oSerTR.Close();
                return oResBalance;
            }
            catch (Exception ex)
            {

                oResBalance.Mensaje = "No se pudo obtener el saldo. " + ex.Message;
                oResBalance.Respuesta = -1;
                oResBalance.Saldo = 0;

                return oResBalance;
            }



        }
    }
}
