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
    public class TypesBoxJourneyRepository : Repository<TypesBoxJourney>, ITypesBoxJourneyRepository
    {
        private readonly ApplicationDbContext _context;

        public TypesBoxJourneyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<TypesBoxJourney> AddTypesBoxJourneyAsync(AddTypesBoxJourneyDTO addTypesBoxJourneyDTO)
        {
            // Obtener el objeto MaterialType relacionado con materialTypeId
            var typesBoxJournies = _context.DoorModels.Where(mt => addTypesBoxJourneyDTO.DoorModelIds.Contains(mt.Id)).ToList();

            // Agregar el subTypeMaterial al contexto
            var typesBoxJourneySaved = await _context.TypesBoxJournies.AddAsync(addTypesBoxJourneyDTO.TypesBoxJourney);
            // Agregar el MaterialType al subTypeMaterialSaved
            foreach (var typeBoxJourney in typesBoxJournies)
            {
                typesBoxJourneySaved.Entity.DoorModels.Add(typeBoxJourney);
            }

            return addTypesBoxJourneyDTO.TypesBoxJourney;

        }

    }
}
