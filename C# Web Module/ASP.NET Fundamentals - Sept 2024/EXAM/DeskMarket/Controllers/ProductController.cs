using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using System.Security.Policy;
using static DeskMarket.ApplicationConstants.EntityValidationConstants.Product;

namespace DeskMarket.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;

        public ProductController(ApplicationDbContext _dbContext, UserManager<IdentityUser> _userManager)
        {
            this.dbContext = _dbContext;
            this.userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            string userId = GetUserId();

            List<ProductIndexViewModel> products = await dbContext
                .Products
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductIndexViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    HasBought = dbContext.ProductsClients.Any(pc => pc.ClientId == userId && pc.ProductId == p.Id),
                    IsSeller = p.SellerId == userId
                })
                .AsNoTracking()
                .ToListAsync();

            return View(products);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ProductAddInputModel model = new ProductAddInputModel();
            model.Categories = await dbContext.Categories.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddInputModel model)
        {
            string userId = GetUserId();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid validation");

                model.Categories = await dbContext.Categories.ToListAsync();
                return View(model);
            }

            DateTime addedOn;
            bool isDateValid = DateTime.TryParseExact(model.AddedOn, DateAddedOnFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out addedOn);
            if (!isDateValid)
            {
                ModelState.AddModelError(nameof(model.AddedOn), $"Invalid AddedOn date! Format should be: {DateAddedOnFormat}");

                model.Categories = await dbContext.Categories.ToListAsync();
                return View(model);
            }

            // If any of the validations above return false (if there is any model validation errors),
            //, when the View(model) is returned, the Save button is moved to the footer, I guess it is some bootstrap error
            //I haven't made changes to the Add.cshtml, I downloaded the skeleton and this bug is from the skeleton


            Product productToAdd = new Product()
            {
                ProductName = model.ProductName,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                SellerId = userId,
                AddedOn = addedOn,
                CategoryId = model.CategoryId
            };

            await dbContext.Products.AddAsync(productToAdd);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            string userId = GetUserId();

            Product? productToCheck = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (productToCheck != null && productToCheck.SellerId != userId)
            {
                return Unauthorized();
            }

            List<Category> categories = await dbContext.Categories.ToListAsync();

            ProductEditViewModel? productToView = await dbContext
                .Products
                .Where(p => p.Id == Id)
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductEditViewModel()
                {
                    ProductName = p.ProductName,
                    Price = p.Price.ToString(),
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    AddedOn = p.AddedOn.ToString(DateAddedOnFormat),
                    CategoryId = p.CategoryId,
                    Categories = categories,
                    SellerId = p.SellerId
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return View(productToView);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model, int Id)
        {
            string userId = GetUserId();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid validation");

                model.Categories = await dbContext.Categories.ToListAsync();
                return View(model);
            }

            DateTime addedOn;
            bool isDateValid = DateTime.TryParseExact(model.AddedOn, DateAddedOnFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out addedOn);
            if (!isDateValid)
            {
                ModelState.AddModelError(nameof(model.AddedOn), $"Invalid AddedOn date! Format should be: {DateAddedOnFormat}");

                model.Categories = await dbContext.Categories.ToListAsync();
                return View(model);
            }

            Product? productToEdit = await dbContext.Products
                .Where(p => p.Id == Id)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (productToEdit != null)
            {
                if (productToEdit.SellerId != userId)
                {
                    return Unauthorized();
                }

                decimal editedPrice = decimal.Parse(model.Price);

                productToEdit.ProductName = model.ProductName;
                productToEdit.Description = model.Description;
                productToEdit.ImageUrl = model.ImageUrl;
                productToEdit.Price = editedPrice;
                productToEdit.AddedOn = addedOn;
                productToEdit.CategoryId = model.CategoryId;
                productToEdit.SellerId = model.SellerId; // could be unnecessary

                await dbContext.SaveChangesAsync();
            } else
            {
                throw new ArgumentException("Invalid Id!");
            }

            return RedirectToAction(nameof(Details), new { Id });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string userId = GetUserId();

            IEnumerable<ProductCartViewModel> productsOfClient = await dbContext
                .ProductsClients
                .Where(pc => pc.ClientId == userId)
                .Where(pc => pc.Product.IsDeleted == false)
                .Include(pc => pc.Product)
                .Select(pc => new ProductCartViewModel()
                {
                    Id = pc.ProductId,
                    ProductName = pc.Product.ProductName,
                    ImageUrl = pc.Product.ImageUrl,
                    Price = pc.Product.Price
                })
                .ToListAsync();

            return View(productsOfClient);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            string userId = GetUserId();

            Product? productToPair = await dbContext
                .Products
                .Where(p => p.Id == id)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (productToPair == null)
            {
                throw new ArgumentException("Invalid Product");
            }

            bool isProductAlreadyAddedToCart = await dbContext.ProductsClients.AnyAsync(pc => pc.ProductId == id);
            if (isProductAlreadyAddedToCart)
            {
                return RedirectToAction(nameof(Index));
            }

            ProductClient productClientToAdd = new ProductClient()
            {
                ClientId = userId,
                ProductId = id,
                Product = productToPair
            };

            productToPair.ProductsClients.Add(productClientToAdd);
            await dbContext.ProductsClients.AddAsync(productClientToAdd);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int Id)
        {
            string userId = GetUserId();

            Product? productToRemoveFromCart = await dbContext
                .Products
                .Where(p => p.Id == Id)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (productToRemoveFromCart == null)
            {
                return BadRequest();
            }

            ProductClient? productClientToRemove = await dbContext
                .ProductsClients
                .Where(pc => pc.ProductId == Id && pc.ClientId == userId)
                .FirstOrDefaultAsync();

            if (productClientToRemove == null)
            {
                throw new ArgumentException("Invalid Pair");
            }

            productToRemoveFromCart.ProductsClients.Remove(productClientToRemove);
            dbContext.ProductsClients.Remove(productClientToRemove);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            string userId = GetUserId();

            ProductDetailsViewModel? model = await dbContext
                .Products
                .Where(p => p.Id == Id)
                .Where(p => p.IsDeleted == false)
                .AsNoTracking()
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    AddedOn = p.AddedOn.ToString(DateAddedOnFormat),
                    Seller = p.Seller.UserName,
                    HasBought = dbContext.ProductsClients.Any(pc => pc.ClientId == userId && pc.ProductId == p.Id)
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            ProductDeleteViewModel? gameToDeleteViewModel = await dbContext
                .Products
                .Where(p => p.Id == Id)
                .Where(p => p.IsDeleted == false)
                .Select(p => new ProductDeleteViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Seller = p.Seller.UserName,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            return View(gameToDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductDeleteViewModel model)
        {
            int productId = model.Id;

            Product? productToDelete = await dbContext
                .Products
                .Where(p => p.Id == productId)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefaultAsync();

            if (productToDelete != null)
            {
                productToDelete.IsDeleted = true;
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

    }
}
