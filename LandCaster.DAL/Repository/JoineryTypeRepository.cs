using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class JoineryTypeRepository : Repository<JoineryType>, IJoineryTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public JoineryTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<JoineryType> AddJoineryTypeAsync(AddJoineryTypeDTO addJoineryTypeDTO)
        {
            // Obtener el objeto MaterialType relacionado con materialTypeId
            var joineryes = _context.Joineries.Where(mt => addJoineryTypeDTO.JoineryIds.Contains(mt.Id)).ToList();

            // Agregar el subTypeMaterial al contexto
            var joineryTypeSaved = await _context.JoineryTypes.AddAsync(addJoineryTypeDTO.JoineryType);
            // Agregar el MaterialType al subTypeMaterialSaved
            foreach (var joinery in joineryes)
            {
                joineryTypeSaved.Entity.Joineries.Add(joinery);
            }

            return addJoineryTypeDTO.JoineryType;

        }
    }
}
