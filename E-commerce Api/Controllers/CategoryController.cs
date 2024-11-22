using AutoMapper;
using Domain.Entities;
using Domain.Repos;
using E_commerce_Api.Dtos.category;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Category>> GetAllAsync() =>
             await _unitOfWork.CategoryRepo.GetAllAsync(isTracking : false);


        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> AddAsync(Add_UpdateCategoryDto categoryDto )
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = new Category()
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };

            await _unitOfWork.CategoryRepo.AddAsync(category);
            return Ok();
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAsync(int id ,Add_UpdateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            _mapper.Map(categoryDto, category);
            category.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.CategoryRepo.UpdateAsync(category);
            return Ok();

        }


        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepo.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            await _unitOfWork.CategoryRepo.DeleteAsync(category);
            return Ok();
        }


    }
}
