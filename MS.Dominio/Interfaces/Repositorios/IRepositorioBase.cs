using System;
using System.Collections.Generic;
using System.Text;
using MS.Dominio.Entidades.CobroExpress;
using MS.Dominio.Interfaces;

namespace MS.Dominio.Interfaces.CobroExpress.Repositorios
{

    public interface IRepositorioBase<TEntidad, TEntidadID>
    {
        List<TEntidad> Listar();

        TEntidad SeleccionarPorID(TEntidad entidadID);

        bool SaveEntity(List<TEntidad> entidad);

        bool DeleteAll();


    }

}
