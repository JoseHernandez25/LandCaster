using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.Entities;
using LandCaster.Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        private readonly ApplicationDbContext _context;

        public ColorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        //public void update(Categoria categoria)
        //{
        //    var categoriaBD = _context.Categorias.FirstOrDefault(b => b.Id == categoria.Id);
        //    if (categoriaBD != null)
        //    {
        //        categoriaBD.Nombre = categoria.Nombre;
        //        categoriaBD.Descripcion = categoria.Descripcion;
        //        categoriaBD.Estado = categoria.Estado;
        //        _context.SaveChanges();
        //
        //    }
        //}


        public List<Brand> GetBrands()
        {
            var brands = _context.SubCategories
                                .Include(sc => sc.Brands)
                                .FirstOrDefault(sc => sc.Id == 1)?
                                .Brands
                                .ToList();
            return brands;
        }


    }
}
