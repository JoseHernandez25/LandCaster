using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IDoorModelRepository : IRepository<DoorModel>
    {
        Task<DoorModel> AddDoorModelAsync(AddDoorModelDTO addDoorModelDTO);
    }
}
