using Microsoft.EntityFrameworkCore;
using FAO.DAL.Entities;
using System;

namespace FAO.DAL
{
    public class FAODbContext : DbContext
    {
        private readonly string _connectionString;
        //public FAODbContext(string connectionString = @"Server=.;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;")
        //{

        //    _connectionString = connectionString;
        //}

        public FAODbContext(DbContextOptions<FAODbContext> options) :
            base(options)
        {
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Partialinfo> Partialinfos { get; set; }
        public DbSet<Bookpart> Bookparts { get; set; }
        public DbSet<Assetevent> Assetevents { get; set; }
        public DbSet<Assetimage> Assetimages { get; set; }
        public DbSet<Companybook> Companybooks { get; set; }
        public DbSet<Companyfield> Companyfields { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Groupcriteria> Groupcriterias { get; set; }
        public DbSet<Groupsort> Groupsorts { get; set; }
        public DbSet<Selection> Selections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_connectionString);



            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set keys for Entity in order
            modelBuilder.Entity<Field>().HasKey("FieldId");

            modelBuilder.Entity<Tenant>().HasKey("TenantId");

            modelBuilder.Entity<Company>().HasKey("TenantId", "CompanyId");

            modelBuilder.Entity<Companybook>().HasKey("TenantId", "CompanyId", "BookId");

            modelBuilder.Entity<Companyfield>().HasKey("TenantId", "CompanyId", "FieldId");
            modelBuilder.Entity<Selection>().HasKey("TenantId", "CompanyId", "FieldId", "SelectionId");

            modelBuilder.Entity<Group>().HasKey("TenantId", "CompanyId", "GroupId");
            modelBuilder.Entity<Groupcriteria>().HasKey("TenantId", "CompanyId", "GroupId", "CriteriaId");
            modelBuilder.Entity<Groupsort>().HasKey("TenantId", "CompanyId", "GroupId", "SortId");

            modelBuilder.Entity<Asset>().HasKey("TenantId", "CompanyId", "AssetId");
            modelBuilder.Entity<Assetevent>().HasKey("TenantId", "CompanyId", "AssetId", "EventId");
            modelBuilder.Entity<Assetimage>().HasKey("TenantId", "CompanyId", "AssetId", "ImageId");
            modelBuilder.Entity<Partialinfo>().HasKey("TenantId", "CompanyId", "AssetId", "SequenceId");
            modelBuilder.Entity<Bookpart>().HasKey("TenantId", "CompanyId", "AssetId", "SequenceId", "BookId");

            base.OnModelCreating(modelBuilder);
        }

    }

}
