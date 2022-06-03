using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using MS.Dominio.Entidades.CobroExpress;
using MS.Insfraestructura.Datos.Configs;

namespace AppVenta.Infraestructura.Datos.Contextos
{
    public class MSContexto : DbContext
    {
        public DbSet<Rubro> Rubros { get; set; }
        public DbSet<empresa> Empresas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=192.168.5.2; Initial Catalog=ProduccionCE; Persist Security Info=True; Password=Luse_2010; User ID=CobroExpress;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RubroConfig());
            builder.ApplyConfiguration(new EmpresaConfig());


        }
    }
}