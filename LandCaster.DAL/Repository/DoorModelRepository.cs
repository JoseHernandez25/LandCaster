using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.DAL.Repository
{
    public class DoorModelRepository : Repository<DoorModel>, IDoorModelRepository
    {
        private readonly ApplicationDbContext _context;
        public DoorModelRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<DoorModel> AddDoorModelAsync(AddDoorModelDTO addDoorModelDTO)
        {
            // Obtener el objeto MaterialType relacionado con materialTypeId
            var typesBoxJournies = _context.TypesBoxJournies.Where(mt => addDoorModelDTO.TypesBoxJourneyIds.Contains(mt.Id)).ToList();
            var materials = _context.Materials.Where(m => addDoorModelDTO.MaterialIds.Contains(m.Id)).ToList();
            var doorTypes = _context.DoorTypes.Where(dt => addDoorModelDTO.DoorTypeIds.Contains(dt.Id)).ToList();

            // Agregar el subTypeMaterial al contexto
            var doorModelSaved = await _context.DoorModels.AddAsync(addDoorModelDTO.DoorModel);
            // Agregar el MaterialType al subTypeMaterialSaved
            foreach (var typesBoxJourney in typesBoxJournies)
            {
                doorModelSaved.Entity.TypesBoxJournies.Add(typesBoxJourney);
            }

            foreach (var material in materials)
            {
                doorModelSaved.Entity.Materials.Add(material);
            }
            foreach (var doorType in doorTypes)
            {
                doorModelSaved.Entity.DoorTypes.Add(doorType);
            }

            await _context.SaveChangesAsync();

            return doorModelSaved.Entity;

            //return addDoorModelDTO.DoorModel;

        }
    }
}
