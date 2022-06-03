using MS.Domain.Telerecargas.Comunications.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Aplicaciones.Servicios.Telerecargas
{
    public class BodyTR
    {

        public BodyBase GetBodyTR()
        {
            BodyBase obody = new BodyBase();
            obody.cliente = 38414;
            obody.cuenta = 138602;
            obody.usuario = "cargaplustest";
            obody.password = "carga9753";

            return obody;
        }

    }
}
