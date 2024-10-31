using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class ProductEventLogic : IProductEventLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductEventLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginationResponse<ProductEvent>> GetProductEventAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<ProductEvent>, IOrderedQueryable<ProductEvent>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<ProductEvent>, IOrderedQueryable<ProductEvent>>? value = orderByField switch
            {
                "folio" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Folio) : query.OrderByDescending(c => c.Folio),
                "type" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Type) : query.OrderByDescending(c => c.Type),
                "status" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Status) : query.OrderByDescending(c => c.Status),
                _ => null
            };


            Expression<Func<ProductEvent, bool>> filterCondition = c =>
                ((withTrashed == true && c.DeletedAt != null) ||
                 (withTrashed == false && c.DeletedAt == null) ||
                 withTrashed == null) &&
                ((string.IsNullOrEmpty(term) || c.Folio.Contains(term)));



            orderBy = value;
            var productevents = _unitOfWork.ProductEvent.PaginateGetAsync(
              parameters: parameters,
              filter: filterCondition,
              orderBy: orderBy,
              relationships: "Employee,ProductEventDetails",
              isTracking: false,
              withTrashed: withTrashed == null ? true : Convert.ToBoolean(withTrashed)
          );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(productevents, parameters.PageNumber);

            return paginationResponse;

        }

        public async Task<ProductEvent> AddProductEventAsync(ProductEvent productEvent)
        {
            // Generar el folio correcto
            productEvent.Folio = await GenerateFolioAsync(productEvent.Type);

            // Validar el modelo después de modificar el folio
            ValidateProductEvent(productEvent);

            var createProductEvent = _unitOfWork.ProductEvent.Create(productEvent);
            await _unitOfWork.Save();

            return productEvent;
        }

        public async Task<ProductEvent> UpdateProductEventAsync(int id, ProductEvent productEvent)
        {
            // Generar el folio correcto
            productEvent.Folio = await GenerateFolioAsync(productEvent.Type);

            // Validar el modelo después de modificar el folio
            ValidateProductEvent(productEvent);

            _unitOfWork.ProductEvent.Update(productEvent);
            await _unitOfWork.Save();
            return productEvent;
        }
        public async Task<ProductEvent> DeleteProductEventAsync(int id)
        {
            var productevent = await _unitOfWork.ProductEvent.Find(id);

            productevent.DeletedAt = DateTime.UtcNow;
            _unitOfWork.ProductEvent.Update(productevent);
            await _unitOfWork.Save();
            return productevent;
        }

        private async Task<string> GenerateFolioAsync(string type)
        {
            // Determinar el prefijo adecuado
            string prefix = type switch
            {
                "Entrada" => "E-",
                "Salida" => "S-",
                "Resguardo" => "R-",
                _ => throw new ArgumentException("Tipo no válido.")
            };


            var lastProductEvent = (await _unitOfWork.ProductEvent.Get(
               filter: pe => pe.Type == type,
               orderBy:pe => pe.OrderByDescending(pe => pe.Folio),
               isTracking:false
               )).FirstOrDefault();

            int nextNumber = 1;
            if (lastProductEvent != null)
            {
                // Separar el folio en sus componentes
                var regex = new Regex(@"^(E|S|R)-(\d+)-\d+$");
                var match = regex.Match(lastProductEvent.Folio);
                if (match.Success)
                {
                    nextNumber = int.Parse(match.Groups[2].Value) + 1;
                }
            }

            // Añadir marca de tiempo UNIX
            var unixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            // Construir el nuevo folio
            return $"{prefix}{nextNumber:D3}-{unixTimestamp}";
        }

        private void ValidateProductEvent(ProductEvent productEvent)
        {
            // Validación personalizada, lanza una excepción si no es válido
            var regex = new Regex(@"^(E|S|R)-\d{1,7}-\d{10}$");
            if (!regex.IsMatch(productEvent.Folio))
            {
                throw new ArgumentException("El formato debe ser 'E-', 'S-' o 'R-' seguido de un número (1 a 7 dígitos) y una fecha en formato UNIX.");
            }
        }
    }
}
