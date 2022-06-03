using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Interfaces
{
    public interface IOperacionesTelerecargasVentas<TEntidad, T>
    {
   
        public T Sale(TEntidad entidad);
       



    }
}
