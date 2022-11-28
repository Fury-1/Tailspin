using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tailspin.Surveys.Data.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chunk> Chunks { get; set; }
        public virtual DbSet<Chunk1> Chunks1 { get; set; }
        public virtual DbSet<ChunkGroup> ChunkGroups { get; set; }
        public virtual DbSet<ChunkGroup1> ChunkGroups1 { get; set; }
        public virtual DbSet<CitusTable> CitusTables { get; set; }
        public virtual DbSet<ContributorRequest> ContributorRequests { get; set; }
        public virtual DbSet<Option1> Options1 { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Stripe> Stripes { get; set; }
        public virtual DbSet<Stripe1> Stripes1 { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<SurveyContributor> SurveyContributors { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<User> Users { get; set; }

        // Unable to generate entity type for table 'columnar_internal.options' since its primary key could not be scaffolded. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=192.46.212.188;Database=aakash;Port=2002;User Id=aakash;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum("citus", "distribution_type", new[] { "hash", "range", "append" })
                .HasPostgresEnum("citus", "shard_transfer_mode", new[] { "auto", "force_logical", "block_writes" })
                .HasPostgresEnum("pg_catalog", "citus_copy_format", new[] { "csv", "binary", "text" })
                .HasPostgresEnum("pg_catalog", "citus_job_status", new[] { "scheduled", "running", "finished", "cancelling", "cancelled", "failing", "failed" })
                .HasPostgresEnum("pg_catalog", "citus_task_status", new[] { "blocked", "runnable", "running", "done", "cancelling", "error", "unscheduled", "cancelled" })
                .HasPostgresEnum("pg_catalog", "noderole", new[] { "primary", "secondary", "unavailable" })
                .HasPostgresExtension("citus")
                .HasPostgresExtension("citus_columnar")
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Chunk>(entity =>
            {
                entity.HasKey(e => new { e.StorageId, e.StripeNum, e.AttrNum, e.ChunkGroupNum })
                    .HasName("chunk_pkey");

                entity.ToTable("chunk", "columnar_internal");

                entity.HasComment("Columnar per chunk metadata");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.Property(e => e.StripeNum).HasColumnName("stripe_num");

                entity.Property(e => e.AttrNum).HasColumnName("attr_num");

                entity.Property(e => e.ChunkGroupNum).HasColumnName("chunk_group_num");

                entity.Property(e => e.ExistsStreamLength).HasColumnName("exists_stream_length");

                entity.Property(e => e.ExistsStreamOffset).HasColumnName("exists_stream_offset");

                entity.Property(e => e.MaximumValue).HasColumnName("maximum_value");

                entity.Property(e => e.MinimumValue).HasColumnName("minimum_value");

                entity.Property(e => e.ValueCompressionLevel).HasColumnName("value_compression_level");

                entity.Property(e => e.ValueCompressionType).HasColumnName("value_compression_type");

                entity.Property(e => e.ValueCount).HasColumnName("value_count");

                entity.Property(e => e.ValueDecompressedLength).HasColumnName("value_decompressed_length");

                entity.Property(e => e.ValueStreamLength).HasColumnName("value_stream_length");

                entity.Property(e => e.ValueStreamOffset).HasColumnName("value_stream_offset");
            });

            modelBuilder.Entity<Chunk1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("chunk", "columnar");

                entity.HasComment("Columnar chunk information for tables on which the current user has ownership privileges.");

                entity.Property(e => e.AttrNum).HasColumnName("attr_num");

                entity.Property(e => e.ChunkGroupNum).HasColumnName("chunk_group_num");

                entity.Property(e => e.ExistsStreamLength).HasColumnName("exists_stream_length");

                entity.Property(e => e.ExistsStreamOffset).HasColumnName("exists_stream_offset");

                entity.Property(e => e.MaximumValue).HasColumnName("maximum_value");

                entity.Property(e => e.MinimumValue).HasColumnName("minimum_value");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.Property(e => e.StripeNum).HasColumnName("stripe_num");

                entity.Property(e => e.ValueCompressionLevel).HasColumnName("value_compression_level");

                entity.Property(e => e.ValueCompressionType).HasColumnName("value_compression_type");

                entity.Property(e => e.ValueCount).HasColumnName("value_count");

                entity.Property(e => e.ValueDecompressedLength).HasColumnName("value_decompressed_length");

                entity.Property(e => e.ValueStreamLength).HasColumnName("value_stream_length");

                entity.Property(e => e.ValueStreamOffset).HasColumnName("value_stream_offset");
            });

            modelBuilder.Entity<ChunkGroup>(entity =>
            {
                entity.HasKey(e => new { e.StorageId, e.StripeNum, e.ChunkGroupNum })
                    .HasName("chunk_group_pkey");

                entity.ToTable("chunk_group", "columnar_internal");

                entity.HasComment("Columnar chunk group metadata");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.Property(e => e.StripeNum).HasColumnName("stripe_num");

                entity.Property(e => e.ChunkGroupNum).HasColumnName("chunk_group_num");

                entity.Property(e => e.RowCount).HasColumnName("row_count");
            });

            modelBuilder.Entity<ChunkGroup1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("chunk_group", "columnar");

                entity.HasComment("Columnar chunk group information for tables on which the current user has ownership privileges.");

                entity.Property(e => e.ChunkGroupNum).HasColumnName("chunk_group_num");

                entity.Property(e => e.RowCount).HasColumnName("row_count");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.Property(e => e.StripeNum).HasColumnName("stripe_num");
            });

            modelBuilder.Entity<CitusTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("citus_tables");

                entity.Property(e => e.CitusTableType).HasColumnName("citus_table_type");

                entity.Property(e => e.ColocationId).HasColumnName("colocation_id");

                entity.Property(e => e.DistributionColumn).HasColumnName("distribution_column");

                entity.Property(e => e.ShardCount).HasColumnName("shard_count");

                entity.Property(e => e.TableSize).HasColumnName("table_size");
            });

            modelBuilder.Entity<ContributorRequest>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.Id })
                    .HasName("ContributorRequests_pkey");

                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Created).HasColumnType("timestamp with time zone");

                entity.Property(e => e.EmailAddress).IsRequired();

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.ContributorRequests)
                    .HasForeignKey(d => new { d.SurveyId, d.TenantId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContributorRequests_Surveys_SurveyId");
            });

            modelBuilder.Entity<Option1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("options", "columnar");

                entity.HasComment("Columnar options for tables on which the current user has ownership privileges.");

                entity.Property(e => e.ChunkGroupRowLimit).HasColumnName("chunk_group_row_limit");

                entity.Property(e => e.CompressionLevel).HasColumnName("compression_level");

                entity.Property(e => e.StripeRowLimit).HasColumnName("stripe_row_limit");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => new { e.TenantId, e.Id })
                    .HasName("Questions_pkey");

                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Text).IsRequired();

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => new { d.SurveyId, d.TenantId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_SurveyId");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("storage", "columnar");

                entity.HasComment("Columnar relation ID to storage ID mapping.");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");
            });

            modelBuilder.Entity<Stripe>(entity =>
            {
                entity.HasKey(e => new { e.StorageId, e.StripeNum })
                    .HasName("stripe_pkey");

                entity.ToTable("stripe", "columnar_internal");

                entity.HasComment("Columnar per stripe metadata");

                entity.HasIndex(e => new { e.StorageId, e.FirstRowNumber }, "stripe_first_row_number_idx")
                    .IsUnique();

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.Property(e => e.StripeNum).HasColumnName("stripe_num");

                entity.Property(e => e.ChunkGroupCount).HasColumnName("chunk_group_count");

                entity.Property(e => e.ChunkRowCount).HasColumnName("chunk_row_count");

                entity.Property(e => e.ColumnCount).HasColumnName("column_count");

                entity.Property(e => e.DataLength).HasColumnName("data_length");

                entity.Property(e => e.FileOffset).HasColumnName("file_offset");

                entity.Property(e => e.FirstRowNumber).HasColumnName("first_row_number");

                entity.Property(e => e.RowCount).HasColumnName("row_count");
            });

            modelBuilder.Entity<Stripe1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("stripe", "columnar");

                entity.HasComment("Columnar stripe information for tables on which the current user has ownership privileges.");

                entity.Property(e => e.ChunkGroupCount).HasColumnName("chunk_group_count");

                entity.Property(e => e.ChunkRowCount).HasColumnName("chunk_row_count");

                entity.Property(e => e.ColumnCount).HasColumnName("column_count");

                entity.Property(e => e.DataLength).HasColumnName("data_length");

                entity.Property(e => e.FileOffset).HasColumnName("file_offset");

                entity.Property(e => e.FirstRowNumber).HasColumnName("first_row_number");

                entity.Property(e => e.RowCount).HasColumnName("row_count");

                entity.Property(e => e.StorageId).HasColumnName("storage_id");

                entity.Property(e => e.StripeNum).HasColumnName("stripe_num");
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TenantId })
                    .HasName("Surveys_pkey");

                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Surveys_tenant_tenantId");
            });

            modelBuilder.Entity<SurveyContributor>(entity =>
            {
                entity.HasKey(e => new { e.SurveyId, e.UserId, e.TenantId })
                    .HasName("SurveyContributors_pkey");

                entity.Property(e => e.SurveyId).HasDefaultValueSql("uuid_generate_v4()");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.SurveyContributors)
                    .HasForeignKey(d => new { d.SurveyId, d.TenantId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SurveyContributors_Surveys_SurveyId1");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Created).HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TenantId })
                    .HasName("PK_User");

                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Created).HasColumnType("timestamp with time zone");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Tenant_TenantId");
            });

            modelBuilder.HasSequence("pg_dist_cleanup_recordid_seq", "pg_catalog");

            modelBuilder.HasSequence("pg_dist_colocationid_seq", "pg_catalog").HasMax(4294967296);

            modelBuilder.HasSequence("pg_dist_groupid_seq", "pg_catalog").HasMax(4294967296);

            modelBuilder.HasSequence("pg_dist_node_nodeid_seq", "pg_catalog").HasMax(4294967294);

            modelBuilder.HasSequence("pg_dist_operationid_seq", "pg_catalog");

            modelBuilder.HasSequence("pg_dist_placement_placementid_seq", "pg_catalog");

            modelBuilder.HasSequence("pg_dist_shardid_seq", "pg_catalog").HasMin(102008);

            modelBuilder.HasSequence("storageid_seq", "columnar_internal").HasMin(10000000000);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
