using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LandCaster.Entities.Entities
{
    public class HingeHingeComponent
    {
        [Key]
        public int Id { get; set; }

        public int HingeId { get; set; }

        public int ComponentId { get; set; }
        public int Quantity { get; set; }

        public Hinge Hinge { get; set; }
        public HingeComponent Component { get; set; }
    }
}
