using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using MediaLogue.Domain.Model;

namespace MediaLogue.Infrastructure.Data
{
    public interface IMediaLogueContext
    {
        DbSet<Show> Shows { get; }
        //DbSet<Episode> Episodes { get; }
    }

    public class MediaLogueContext : DbContext, IMediaLogueContext
    {
        public MediaLogueContext()
        {
            Database.SetInitializer<MediaLogueContext>(new CreateDatabaseIfNotExists<MediaLogueContext>());
        }
        public DbSet<Show> Shows { get; set; }
    //    public DbSet<Episode> Episodes { get; private set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ShowConfiguration());
            modelBuilder.Configurations.Add(new EpisodeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class ShowConfiguration : EntityTypeConfiguration<Show>
    {
        public ShowConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
    public class EpisodeConfiguration : EntityTypeConfiguration<Episode>
    {
        public EpisodeConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasRequired(t => t.Show)
                .WithMany(show => show.Episodes)
                .HasForeignKey(t => t.ShowId)
                .WillCascadeOnDelete();
        }
    }
}
