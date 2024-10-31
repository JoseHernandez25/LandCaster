using LandCaster.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.Entities.Entities
{
    [EntityTypeConfiguration(typeof(DrawerSlideComponentConfiguration))]
    public class DrawerSlideComponent : TimeStamp
    {
        public int Id { get; set; }
        public string SupplierCode { get; set; }
        public string Name { get; set;}
        public double Cost { get; set;}


        //Relations
        public int CurrencieId { get; set; }
        public Currencie Currencie { get; set; } = null!;
        public int? BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public int UnitId { get; set; }
        public Unit Unit { get; set; } = null!;
        public List<DrawerSlideDrwsComponent> DrawerSlideDrwsComponents { get; } = new();
    }
}
