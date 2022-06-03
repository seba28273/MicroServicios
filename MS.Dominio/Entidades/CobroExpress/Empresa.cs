using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dominio.Entidades.CobroExpress
{
    public class empresa
    {

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Rubro { get; set; }
        public decimal Maximo { get; set; }
        public bool Parcial { get; set; }
        public bool SinFactura { get; set; }
        public IngresoManual IngresoManual { get; set; }

    }
    public class IngresoManual
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Longitud { get; set; }

        public string Tipo { get; set; }
    }
}
