using System;
using FAO.DAL;
using FAO.DAL.Entities;

namespace FAO.Repositories.RepoExts
{
    public static class CompanyRepoExt
    {
        public static bool Delete(this IGenericRepository<Company> companyRepo, Guid tenantId, Guid companyId)
        {
            bool returnValue = false;
            return returnValue;
        }

    }
}
