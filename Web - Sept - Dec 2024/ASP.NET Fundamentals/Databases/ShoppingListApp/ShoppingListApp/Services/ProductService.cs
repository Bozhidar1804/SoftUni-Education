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

        public async Task DeleteProductAsync(int id)
        {
            var entity = await context.Products.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid Product");
            }


            context.Products.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task EditProductAsync(ProductViewModel model)
        {
            var entity = await context.Products.FindAsync(model.Id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid product");
            }

            entity.Name = model.Name;
            await context.SaveChangesAsync();
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var entity = await context.Products.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid product");
            }

            return new ProductViewModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
