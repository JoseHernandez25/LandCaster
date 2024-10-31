﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class FurnitureDrawer 
    {
        [Key]
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int DrawerId { get; set; }
        public int Quantity { get; set; }
        public Furniture Furniture { get; set; }
        public Drawer Drawer { get; set; }
    }
}