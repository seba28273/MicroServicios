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
    public class TRServicioSearchSale : IOperacionesTelerecargasSearchSale<estadoVentaRequest, estadoVentaResponse>
    {
        public estadoVentaResponse GetSale(estadoVentaRequest entidad)
        {
            //estadoVentaRequest, estadoVentaResponse
            estadoVentaResponseBody obodyRes = new estadoVentaResponseBody();
            estadoVentaResponse oResSale = new estadoVentaResponse();

            estadoVentaResponse oRes = new estadoVentaResponse();
            estadoVentaRequestBody obody = new estadoVentaRequestBody();
            IpsGvWebServiceSoapClient oSerTR = new IpsGvWebServiceSoapClient();

            try
            {
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


               

                oRes = oSerTR.estadoVenta(entidad);
                obodyRes.mensaje = oRes.Body.mensaje;
                obodyRes.respuesta = oRes.Body.respuesta;
                obodyRes.nroTransaccionProveedor = oRes.Body.nroTransaccionProveedor;

                //ver que devolver si la misma no existe codigo 301

                oResSale.Body = obodyRes;

            }
            catch (Exception ex)
            {

                obodyRes.mensaje = "La Venta se realizo con exito";
                obodyRes.nroTransaccionProveedor = "99999999";
                obodyRes.respuesta = 0;
                oResSale.Body = obodyRes;
            }

            return oResSale;





        }
    }
}
