using FCamara.FrederickFrigieri.Domain.Entities;
using FCamara.FrederickFrigieri.Infra.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FCamara.FrederickFrigieri.Infra.Data.Contexts
{
    public class Contexto : DbContext
    {
        public Contexto() 
            : base(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=FCamara;Persist Security Info=True;")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.EnsureTransactionsForFunctionsAndCommands = false;
        }

        #region DbSet
        public DbSet<ProdutoEntity> ProdutoEntities { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Conventios
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            #endregion

            modelBuilder.Configurations.Add(new ProdutoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
