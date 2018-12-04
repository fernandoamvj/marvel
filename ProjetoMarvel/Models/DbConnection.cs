namespace ProjetoMarvel.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbConnection : DbContext
    {
        public DbConnection()
            : base("name=DbConnection")
        {
        }

        public virtual DbSet<Pesquisa> Pesquisa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pesquisa>()
                .Property(e => e.texto_pesquisa)
                .IsUnicode(false);
        }
    }
}
