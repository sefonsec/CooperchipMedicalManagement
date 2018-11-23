using Cooperchip.Common.Entity;
using Cooperchip.MedicalManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Infra.TypeConfiguration
{
    class CidadeTypeConfiguration : CooperchipEntityAbstractConfig<Cidade>
    {
        protected override void ConfigFields()
        {
            Property(pk => pk.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(d => d.Descricao)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnName("Descricao");

            Property(u => u.UfId)
                .IsRequired()
                .HasColumnName("UfId");
        }

        protected override void ConfigForeignKey()
        {
            HasRequired(pu => pu.Uf)
                .WithMany()
                .HasForeignKey(fk => fk.UfId)
                .WillCascadeOnDelete(false);
        }

        protected override void ConfigPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigTable()
        {
            ToTable("TBL_Cidade");
        }
    }
}
