﻿using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class InternalAccessoryType : TimeStamp
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<InternalAccessory> InternalAccessories { get; } = new();

    }
}
