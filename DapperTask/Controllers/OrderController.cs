using DapperTask.Models;
using DapperTask.Repository;
using DapperTask.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DapperTask.Controllers
{
    [Route("api/Torder")]
    [ApiController]

    public class OrderController : Controller
    {
            private readonly IOrderRepository _orderRepo;
            public OrderController(IOrderRepository _orderRepo)
            {
                this._orderRepo = _orderRepo;
            }
            [HttpGet]
            public async Task<IActionResult> GetOrders()
            {
                try
                {
                    var orders = await _orderRepo.GetTorder();
                    return Ok(orders);
                }
                catch (Exception ex)
                {
                    //log error
                    return StatusCode(500, ex.Message);
                }
            }
            [HttpGet("{Id}")]
            public async Task<IActionResult> GetOrderbyId(int Id)
            {
                try
                {
                    var order = await _orderRepo.GetOrder(Id);
                    return Ok(order);
                }
                catch (Exception ex)
                {
                    //log error
                    return StatusCode(500, ex.Message);
                }
            }

            [HttpPost]
            public async Task<IActionResult> CreateOrder(Order order)
            {
                try
                {
                    var result = await _orderRepo.CreateOrder(order);

                    if (result == 0)
                    {
                        return StatusCode(409, "The request could not be processed because of conflict in the request");
                    }
                    else
                    {
                        return StatusCode(200, string.Format("Record Inserted Successfuly with compnay Id {0}", result));
                    }
                }
                catch (Exception ex)
                {
                    //log error
                    return StatusCode(500, ex.Message);
                }
            }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            try
            {
                var result = await _orderRepo.UpdateOrder(order);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Updated Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteorderAsync(int id)
        {
            try
            {
                var result = await _orderRepo.DeleteOrder(id);
                if (result == 0)
                {
                    return StatusCode(409, "The request could not be processed because of conflict in the request");
                }
                else
                {
                    return StatusCode(200, string.Format("Record Deleted Successfuly"));
                }
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }


    }
}

