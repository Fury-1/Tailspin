// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Tailspin.Surveys.Data.DataModels
{
    public class ApplicationDbContext : DbContext
    {
 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        //public override 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
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

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.Created).HasColumnType("timestamp with time zone");
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
        }

        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<SurveyContributor> SurveyContributors { get; set; }

        public DbSet<ContributorRequest> ContributorRequests { get; set; }
    }
}
