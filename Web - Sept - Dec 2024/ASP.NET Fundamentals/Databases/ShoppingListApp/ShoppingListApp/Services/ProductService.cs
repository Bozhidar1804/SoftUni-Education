using Microsoft.EntityFrameworkCore;
using ShoppingListApp.Contracts;
using ShoppingListApp.Data;
using ShoppingListApp.Models;
using ShoppingListApp.Data.Models;

namespace ShoppingListApp.Services
{
    public class ProductService(ShoppingListDbContext context) : IProductService
    {
		public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
		{
            return await context.Products
				.AsNoTracking()
				.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
		}
		public async Task AddProductAsync(ProductViewModel model)
        {
            var entity = new Product()
            {
                Name = model.Name
            };

            await context.Products.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditProductAsync(ProductViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
