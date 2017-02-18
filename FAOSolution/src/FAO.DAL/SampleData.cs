using FAO.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.DAL
{
    public static class SampleData
    {
        public static async Task InitializeMusicStoreDatabaseAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<FAODbContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    await InsertTestData(serviceProvider);
                }
            }
        }

        private static async Task InsertTestData(IServiceProvider serviceProvider)
        {
            await AddOrUpdateAsync<Tenant>(serviceProvider, GetTenants());
            await AddOrUpdateAsync<Company>(serviceProvider, GetCompanies());
            await AddOrUpdateAsync<Asset>(serviceProvider, GetAssets());
        }

        private static async Task AddOrUpdateAsync<TEntity>(IServiceProvider serviceProvider, IEnumerable<TEntity> entities) where TEntity : class
        {
            // Query in a separate context so that we can attach existing entities as modified
            List<TEntity> existingData;
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<FAODbContext>();
                existingData = db.Set<TEntity>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<FAODbContext>();
                await db.Set<TEntity>().AddRangeAsync(entities);
                await db.SaveChangesAsync();
            }
        }

        private static Tenant[] GetTenants()
        {
            var tenants = new Tenant[]
            {
                new Tenant { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), Name = "Tenant1", IsActive = true },
                new Tenant { TenantId = new Guid("00000000-0000-0000-0000-000000000002"), Name = "Tenant2", IsActive = true },
                new Tenant { TenantId = new Guid("00000000-0000-0000-0000-000000000003"), Name = "Tenant3", IsActive = true }
            };
            return tenants;
        }

        private static Company[] GetCompanies()
        {
            var companies = new Company[]
            {
                new Company { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), CompanyId = new Guid("00000001-0000-0000-0000-000000000000"), LongName = "Company 1", BusnStart = DateTime.Now },
                new Company { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), CompanyId = new Guid("00000002-0000-0000-0000-000000000000"), LongName = "Company 2", BusnStart = DateTime.Now },
                new Company { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), CompanyId = new Guid("00000003-0000-0000-0000-000000000000"), LongName = "Company 3", BusnStart = DateTime.Now },
            };
            return companies;
        }

        private static Asset[] GetAssets()
        {
            var assets = new Asset[]
            {
                new Asset { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), CompanyId = new Guid("00000001-0000-0000-0000-000000000000"), AssetId = 1, PropType = "P" },
                new Asset { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), CompanyId = new Guid("00000001-0000-0000-0000-000000000000"), AssetId = 2, PropType = "P" },
                new Asset { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), CompanyId = new Guid("00000001-0000-0000-0000-000000000000"), AssetId = 3, PropType = "P" },
                new Asset { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), CompanyId = new Guid("00000001-0000-0000-0000-000000000000"), AssetId = 4, PropType = "P" },
                new Asset { TenantId = new Guid("00000000-0000-0000-0000-000000000001"), CompanyId = new Guid("00000001-0000-0000-0000-000000000000"), AssetId = 5, PropType = "P" },
            };
            return assets;
        }

    }
}
