using FAO.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Tenant> TenantRepository { get; }
        IGenericRepository<Company> CompanyRepository { get; }
        IGenericRepository<Asset> AssetRepository { get; }
        IGenericRepository<Group> GroupRepository { get; }
        IGenericRepository<Companybook> CompanybookRepository { get; }
        IGenericRepository<Companyfield> CompanyfieldRepository { get; }

        void Commit();
    }
}
