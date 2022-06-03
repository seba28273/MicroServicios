using System;
using System.Collections.Generic;
using System.Text;

using MS.Dominio.Interfaces.CobroExpress;
using MS.Dominio.Interfaces;
namespace MS.Aplicaciones.Interfaces
{
    interface IServicioBase<TEntidad, TEntidadID>
         : IOperacionesCobroExternas<TEntidad, TEntidadID>
    {
    }
}
