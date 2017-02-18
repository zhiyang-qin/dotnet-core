using System;
using FAO.DtoMapper.Dtos;
using System.Collections.Generic;

namespace FAO.Services.Interfaces
{
    public interface ICalculationService
    {
        PeriodDeprItemDto CalculateDepreciation(DepreciableBookDto deprBook, DateTime runDate);
        List<PeriodDeprItemDto> CalculateProjection(DepreciableBookDto deprBook);
        List<PeriodDeprItemDto> CalculateMonthlyProjection(DepreciableBookDto deprBook, DateTime startDate, DateTime endDate);
    }
}
