using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.ProductDTO;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface IProductLogic
    {
        Task<PaginationResponse<Product>> GetProductAsync(PaginationDTO parameters);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(int id, Product product);
        Task<Product> DeleteProductAsync(int id);
        Task<List<Brand>> GetBrands();
        Task<Product> VerifyProduct(string code);
        //Task<Inventory> getInvetoryOfProduct(string code);

    }
}
