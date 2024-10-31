 using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Hinges;
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
    public class HingeRepository : Repository<Hinge>, IHingeRepository
    {
        private readonly ApplicationDbContext _context;
        public HingeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Hinge> AddHingeAsync(AddHingeDTO AddHingeDTO)
        {
            // Obtener el objeto MaterialType relacionado con materialTypeId
            var hingeComponents =new List<HingeComponent>();

            // Agregar el subTypeMaterial al contexto
            var hingeSaved = await _context.Hinges.AddAsync(AddHingeDTO.Hinge);
            // Agregar el MaterialType al subTypeMaterialSaved
            foreach (var HingeComponents in hingeComponents)
            {
                //hingeSaved.Entity.Components.Add(HingeComponents);
            }

            return AddHingeDTO.Hinge;

        }
        public async Task DeleteHingeComponentAsync(int hingeId, int componentId)
        {
            // Busca la bisagra por su ID en la base de datos
            var hinge = await _context.Hinges.FindAsync(hingeId);

            // Verifica si se encontró la bisagra
            if (hinge != null)
            {
                // Busca el componente dentro de la lista de componentes de la bisagra
                var componentToRemove = new List<HingeHingeComponent>();

                // Verifica si se encontró el componente
                if (componentToRemove != null)
                {
                    // Elimina el componente de la lista de componentes de la bisagra

                    // Guarda los cambios en la base de datos
                    await _context.SaveChangesAsync();
                }
            }
        }


    }
}
