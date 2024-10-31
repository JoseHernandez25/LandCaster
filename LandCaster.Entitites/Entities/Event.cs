using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    public class Event : TimeStamp
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public TypeEvent Type { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
    public enum TypeEvent
    {
        Alta = 1,
        Baja = 2,
    }
}
