﻿using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository.IRepository
{
    public interface IExternalAccessoryRepository : IRepository<ExternalAccessory>
    {
        List<Brand> GetBrands();
    }
}
