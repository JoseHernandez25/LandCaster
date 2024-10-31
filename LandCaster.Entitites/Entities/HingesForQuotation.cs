using System.ComponentModel.DataAnnotations;

namespace LandCaster.Entities.Entities
{
    public class HingesForQuotation
    {
        [Key]
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int HingeId { get; set; }
        public int? HingeTypeId { get; set; }
        public int Quantity { get; set; }

        public Furniture Furniture { get; set; }
        //public HingeType HingeType { get; set; }
        public Hinge Hinge { get; set; }
    }
}
