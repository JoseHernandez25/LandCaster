using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using LandCaster.Entities.Specfications;
using LandCaster.Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LandCaster.BLL.Logic
{
    public class InventoryLogic : IInventoryLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public InventoryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<PaginationResponse<Inventory>> GetInventoryAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Inventory>, IOrderedQueryable<Inventory>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");

            Func<IQueryable<Inventory>, IOrderedQueryable<Inventory>>? value = orderByField switch
            {
                "stock" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Stock) : query.OrderByDescending(c => c.Stock),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                "maximumstock" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.MaximumStock) : query.OrderByDescending(c => c.MaximumStock),
                "minimumstock" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.MinimumStock) : query.OrderByDescending(c => c.MinimumStock),
                "products" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Product.Name) : query.OrderByDescending(c => c.Product.Name),
                "currencies" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Factory.Name) : query.OrderByDescending(c => c.Factory.Name),
                _ => null
            };

            orderBy = value;
            var inventories = _unitOfWork.Inventory.PaginateGetAsync(
                parameters: parameters,
                //filter: c =>
                //    (string.IsNullOrEmpty(term) || c.Stock.Contains(term)),
                orderBy: orderBy,
                relationships: "Product,Factory",
                isTracking: false
            );

            var paginationResponse = PaginationHelper.CreatePaginationResponse(inventories, parameters.PageNumber);

            return paginationResponse;
        }

        public async Task<Inventory> AddInventoryAsync(Inventory inventory)
        {

            var product = await _unitOfWork.Product.Fisrt(
                filter: p => p.Id == inventory.ProductId, // Filtrar por ID del producto
                properties: "Inventories" // Incluir inventarios
            );

            // Verificar si el producto ya existe en la fábrica
            if (product.Inventories.Any(inv => inv.FactoryId == inventory.FactoryId))
            {
                throw new ArgumentException("El producto ya existe en esta fábrica.");
            }

            // Crear el inventario si no existe en la fábrica
            var createdInventory = _unitOfWork.Inventory.Create(inventory);
            await _unitOfWork.Save();


            return inventory;
        }
        public async Task<Inventory> UpdateInventoryAsync(int id, Inventory inventory)
        {
            _unitOfWork.Inventory.Update(inventory);
            await _unitOfWork.Save();
            return inventory;
        }

        public async Task<Inventory> DeleteInventoryAsync(int id)
        {
            var inventory = await _unitOfWork.Inventory.Find(id);

            inventory.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Inventory.Update(inventory);
            await _unitOfWork.Save();
            return inventory;
        }

        public async Task<IEnumerable<Product>> GetProductAsync()
        {
            var products = await _unitOfWork.Product.Get(
                filter: null,
                orderBy: null,
                properties: "Inventories", 
                isTracking: true
            );
            return products;
        }
        public async Task<Inventory> getInvetoryOfProduct(string code)
        {
            // Buscar el producto por su código incluyendo los inventarios
            var product = await _unitOfWork.Product.Fisrt(
                filter: (p => p.Code.Contains(code)),//filtro de codigo donde el codigo de un producto coincide

                properties: "Inventories"//relaciones para usar otras tablas
                );

            var inventory = product.Inventories.Where(inv => inv.FactoryId == 1).FirstOrDefault();//consulta de el inventario donde fabrica sea 1

            return inventory;


        }


    }
}

