using System.Data.Entity.ModelConfiguration;

namespace Cooperchip.Common.Entity
{
    public abstract class CooperchipEntityAbstractConfig<TEntity> : EntityTypeConfiguration<TEntity> 
        where TEntity : class
    {
        public CooperchipEntityAbstractConfig()
        {
            ConfigTable();
            ConfigFields();
            ConfigPrimaryKey();
            ConfigForeignKey();
        }

        protected abstract void ConfigForeignKey();

        protected abstract void ConfigPrimaryKey();

        protected abstract void ConfigFields();

        protected abstract void ConfigTable();
    }
}
