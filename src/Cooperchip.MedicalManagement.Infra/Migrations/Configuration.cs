using Cooperchip.MedicalManagement.Infra.Data.ORM.EF;
using System.Data.Entity.Migrations;

namespace Cooperchip.MedicalManagement.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MMDbContext context)
        {
   
        }
    }
}
