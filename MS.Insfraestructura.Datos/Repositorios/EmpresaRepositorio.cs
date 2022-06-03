using AppVenta.Infraestructura.Datos.Contextos;
using MS.Dominio.Entidades.CobroExpress;
using MS.Dominio.Interfaces.CobroExpress.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Insfraestructura.Datos.Repositorios
{
    public class EmpresaRepositorio : IRepositorioBase<empresa, int>
    {
        private MSContexto db;

        public EmpresaRepositorio(MSContexto _db)
        {
            db = _db;
        }

        public bool DeleteAll()
        {
            List<empresa> entidad = Listar();
            db.RemoveRange(entidad);

            return true;
        }

        public List<empresa> Listar()
        {
            return db.Empresas.ToList();
        }

        public bool SaveEntity(empresa entidad)
        {
            db.Empresas.Add(entidad);
            return true;
        }

        public bool SaveEntity(List<empresa> entidad)
        {
            DeleteAll();
            foreach (empresa item in entidad)
            {
                db.Empresas.Add(item);
                db.SaveChanges();
            }

            return true;

            throw new NotImplementedException();
        }
        public empresa SeleccionarPorID(empresa entidadID)
        {
            throw new NotImplementedException();
        }
    }
}
