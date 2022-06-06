using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Aplicaciones.Interfaces.Claro
{
    public interface IOperacionesClaroSearchSale<TEntidad, T>
    {
        public T GetSale(TEntidad entidad);

    }
}
