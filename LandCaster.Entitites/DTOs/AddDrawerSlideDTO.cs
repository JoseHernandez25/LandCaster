using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AddDrawerSlideDTO
    {
            public DrawerSlide DrawerSlide { get; set; }
            public DrawerSlideDrwsComponent[] Components { get; set; }
    }
}


