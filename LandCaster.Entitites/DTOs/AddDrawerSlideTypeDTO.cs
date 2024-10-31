using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.DTOs
{
    public class AddDrawerSlideTypeDTO
    {
        public DrawerSlide[] drawerSlides { get; set; }
        public string Name { get; set; }
        public bool isSimple { get; set; }

    }
}
