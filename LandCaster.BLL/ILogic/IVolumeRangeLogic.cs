using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Discounts;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IVolumeRangeLogic
    {
        Task<IEnumerable<VolumeRange>> GetVolumeRangeAsync();
        Task<IEnumerable<DiscountType>> GetDiscountTypeAsync();

        Task<VolumeRange> AddVolumeRangeAsync(AddVolumeRangeDTO addVolumeRangeDTO);

        Task<VolumeRange> UpdateVolumeRangeAsync(int id, UpdateVolumenRangeDTO updateVolumeRangeDTO);
        //Task<VolumeRange> UpdateVolumeRangeAsync(int id, VolumeRange volumeRange);


    }
}
