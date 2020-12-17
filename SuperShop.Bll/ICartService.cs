using SuperShop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperShop.Bll
{
    public interface ICartService
    {
        Task AddAsync(int productId, int count);
        Task<Order> CreateOrderAsync();
        Task EmptyCartAsync();
        Task<IReadOnlyDictionary<Product, int>> GetItemsAsync();
    }
}