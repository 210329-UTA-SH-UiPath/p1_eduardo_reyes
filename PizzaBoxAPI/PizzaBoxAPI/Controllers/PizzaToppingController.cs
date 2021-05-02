using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace PizzaBoxAPI.Controllers
{
    public class PizzaToppingController : Controller
    {
        private readonly IRepository repo;
        public PizzaToppingController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Toppings> Get()
        {
            try
            {
                return Ok(repo.GetPizzaToppings());
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Toppings> GetById([FromRoute] int id)
        {
            try
            {
                var x = repo.GetPizzaToppingsById(id);
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
        public IActionResult Post([FromBody] Toppings topping)
        {
            try
            {
                if (topping == null)
                    return BadRequest("Data is invalid or null");

                //order.Cost = 0;

                repo.AddToppings(topping);
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
        public IActionResult Put([FromBody] Toppings topping)
        {
            try
            {


                if (topping == null)
                    return BadRequest("Data is invalid or null");
                repo.UpdatePizzaTopping(topping);
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
                if (repo.GetPizzaToppingById(id) == null)
                    return BadRequest("Item does not exist");
                repo.DeletePizzaToppingById(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
