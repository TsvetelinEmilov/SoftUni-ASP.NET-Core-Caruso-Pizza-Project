namespace CarusoPizza.Controllers
{
    using CarusoPizza.Infrastructure;
    using CarusoPizza.Models.Products;
    using CarusoPizza.Services.Products;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProductsController : Controller
    {
        private readonly IProductService products;

        public ProductsController(IProductService products) 
            => this.products = products;

        [Authorize]
        public IActionResult Add()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new ProductFormModel
            {
                Categories = this.products.ProductsCategories()
            });
        }
            
        [Authorize]
        [HttpPost]
        public IActionResult Add(ProductFormModel product)
        {
            if (!User.IsAdmin())
            {
                return BadRequest();
            }

            if (!this.products.CategoryExists(product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                product.Categories = this.products.ProductsCategories();

                return this.View(product);
            }

            this.products.Add(product.Name,
                product.Weight,
                product.Price,
                product.Description,
                product.ImageUrl,
                product.CategoryId);

            return this.RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult All([FromQuery]AllProductsQueryModel query)
        {
            var queryResult = this.products.All(
                query.SearchTerm,
                query.CurrentPage,
                AllProductsQueryModel.ProductsPerPage);

            query.TotalProducts = queryResult.TotalProducts;
            query.Products = queryResult.Products;

            return View(query);
        }
        [Authorize]
        public IActionResult Edit(int id)
        {
            var product = this.products.FindById(id);

            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new ProductFormModel
            {
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Weight = product.Weight,
                CategoryId = product.CategoryId,
                Categories = this.products.ProductsCategories()
            });

        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, ProductFormModel product)
        {
            if (!this.products.CategoryExists(product.CategoryId))
            {
                this.ModelState.AddModelError(nameof(product.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                product.Categories = this.products.ProductsCategories();

                return this.View(product);
            }

            if (!User.IsAdmin())
            {
                return BadRequest();
            }

            this.products.Edit(
                id,
                product.Name,
                product.Weight,
                product.Price,
                product.Description,
                product.ImageUrl,
                product.CategoryId);

            return RedirectToAction(nameof(All));

        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            if (!User.IsAdmin())
            {
                return BadRequest();
            }

            this.products.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Stop(int id)
        {
            if (!User.IsAdmin())
            {
                return BadRequest();
            }

            this.products.Stop(id);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public IActionResult Start(int id)
        {
            if (!User.IsAdmin())
            {
                return BadRequest();
            }

            this.products.Start(id);

            return RedirectToAction(nameof(All));
        }
    }
}
