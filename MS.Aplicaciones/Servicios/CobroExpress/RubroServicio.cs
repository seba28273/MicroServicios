using MS.Aplicaciones.Interfaces;
using MS.Dominio.Entidades.CobroExpress;
using MS.Dominio.Interfaces.CobroExpress.Repositorios;
using Newtonsoft.Json;
using ServiceCE;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace MS.Aplicaciones.Servicios.CobroExpress
{
    public class RubroServicio : IServicioBase<Rubro, int>
    {
        private readonly IRepositorioBase<Rubro, int> repoRubro;

        public RubroServicio(IRepositorioBase<Rubro, int> _repoRubro)
        {
            repoRubro = _repoRubro;
        }


        public RubroServicio()
        {

        }

        public List<Rubro> Listar()
        {
            return repoRubro.Listar();
        }

        public Rubro SeleccionarPorID(Rubro entidadID)
        {
            throw new NotImplementedException();
        }

        public bool Save(List<Rubro> entidad)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            try
            {
                BuscarRubrosRequest oreq = new BuscarRubrosRequest();
                tEntidad entity = new tEntidad();
                entity.Usuario = "EldarTest";
                entity.Clave = "U4dq45Z";
                tParamBuscarRubros oParam = new tParamBuscarRubros();
                oParam.Entidad = entity;
                oreq.Param = oParam;
                BuscarRubrosResponse ores = new BuscarRubrosResponse();

                IpwsCobranzaGlobalClient o = new IpwsCobranzaGlobalClient();

                ores = o.BuscarRubros(oreq);

                List<Rubro> oListRubros = new List<Rubro>();

                string jsonString = JsonConvert.SerializeObject(ores.@return.Rubros);


                oListRubros = JsonConvert.DeserializeObject<List<Rubro>>(jsonString);
                List<Rubro> oListRubros3 = new List<Rubro>();

                //foreach (tRubros item in ores.@return.Rubros)
                //{
                //    Rubro oRubro = new Rubro();
                //    oRubro.CodRub = item.CodRub;
                //    oRubro.DescriRub = item.DescriRub;
                //    oListRubros.Add(oRubro);
                //}

                bool mRes = false;

                mRes = repoRubro.SaveEntity(oListRubros);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
