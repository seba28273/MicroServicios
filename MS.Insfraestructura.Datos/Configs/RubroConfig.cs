using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS.Dominio.Entidades.CobroExpress;

namespace MS.Insfraestructura.Datos.Configs
{
    class RubroConfig : IEntityTypeConfiguration<Rubro>
    {
        public void Configure(EntityTypeBuilder<Rubro> builder)
        {
            builder.ToTable("CobroExpressRubros");
            builder.HasKey(c => c.CodRub);


        }


    }


}
