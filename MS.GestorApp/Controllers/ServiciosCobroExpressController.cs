using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppVenta.Infraestructura.Datos.Contextos;
using Microsoft.AspNetCore.Mvc;
using MS.Aplicaciones.Servicios.CobroExpress;
using MS.Dominio.Entidades.CobroExpress;
using MS.Insfraestructura.Datos.Repositorios;

namespace MS.GestorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosCobroExpressController : Controller
    {
        RubroServicio CrearServicio()
        {
            MSContexto db = new MSContexto();
            RubroRepositorio repo = new RubroRepositorio(db);
            RubroServicio servicio = new RubroServicio(repo);
            return servicio;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult<List<Rubro>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }


        [HttpGet("{CrearRubros}")]
        public ActionResult<List<Rubro>> CrearRubros()
        {
            var servicio = CrearServicio();
            servicio.Save();

            return Ok(servicio.Listar());
        }
    }
}