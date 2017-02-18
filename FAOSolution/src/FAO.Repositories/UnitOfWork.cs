using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAO.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using FAO.DAL;

namespace FAO.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly FAODbContext dbContext;
        private GenericRepository<Tenant> _tenantRepo;
        private GenericRepository<Company> _companyRepo;
        private GenericRepository<Asset> _assetRepo;
        private GenericRepository<Group> _groupRepo;
        private GenericRepository<Companybook> _companybookRepo;
        private GenericRepository<Companyfield> _companyfieldRepo;

        public UnitOfWork(FAODbContext context)
        {
            this.dbContext = context;
        }

        public IGenericRepository<Tenant> TenantRepository
        {
            get
            {
                if (_tenantRepo == null)
                    _tenantRepo = new GenericRepository<Tenant>(dbContext);
                return _tenantRepo;
            }
        }

        public IGenericRepository<Company> CompanyRepository
        {
            get
            {
                if (_companyRepo == null)
                    _companyRepo = new GenericRepository<Company>(dbContext);
                return _companyRepo;
            }
        }

        public IGenericRepository<Asset> AssetRepository
        {
            get
            {
                if (_assetRepo == null)
                    _assetRepo = new GenericRepository<Asset>(dbContext);
                return _assetRepo;
            }
        }

        public IGenericRepository<Group> GroupRepository
        {
            get
            {
                if (_groupRepo == null)
                    _groupRepo = new GenericRepository<Group>(dbContext);
                return _groupRepo;
            }
        }

        public IGenericRepository<Companybook> CompanybookRepository
        {
            get
            {
                if (_companybookRepo == null)
                    _companybookRepo = new GenericRepository<Companybook>(dbContext);
                return _companybookRepo;
            }
        }

        public IGenericRepository<Companyfield> CompanyfieldRepository
        {
            get
            {
                if (_companyfieldRepo == null)
                    _companyfieldRepo = new GenericRepository<Companyfield>(dbContext);
                return _companyfieldRepo;
            }
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
