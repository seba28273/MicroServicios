using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MS.Aplicaciones.Interfaces.Claro;
using MS.Dominio.Entidades.Claro.Request;
using MS.Dominio.Entidades.Claro.Response;
using Newtonsoft.Json;

namespace MS.GestorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesClaroController : ControllerBase
    {

        private readonly IOperacionesClaroSale<requestSaleClaro, responseSaleClaro> _ServiciosClaroSale;
        private readonly IOperacionesClaroSearchSale<requestSearchClaro, responseSaleClaro> _ServiciosSearchClaroSale;
        public ServicesClaroController(IOperacionesClaroSale<requestSaleClaro, responseSaleClaro> serviciosClaro , 
            IOperacionesClaroSearchSale<requestSearchClaro, responseSaleClaro> servicesSearchClaro)
        {
            _ServiciosClaroSale = serviciosClaro;
            _ServiciosSearchClaroSale = servicesSearchClaro;
        }


        [HttpGet]
        public IActionResult Index()
        {


            return Ok("EJECUCION SERVICIO CLARo");
        }


        [HttpPost]
        [Route("SaleClaro")]
        public IActionResult SaleClaro([FromBody] requestSaleClaro prequestSaleClaro)
        {

            //CONTROLADOR QUE LLAMA A LA CLASE ServicesTelerecargas PARA CONSUMIR EL METODO GetBalance
            //ACA NO ME QUEDO OTRA QUE HACER UN NEW, PERO EN TEORIA DEBERIA USAR INTERFACES E INYECCION DE DEPENDENCIAS
            responseSaleClaro oSale = new responseSaleClaro();
            requestSaleClaro oSaleRequest = new requestSaleClaro();


           // oSaleRequest = JsonConvert.DeserializeObject<requestSaleClaro>(Venta);

          

            string mRes = "";
            //mRes = JsonConvert.SerializeObject(oSaleRequest);

            oSale = _ServiciosClaroSale.Sale(prequestSaleClaro);

            mRes = JsonConvert.SerializeObject(oSale);

            return Ok(mRes);
        }


        [HttpPost]
        [Route("SearchSaleClaro")]
        public IActionResult GetSaleClaro([FromBody] requestSearchClaro orequestSearchClaro)
        {

            //CONTROLADOR QUE LLAMA A LA CLASE ServicesTelerecargas PARA CONSUMIR EL METODO GetBalance
            //ACA NO ME QUEDO OTRA QUE HACER UN NEW, PERO EN TEORIA DEBERIA USAR INTERFACES E INYECCION DE DEPENDENCIAS
            responseSaleClaro oSale = new responseSaleClaro();
            requestSaleClaro oSaleRequest = new requestSaleClaro();


            // oSaleRequest = JsonConvert.DeserializeObject<requestSaleClaro>(Venta);



            string mRes = "";
            //mRes = JsonConvert.SerializeObject(oSaleRequest);

            oSale = _ServiciosSearchClaroSale.GetSale(orequestSearchClaro);

            mRes = JsonConvert.SerializeObject(oSale);

            return Ok(mRes);
        }



    }
}