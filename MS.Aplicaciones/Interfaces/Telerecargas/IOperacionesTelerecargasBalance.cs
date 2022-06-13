using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Interfaces
{
    public interface IOperacionesTelerecargasBalance<T,I>
    {

        public T GetBalance(I produccion);



    }
}
