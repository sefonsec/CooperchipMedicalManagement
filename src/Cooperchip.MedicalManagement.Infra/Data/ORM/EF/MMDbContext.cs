using Cooperchip.MedicalManagement.Domain.Entities;
using Cooperchip.MedicalManagement.Infra.TypeConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Cooperchip.MedicalManagement.Infra.Data.ORM.EF
{
    public class MMDbContext : DbContext
    {
        public MMDbContext() : base("MMDbContexto")
        {
        }

        public DbSet<Uf> Uf { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Bairro> Bairro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Add FluentApi Map
            modelBuilder.Configurations.Add(new UfTypeConfiguration());
            modelBuilder.Configurations.Add(new CidadeTypeConfiguration());
            modelBuilder.Configurations.Add(new BairroTypeConfiguration());

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(80));

            base.OnModelCreating(modelBuilder);
        }
    }
}
