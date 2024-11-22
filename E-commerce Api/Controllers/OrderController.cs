using AutoMapper;
using Domain.Entities;
using Domain.Repos;
using E_commerce_Api.Dtos.category;
using E_commerce_Api.Dtos.order;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Order>> GetAllAsync() =>
             await _unitOfWork.OrderRepo.GetAllAsync(isTracking: false);


        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Order>> AddAsync(Add_UpdateOrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var order = new Order();
             _mapper.Map(orderDto, order);
            if (order.Status == null)
            {
                order.Status = "Approved";
            }
            await _unitOfWork.OrderRepo.AddAsync(order);
            return Ok();
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateAsync(int id ,Add_UpdateOrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingOrder = await _unitOfWork.OrderRepo.GetByIdAsync(id);
            if (existingOrder == null)
            {
                return NotFound();
            }

            _mapper.Map(orderDto, existingOrder);
            await _unitOfWork.OrderRepo.UpdateAsync(existingOrder);
            return Ok();

        }


        [HttpDelete("Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var order = await _unitOfWork.OrderRepo.GetByIdAsync(id);
            if (order == null)
                return NotFound();

            await _unitOfWork.OrderRepo.DeleteAsync(order);
            return Ok();
        }

        [HttpGet("GetOrdersByStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(string status) =>
            await _unitOfWork.OrderRepo.GetOrdersByStatusAsync(status);

    }
}


