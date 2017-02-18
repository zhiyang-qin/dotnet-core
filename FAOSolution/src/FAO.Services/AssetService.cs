using FAO.DAL.Entities;
using FAO.DtoMapper.Dtos;
using FAO.DtoMapper.Mappers;
using FAO.Repositories;
using FAO.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAO.Services
{
    public class AssetService : IAssetService
    {
        private IUnitOfWork _unitOfWork;

        public AssetService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<AssetDto> GetAllAssets(Guid tenantid, Guid companyid)
        {
            IEnumerable<Asset> assetList = _unitOfWork.AssetRepository.GetMany(asset=>asset.TenantId == tenantid && asset.CompanyId == companyid);
            IEnumerable<AssetDto> assetDtoList = assetList.Select(asset => AssetMapper.EntityMapToDto(asset));
            return assetDtoList;
        }

}
}
