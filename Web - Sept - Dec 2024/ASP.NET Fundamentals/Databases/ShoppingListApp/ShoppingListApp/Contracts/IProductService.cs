using ShoppingListApp.Models;

namespace ShoppingListApp.Contracts
{
    public interface IProductService
    {
        Task <IEnumerable<ProductViewModel>> GetAllAsync();

        Task <ProductViewModel> GetByIdAsync (int id);

        Task AddProductAsync(ProductViewModel model);

        Task EditProductAsync(ProductViewModel model);

        Task DeleteProductAsync(int id);
    }
}
