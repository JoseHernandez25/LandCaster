using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Hinges;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IHingeRepository : IRepository<Hinge>
    {
        Task<Hinge> AddHingeAsync(AddHingeDTO addHingeDTO);
        Task DeleteHingeComponentAsync(int hingeId, int componentId);
    }
}
