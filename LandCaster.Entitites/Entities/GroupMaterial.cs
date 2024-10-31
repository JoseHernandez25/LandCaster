using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class GroupMaterial
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int MaterialId { get; set; }
        // Relations
        public Group Group { get; set; }
        public Material Material { get; set; }
    }
}
