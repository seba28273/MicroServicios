using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Interfaces.CobroExpress
{
    public interface IOperacionesCobroExpress<TEntidad, TEntidadID>
    {
        List<TEntidad> Listar();

        TEntidad SeleccionarPorID(TEntidad entidadID);

        bool Save(TEntidad entidad);

        bool SaveRubros();
        

        bool DeleteAll();

    }
}
