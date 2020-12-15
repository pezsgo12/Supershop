using SuperShop.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperShop.Bll
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
    }
}