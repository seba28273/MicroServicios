using MS.Aplicaciones.Interfaces;
using MS.Dominio.Entidades.CobroExpress;
using MS.Dominio.Interfaces.CobroExpress.Repositorios;
using Newtonsoft.Json;
using ServiceCE;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Aplicaciones.Servicios.CobroExpress
{
    public class EmpresaServicio : IServicioBase<empresa, int>
    {
        private readonly IRepositorioBase<empresa, int> repoEmpresa;

        public EmpresaServicio(IRepositorioBase<empresa, int> _repoEmpresa)
        {
            repoEmpresa = _repoEmpresa;
        }


        public EmpresaServicio()
        {

        }


        public bool DeleteAll()
        {
            throw new NotImplementedException();
        }

        public List<empresa> Listar()
        {
           return repoEmpresa.Listar();
        }

        public bool Save()
        {
            try
            {
                BuscarEmpresasRequest oreq = new BuscarEmpresasRequest();
                tEntidad entity = new tEntidad();
                entity.Usuario = "EldarTest";
                entity.Clave = "U4dq45Z";
                tParamBuscarEmpresas oParam = new tParamBuscarEmpresas();
                oParam.Entidad = entity;
                oreq.Param = oParam;
                BuscarEmpresasResponse ores = new BuscarEmpresasResponse();
                IpwsCobranzaGlobalClient o = new IpwsCobranzaGlobalClient();

                ores = o.BuscarEmpresas(oreq);


                List<empresa> oListEmpresas = JsonConvert.DeserializeObject<List<empresa>>(ores.@return.Empresas.ToString());


                //List<Empresa> oListEmpresas = new List<Empresa>();

                //foreach (tEmpresa item in ores.@return.Empresas)
                //{
                //    Empresa oEmpresa = new Empresa();
                //    oEmpresa.Codigo = item.Codigo;
                //    oEmpresa.Rubro = item.Rubro;
                //    oListEmpresas.Add(oEmpresa);
                //}

                bool mRes = false;

                mRes = repoEmpresa.SaveEntity(oListEmpresas);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

           
        }

        public empresa SeleccionarPorID(empresa entidadID)
        {
            throw new NotImplementedException();
        }

        public bool Save(List<empresa> entidad)
        {
            throw new NotImplementedException();
        }
    }
}
