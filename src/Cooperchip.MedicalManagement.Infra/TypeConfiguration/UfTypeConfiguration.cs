using Cooperchip.Common.Entity;
using Cooperchip.MedicalManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Infra.TypeConfiguration
{
    class UfTypeConfiguration : CooperchipEntityAbstractConfig<Uf>
    {
        protected override void ConfigFields()
        {
            Property(pk => pk.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(s => s.Sigla)
                .IsRequired()
                .HasMaxLength(2).IsFixedLength()
                .HasColumnName("Sigla");

            Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Estado");

            Property(ce => ce.CodigoEstado)
                .IsRequired()
                .HasColumnName("CodigoEstado");
        }

        protected override void ConfigForeignKey()
        {            
        }

        protected override void ConfigPrimaryKey()
        {
            //PrimaryKey
            HasKey(pk => pk.Id);        
        }

        protected override void ConfigTable()
        {
            ToTable("TBL_Uf");
        }
    }
}
