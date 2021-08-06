using AcademyC.Week4.Test.Core.Models;
using AcademyC.Week4.Test.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyC.Week4.Test.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IBusinessLayer businessLayer;

        public OrderController(IBusinessLayer businessLayer)
        {
            this.businessLayer = businessLayer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.businessLayer.FetchOrders();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order Id.");

            var order = businessLayer.FetchClientById(id);

            if (order == null)
                return NotFound($"Order with ID: {id} is missing.");
            return Ok(order);
        }

        [HttpPost]
        public IActionResult Post(Order newOrder)
        {
            if (newOrder == null)
                return BadRequest("Invalid entry.");
            if (!businessLayer.CreateOrder(newOrder))
                return BadRequest("Cannot complete the operation");

            return CreatedAtAction(nameof(GetById), new { id = newOrder.ID }, newOrder);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Order editedOrder)
        {
            if (editedOrder == null)
                return BadRequest("Invalid entry.");
            if (id != editedOrder.ID)
                return BadRequest("Order IDs don't matching");
            if (!businessLayer.EditOrder(editedOrder))
                return BadRequest("Cannot complete the operation");
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");
            var result = businessLayer.DeleteOrderById(id);

            if (!result)
                return BadRequest("Cannot complete the operation");

            return Ok();
        }

    }
}
