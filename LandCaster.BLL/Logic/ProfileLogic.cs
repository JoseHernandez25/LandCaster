using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class ProfileLogic : IProfileLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfileLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<Profile>> GetProfileAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters["term"].ToString();

            if (term == null) term = "";

            var profile = _unitOfWork.Profile.PaginateGetAsync(
                parameters: parameters,
                c => (c.Name.Contains(term)),
                orderBy: null,
                relationships: "DoorModels",
                isTracking: false
            );


            var paginationResponse = await PaginationHelper.CreatePaginationResponse(profile, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<Profile> AddProfileAsync(Profile profile)

        {
        

            var createdProfile = _unitOfWork.Profile.Create(profile);
            await _unitOfWork.Save();

            return profile;
        }

        public async Task<Profile> UpdateProfileAsync(int id, Profile profile)
        {
            _unitOfWork.Profile.Update(profile);
            await _unitOfWork.Save();
            return profile;
        }

        public async Task<Profile> DeleteProfileAsync(int id)
        {
            var profile = await _unitOfWork.Profile.Find(id);

            profile.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Profile.Update(profile);
            await _unitOfWork.Save();
            return profile;
        }
    }
}
