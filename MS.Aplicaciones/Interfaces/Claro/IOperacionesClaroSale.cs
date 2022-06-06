using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Aplicaciones.Interfaces.Claro
{
    public interface IOperacionesClaroSale<TEntidad, T>
    {

        public T Sale(TEntidad entidad);




    }

}
