using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Interfaces
{
    public interface IOperacionesTelerecargasSearchSale<TEntidad, T>
    {
   
        public T GetSale(TEntidad entidad);
       



    }
}
