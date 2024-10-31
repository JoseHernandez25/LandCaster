using LandCaster.DAL.Migrations;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class SubTypeMaterialRepository : Repository<SubTypeMaterial>, ISubTypeMaterialRepository
    {
        private readonly ApplicationDbContext _context;

        public SubTypeMaterialRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<SubTypeMaterial> AddSubTypeMaterialAsync(AddSubTypeMaterialDTO addSubTypeMaterialDTO)
        {
            // Obtener el objeto MaterialType relacionado con materialTypeId
            var materialTypes = _context.MaterialTypes.Where(mt => addSubTypeMaterialDTO.MaterialTypeIds.Contains(mt.Id)).ToList();

            // Agregar el subTypeMaterial al contexto
            var subTypeMaterialSaved = await _context.SubTypeMaterials.AddAsync(addSubTypeMaterialDTO.SubTypeMaterial);
            // Agregar el MaterialType al subTypeMaterialSaved
            foreach (var materialType in materialTypes)
            {
                subTypeMaterialSaved.Entity.MaterialTypes.Add(materialType);
            }

            return addSubTypeMaterialDTO.SubTypeMaterial;

        }

        public async Task AddFinishToSubTypeMaterialAsync(AddFinishToSubTypeDTO addFinishToSubTypeMaterialDTO)
        {
            var subTypeMaterial = await _context.SubTypeMaterials.Include(stm => stm.Finishes)
                                                                  .FirstOrDefaultAsync(stm => stm.Id == addFinishToSubTypeMaterialDTO.SubTypeMaterialId);

            if (subTypeMaterial == null)
            {
                throw new Exception("SubTypeMaterial not found");
            }

            var finish = await _context.Finishes.FindAsync(addFinishToSubTypeMaterialDTO.FinishId);
            if (finish == null)
            {
                throw new Exception("Finish not found");
            }

            subTypeMaterial.Finishes.Add(finish);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveFinishFromSubTypeMaterialAsync(AddFinishToSubTypeDTO addFinishToSubTypeMaterialDTO)
        {
            var subTypeMaterial = await _context.SubTypeMaterials.Include(stm => stm.Finishes)
                                                                  .FirstOrDefaultAsync(stm => stm.Id == addFinishToSubTypeMaterialDTO.SubTypeMaterialId);

            if (subTypeMaterial == null)
            {
                throw new Exception("SubTypeMaterial not found");
            }

            var finish = await _context.Finishes.FindAsync(addFinishToSubTypeMaterialDTO.FinishId);
            if (finish == null)
            {
                throw new Exception("Finish not found");
            }

            subTypeMaterial.Finishes.Remove(finish);

            await _context.SaveChangesAsync();
        }


    }
}
