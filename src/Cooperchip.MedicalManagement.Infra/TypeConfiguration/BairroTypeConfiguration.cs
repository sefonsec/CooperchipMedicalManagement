using Cooperchip.Common.Entity;
using Cooperchip.MedicalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooperchip.MedicalManagement.Infra.TypeConfiguration
{
    class BairroTypeConfiguration : CooperchipEntityAbstractConfig<Bairro>
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

            Property(cfk => cfk.CidadeId)
                .IsRequired()
                .HasColumnName("CidadeId");
        }

        protected override void ConfigForeignKey()
        {
            HasRequired(fkobj => fkobj.Cidade)
                .WithMany()
                .HasForeignKey(fk => fk.CidadeId)
                .WillCascadeOnDelete(false);
        }

        protected override void ConfigPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigTable()
        {
            ToTable("TLB_Bairro");
        }
    }
}
