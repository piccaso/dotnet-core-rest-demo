using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbModel
{
    public partial class postgresContext : DbContext
    {
        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<ArticleGroup> ArticleGroup { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Vote> Vote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=192.168.56.101;Database=postgres;Username=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("plpython2u");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article", "db");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('db.article_id_seq'::regclass)");

                entity.Property(e => e.ArticleIsTrue).HasColumnName("articleIsTrue");

                entity.Property(e => e.FbComments).HasColumnName("fbComments");

                entity.Property(e => e.FbLikes).HasColumnName("fbLikes");

                entity.Property(e => e.FbShares).HasColumnName("fbShares");

                entity.Property(e => e.FkGroup).HasColumnName("fkGroup");

                entity.Property(e => e.FkScreenshot).HasColumnName("fkScreenshot");

                entity.Property(e => e.Heading)
                    .IsRequired()
                    .HasColumnName("heading");

                entity.Property(e => e.MetricsAlteration).HasColumnName("metricsAlteration");

                entity.Property(e => e.MetricsTrue).HasColumnName("metricsTrue");

                entity.Property(e => e.SourceUrl)
                    .IsRequired()
                    .HasColumnName("sourceUrl");

                entity.Property(e => e.Summary)
                    .IsRequired()
                    .HasColumnName("summary");

                entity.Property(e => e.TwLikes).HasColumnName("twLikes");

                entity.Property(e => e.TwRetweets).HasColumnName("twRetweets");

                entity.HasOne(d => d.FkGroupNavigation)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.FkGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_fkGropu");

                entity.HasOne(d => d.FkScreenshotNavigation)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.FkScreenshot)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_fkScreenshot");
            });

            modelBuilder.Entity<ArticleGroup>(entity =>
            {
                entity.ToTable("articleGroup", "db");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('db.\"articleGroup_id_seq\"'::regclass)");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image", "db");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('db.image_id_seq'::regclass)");

                entity.Property(e => e.ContentType)
                    .IsRequired()
                    .HasColumnName("contentType");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");
            });

            modelBuilder.Entity<Vote>(entity =>
            {
                entity.ToTable("vote", "db");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('db.vote_id_seq'::regclass)");

                entity.Property(e => e.FkArticle).HasColumnName("fkArticle");

                entity.Property(e => e.Ts)
                    .HasColumnName("ts")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.FkArticleNavigation)
                    .WithMany(p => p.Vote)
                    .HasForeignKey(d => d.FkArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vote_fkArticle");
            });

            modelBuilder.HasSequence("article_id_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("articleGroup_id_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("image_id_seq")
                .HasMin(1)
                .HasMax(2147483647);

            modelBuilder.HasSequence("vote_id_seq")
                .HasMin(1)
                .HasMax(2147483647);
        }
    }
}
