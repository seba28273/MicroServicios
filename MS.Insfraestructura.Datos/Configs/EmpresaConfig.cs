using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Dominio.Entidades.CobroExpress;

namespace MS.Insfraestructura.Datos.Configs
{
    class EmpresaConfig : IEntityTypeConfiguration<empresa>
    {
        public void Configure(EntityTypeBuilder<empresa> builder)
        {
            builder.ToTable("CobroExpressEmpresas");
            builder.HasKey(c => c.Codigo);

            //builder
            //    .HasMany(empresa => empresa.IngresoManual)
            //    .WithOne(ingresomanual => ingresomanual.Codigo);
           


        }


    }


}
