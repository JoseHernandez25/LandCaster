﻿using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IJoineryTypeRepository : IRepository<JoineryType>
    {
        Task<JoineryType> AddJoineryTypeAsync(AddJoineryTypeDTO addJoineryTypeDTO);
    }
}
