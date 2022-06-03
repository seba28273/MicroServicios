//using FuegoDeQuasar.Domain.Comunications.Requests;
//using FuegoDeQuasar.Domain.Comunications.Responses;
//using FuegoDeQuasar.Trilateration.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MS.Aplicaciones.Interfaces;
using MS.Aplicaciones.Servicios.Telerecargas;
using MS.Domain;
using MS.Domain.Telerecargas.Comunications;
using MS.Domain.Telerecargas.Comunications.Request;
using MS.Domain.Telerecargas.Comunications.Response;
using MS.Dominio.Interfaces;
using Newtonsoft.Json;
using ServiceTR;

namespace MS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesTRController : ControllerBase
    {

        private readonly IOperacionesTelerecargasBalance<ResponseBase> _ServicesBalance;
        private readonly IOperacionesTelerecargasVentas<ventaRecargaRequest, consultaRecargaResponse> _ServicesTelerecargas;
        private readonly IOperacionesTelerecargasSearchSale<estadoVentaRequest, estadoVentaResponse> _ServiciosSearchSaleTR;
        public ServicesTRController(IOperacionesTelerecargasVentas<ventaRecargaRequest, consultaRecargaResponse> serviciosTR,
            IOperacionesTelerecargasBalance<ResponseBase> serviciosBalanceTR,
            IOperacionesTelerecargasSearchSale<estadoVentaRequest, estadoVentaResponse> serviciosSearchSaleTR)
        {
            _ServicesTelerecargas = serviciosTR;
            _ServicesBalance = serviciosBalanceTR;
            _ServiciosSearchSaleTR = serviciosSearchSaleTR;
        }


        [HttpGet]
        public IActionResult Index()
        {


            return Ok("EJECUCION SERVICIO");
        }

        [HttpGet]
        [Route("GetSaleTR")]
        public IActionResult GetSaleTR(string Venta)
        {

            //CONTROLADOR QUE LLAMA A LA CLASE ServicesTelerecargas PARA CONSUMIR EL METODO GetBalance
            //ACA NO ME QUEDO OTRA QUE HACER UN NEW, PERO EN TEORIA DEBERIA USAR INTERFACES E INYECCION DE DEPENDENCIAS
            estadoVentaResponse oSale = new estadoVentaResponse();
            estadoVentaRequest oSaleRequest = new estadoVentaRequest();
            estadoVentaRequestBody obody = new estadoVentaRequestBody();
            obody = JsonConvert.DeserializeObject<estadoVentaRequestBody>(Venta);


            #region body
            BodyTR oBodyTR = new BodyTR();
            BodyBase oBodyreq = new BodyBase();

            oBodyreq = oBodyTR.GetBodyTR();
            obody.cliente = oBodyreq.cliente;
            obody.cuenta = oBodyreq.cuenta;
            obody.usuario = oBodyreq.usuario;
            obody.password = oBodyreq.password;
            obody.terminalNumber = "";
            obody.terminalType = "";
            oSaleRequest.Body = obody;
            #endregion

            string mRes = "";

            oSale = _ServiciosSearchSaleTR.GetSale(oSaleRequest);

            mRes = JsonConvert.SerializeObject(oSale);

            return Ok(mRes);
        }


        [HttpGet]
        [Route("GetBalanceTR")]
        public IActionResult GetBalanceTR()
        {

            //CONTROLADOR QUE LLAMA A LA CLASE ServicesTelerecargas PARA CONSUMIR EL METODO GetBalance
            //ACA NO ME QUEDO OTRA QUE HACER UN NEW, PERO EN TEORIA DEBERIA USAR INTERFACES E INYECCION DE DEPENDENCIAS
            ResponseBase oBalance = new resGetBalance();

            oBalance = _ServicesBalance.GetBalance();


            return Ok(oBalance);
        }


        [HttpPost]
        [Route("SaleTR")]
        public IActionResult SaleTR(string Venta)
        {

            //CONTROLADOR QUE LLAMA A LA CLASE ServicesTelerecargas PARA CONSUMIR EL METODO GetBalance
            //ACA NO ME QUEDO OTRA QUE HACER UN NEW, PERO EN TEORIA DEBERIA USAR INTERFACES E INYECCION DE DEPENDENCIAS
            consultaRecargaResponse oSale = new consultaRecargaResponse();
            ventaRecargaRequest oSaleRequest = new ventaRecargaRequest();
            ventaRecargaRequestBody obody = new ventaRecargaRequestBody();
            obody = JsonConvert.DeserializeObject<ventaRecargaRequestBody>(Venta);

            #region body
            BodyTR oBodyTR = new BodyTR();
            BodyBase oBodyreq = new BodyBase();
            oBodyreq = oBodyTR.GetBodyTR();
            obody.cliente = oBodyreq.cliente;
            obody.cuenta = oBodyreq.cuenta;
            obody.usuario = oBodyreq.usuario;
            obody.password = oBodyreq.password;
            oSaleRequest.Body = obody;
            #endregion


            string mRes = "";
            //mRes = JsonConvert.SerializeObject(oSaleRequest);

            oSale = _ServicesTelerecargas.Sale(oSaleRequest);
           
            mRes =  JsonConvert.SerializeObject(oSale);

            return Ok(mRes);
        }



    }
}
