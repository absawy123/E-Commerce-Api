using AutoMapper;
using Domain.Entities;
using Domain.Repos;
using E_commerce_Api.Dtos.product;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Product>> GetProductsAsync() =>
             await _unitOfWork.ProductRepo.GetAllAsync(p => !p.IsDeleted, isTracking:false);

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddAsync(Add_UpdateProductDto addProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product()
            {
                Name = addProductDto.Name,
                Description = addProductDto.Description,
                CategoryId = addProductDto.CategoryId,
                Price = addProductDto.Price,
            };
            var wwwRoot = _webHostEnvironment.ContentRootPath;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(addProductDto.Image.FileName);
            var filePath = Path.Combine(wwwRoot, "Images", fileName);

            // create directory
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(filePath);
            }
            // save photo in directory
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await addProductDto.Image.CopyToAsync(stream);
            }

            product.ImageUrl = fileName;
            await _unitOfWork.ProductRepo.AddAsync(product);
            return Ok();

        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAsync(int id ,Add_UpdateProductDto productDto )
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProduct = await _unitOfWork.ProductRepo.GetByIdAsync(id);
            if (existingProduct == null)
                return NotFound();

            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.CategoryId = productDto.CategoryId;
            existingProduct.UpdatedAt = DateTime.UtcNow;

            var wwwRoot = _webHostEnvironment.ContentRootPath;
            var oldFilePath = Path.Combine(wwwRoot, "Images", existingProduct.ImageUrl);
            if (System.IO.File.Exists(oldFilePath))
            {
                System.IO.File.Delete(oldFilePath);
            }

            var newfileName = Guid.NewGuid().ToString() + Path.GetExtension(productDto.Image.FileName);
            var newfilePath = Path.Combine(wwwRoot, "Images", newfileName);
            using (var stream = new FileStream(newfilePath, FileMode.Create))
            {
                productDto.Image.CopyTo(stream);
            }
            existingProduct.ImageUrl = newfileName;
            await _unitOfWork.ProductRepo.UpdateAsync(existingProduct);
            return Ok();
        }

        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var Product = await _unitOfWork.ProductRepo.GetByIdAsync(id);
            if (Product == null)
                return NotFound();

            Product.IsDeleted = true;
            await _unitOfWork.ProductRepo.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetTopExpensive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Product>> GetTopExpensiveProductsAsync(int count) =>
            await _unitOfWork.ProductRepo.GetTopExpensive(count);


    }
}
