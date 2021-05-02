using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace PizzaBoxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListController : Controller
    {
        
            private readonly PizzaBox.Data.IRepository repo;
            public OrderListController(IRepository repo)
            {
                this.repo = repo;
            }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MOrder> Get()
        {
            try
            {
                var orders = repo.GetAllOrders();
                var json = JsonConvert.SerializeObject(orders);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MOrder> GetById([FromRoute] int id)
        {
            try
             {
                var x = repo.GetOrderById(id);
                if (x == null)
                 {
                    return NotFound($"The item with id {id} was not found in the database.");
                 }
                return Ok(x);
             }
             catch (Exception e)
             {
                return StatusCode(400, e.Message);
             }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Post([FromBody] MOrder order)
        {
            try
            {
                if (order == null)
                    return BadRequest("Data is invalid or null");
                repo.AddOrder(order);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put([FromBody] MOrder order)
        {
            try
            {

                
                if (order == null)
                    return BadRequest("Data is invalid or null");
                repo.UpdateOrder(order);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                if (repo.GetOrderById(id) == null)
                    return BadRequest("Item does not exist");
                repo.DeleteOrder(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }


    }
}
