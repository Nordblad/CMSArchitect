namespace Architect.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<PageContent> PageContents { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<CssFile> CssFiles { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Content>()
        //        .HasMany(e => e.PageContents)
        //        .WithRequired(e => e.Content)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Page>()
        //        .HasMany(e => e.PageContents)
        //        .WithRequired(e => e.Page)
        //        .WillCascadeOnDelete(false);
        //}
    }
}
