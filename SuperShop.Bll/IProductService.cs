using SuperShop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperShop.Bll
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAvailableProductsAsync();
    }
}