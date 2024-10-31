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
    public class JoineryRepository : Repository<Joinery>, IJoineryRepository
    {
        private readonly ApplicationDbContext _context;
        public JoineryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Joinery> AddJoineryAsync(AddJoineryDTO addJoineryDTO)
        {
            // Obtener el objeto MaterialType relacionado con materialTypeId
            var joineryTypes = _context.JoineryTypes.Where(mt => addJoineryDTO.JoineryTypeIds.Contains(mt.Id)).ToList();

            // Agregar el subTypeMaterial al contexto
            var joinerySaved = await _context.Joineries.AddAsync(addJoineryDTO.Joinery);
            // Agregar el MaterialType al subTypeMaterialSaved
            foreach (var joineryType in joineryTypes)
            {
                joinerySaved.Entity.JoineryTypes.Add(joineryType);
            }

            return addJoineryDTO.Joinery;

        }
    }
}
