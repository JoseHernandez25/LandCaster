using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities.Catalogs
{
    public class Accessory
{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? DeletedAt { get; set; }
    }
}
