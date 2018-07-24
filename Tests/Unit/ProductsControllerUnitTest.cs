using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prodi;
using prodi.Controllers;
using prodi.Models;
using Xunit;

namespace Tests
{
    public class ProductsControllerUnitTests
    {
        [Fact]
        public async Task Get_Returns_AllProductsAsync()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("Get_Returns_AllProducts")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApiContext(options))
            {
                context.Products.Add(new Product { Description = "Description 1", Model = "Model 1", Brand = "Brand 1" });
                context.Products.Add(new Product { Description = "Description 2", Model = "Model 2", Brand = "Brand 2" });
                context.Products.Add(new Product { Description = "Description 3", Model = "Model 3", Brand = "Brand 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApiContext(options))
            {
                var controller = new ProductsController(context);
                var result = await controller.Get();

                Assert.IsType<OkObjectResult>(result);

                // TODO: Assert 3 objects in array
            }
        }

        [Fact]
        public async Task GetById_GivenValidId_Returns_ProductAsync()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("GetById_GivenValidId_Returns_Product")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApiContext(options))
            {
                context.Products.Add(new Product { Id = "123", Description = "Description 1", Model = "Model 1", Brand = "Brand 1" });
                context.Products.Add(new Product { Description = "Description 2", Model = "Model 2", Brand = "Brand 2" });
                context.Products.Add(new Product { Description = "Description 3", Model = "Model 3", Brand = "Brand 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApiContext(options))
            {
                var controller = new ProductsController(context);
                var result = await controller.GetById("123");

                Assert.IsType<OkObjectResult>(result);

                // TODO: Assert 1 object in array
            }
        }

        [Fact]
        public async Task GetById_GivenInvalidId_Returns_NotFoundAsync()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("GetById_GivenInvalidId_Returns_NotFound")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApiContext(options))
            {
                context.Products.Add(new Product { Description = "Description 1", Model = "Model 1", Brand = "Brand 1" });
                context.Products.Add(new Product { Description = "Description 2", Model = "Model 2", Brand = "Brand 2" });
                context.Products.Add(new Product { Description = "Description 3", Model = "Model 3", Brand = "Brand 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApiContext(options))
            {
                var controller = new ProductsController(context);
                var result = await controller.GetById("invalid id");

                Assert.IsType<NotFoundResult>(result);
            }
        }

        [Fact]
        public async Task Post_AddsNewProductAsync()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("Post_AddsNewProduct")
                .Options;

            // Use a clean instance of the context to run the test
            using (var context = new ApiContext(options))
            {
                var controller = new ProductsController(context);
                var result = await controller.Post(new Product { Description = "Description 1", Model = "Model 1", Brand = "Brand 1" });

                Assert.IsType<NoContentResult>(result);

                // TODO: Assert only 1 object in array
            }
        }

        [Fact]
        public async Task Put_GivenValidId_UpdatesExistingProductAsync()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("Put_GivenValidId_UpdatesExistingProduct")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApiContext(options))
            {
                context.Products.Add(new Product { Id = "123", Description = "Description 1", Model = "Model 1", Brand = "Brand 1" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApiContext(options))
            {
                var controller = new ProductsController(context);
                var result = await controller.Put("123", new Product { Description = "New description"});

                Assert.IsType<NoContentResult>(result);

                // TODO: Assert description has been updated
            }
        }

        [Fact]
        public async Task Delete_GivenValidId_DeletesExistingProductAsync()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("Delete_GivenValidId_DeletesExistingProduct")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ApiContext(options))
            {
                context.Products.Add(new Product { Id = "123", Description = "Description 1", Model = "Model 1", Brand = "Brand 1" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ApiContext(options))
            {
                var controller = new ProductsController(context);
                var result = await controller.Delete("123");

                Assert.IsType<NoContentResult>(result);

                // TODO: Assert no objects in array
            }
        }
    }
}