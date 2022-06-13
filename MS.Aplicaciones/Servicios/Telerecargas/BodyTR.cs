using MS.Domain.Telerecargas.Comunications.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Aplicaciones.Servicios.Telerecargas
{
    public class BodyTR
    {

        public BodyBase GetBodyTR(int produccion)
        {
            BodyBase obody = new BodyBase();
            if (produccion == 1)
            {
                obody.cliente = 38414;
                obody.cuenta = 150198;
                obody.usuario = "cplus_h2h";
                obody.password = "cp1u5h2h31dar";
            }
            else
            {
                obody.cliente = 38414;
                obody.cuenta = 138602;
                obody.usuario = "cargaplustest";
                obody.password = "carga9753";
            }
           

            return obody;
        }

    }
}
