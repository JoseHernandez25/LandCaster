using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs.Discounts;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class VolumeRangeRepository : Repository<VolumeRange>, IVolumeRangeRepository
    {
        private readonly ApplicationDbContext _context;

        public VolumeRangeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;

        }

        public async Task<VolumeRange> AddVolumeRangeAsync(AddVolumeRangeDTO addVolumeRangeDTO)
        {
            // Obtener el objeto MaterialType relacionado con materialTypeId
            var discountTypes = _context.DiscountTypes.Where(mt => addVolumeRangeDTO.DiscountTypesIds.Contains(mt.Id)).ToList();
          

            // Agregar el subTypeMaterial al contexto
            var volumeRangesSaved = await _context.VolumeRanges.AddAsync(addVolumeRangeDTO.VolumeRange);
            // Agregar el MaterialType al subTypeMaterialSaved
            foreach (var DiscountTypes in discountTypes)
            {
                volumeRangesSaved.Entity.DiscountTypes.Add(DiscountTypes);
            }


            await _context.SaveChangesAsync();

            return volumeRangesSaved.Entity;

            //return addDoorModelDTO.DoorModel;

        }

        public async Task<VolumeRange> UpdateVolumeRangeAsync(int id, UpdateVolumenRangeDTO updateVolumeRangeDTO)
        {
            var existingVolumeRange = await _context.VolumeRanges.FindAsync(id);
            if (existingVolumeRange == null)
            {
                throw new KeyNotFoundException("VolumeRange not found");
            }

            // Actualizar propiedades del VolumeRange
            existingVolumeRange.StartRange = updateVolumeRangeDTO.VolumeRange.StartRange;
            existingVolumeRange.EndRange = updateVolumeRangeDTO.VolumeRange.EndRange;
            existingVolumeRange.DiscountType = updateVolumeRangeDTO.VolumeRange.DiscountType;

            // Actualizar los DiscountTypes si es necesario
            existingVolumeRange.DiscountTypes.Clear();
            foreach (var discountTypeId in updateVolumeRangeDTO.DiscountTypesIds)
            {
                var discountType = await _context.DiscountTypes.FindAsync(discountTypeId);
                if (discountType != null)
                {
                    existingVolumeRange.DiscountTypes.Add(discountType);
                }
            }

            _context.VolumeRanges.Update(existingVolumeRange);
            await _context.SaveChangesAsync();

            return existingVolumeRange;
        }
    }
}
