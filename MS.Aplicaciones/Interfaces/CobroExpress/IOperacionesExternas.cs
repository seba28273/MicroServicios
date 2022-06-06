using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Interfaces.CobroExpress
{
    public interface IOperacionesCobroExternas<TEntidad, TEntidadID>
    {
        List<TEntidad> Listar();

        TEntidad SeleccionarPorID(TEntidad entidadID);

        bool Save(List<TEntidad> entidad);


        bool Save();

        bool DeleteAll();

    }
}
