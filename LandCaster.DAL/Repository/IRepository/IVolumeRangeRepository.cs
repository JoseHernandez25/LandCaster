using LandCaster.Entities.DTOs.Discounts;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IVolumeRangeRepository : IRepository<VolumeRange>
    {
        Task<VolumeRange> AddVolumeRangeAsync(AddVolumeRangeDTO addVolumeRangeDTO);
        Task<VolumeRange> UpdateVolumeRangeAsync(int id, UpdateVolumenRangeDTO updateVolumeRangeDTO);


    }
}
