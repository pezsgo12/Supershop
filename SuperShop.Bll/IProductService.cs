using SuperShop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperShop.Bll
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAvailableProductsAsync(int? categoryId = default);
        Task<Product> CreateProductAsync(Product p);
        Task<Product> EditProductAsync(Product p);
        Task<Product> GetProductAsync(int productId);
        Task DeleteProductAsync(int productId);
    }
}