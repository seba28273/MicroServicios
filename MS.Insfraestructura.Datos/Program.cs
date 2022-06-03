using AppVenta.Infraestructura.Datos.Contextos;
using System;

namespace MS.Insfraestructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            MSContexto db = new MSContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("Listo!!!!!");
            Console.ReadKey();
        }
    }
}
