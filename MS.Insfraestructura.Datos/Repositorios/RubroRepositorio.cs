using AppVenta.Infraestructura.Datos.Contextos;
using MS.Dominio.Entidades.CobroExpress;
using MS.Dominio.Interfaces.CobroExpress.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MS.Insfraestructura.Datos.Repositorios
{
    public class RubroRepositorio : IRepositorioBase<Rubro, int>
    {
        private MSContexto db;

        public RubroRepositorio(MSContexto _db)
        {
            db = _db;
        }

        public bool DeleteAll()
        {
            List<Rubro> entidad = Listar();
            db.RemoveRange(entidad);

            return true;
        }

        public List<Rubro> Listar()
        {
            return db.Rubros.ToList();
        }

        public bool SaveEntity(Rubro entidad)
        {
            db.Rubros.Add(entidad);
            return true;
        }

        public bool SaveEntity(List<Rubro> entidad)
        {
            DeleteAll();
            foreach (Rubro item in entidad)
            {
                db.Rubros.Add(item);
                db.SaveChanges();
            }

            return true;

            throw new NotImplementedException();
        }
        public Rubro SeleccionarPorID(Rubro entidadID)
        {
            throw new NotImplementedException();
        }
    }
}
