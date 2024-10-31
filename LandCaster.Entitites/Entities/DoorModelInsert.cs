using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class DoorModelInsert
    {
        [Key]
        public int Id { get; set; }

        public int DoorModelId { get; set; }

        public int InsertId { get; set; }
        public string Position { get; set; }

        public DoorModel DoorModel { get; set; }
        public Insert Insert { get; set; }
    }
}
