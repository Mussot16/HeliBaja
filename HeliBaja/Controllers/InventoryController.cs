using Business.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HeliBaja.Controllers
{
    public class InventoryController : ApiController
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IHttpActionResult GetInventoriesByToolName(string toolName)
        {
            var inventories = _inventoryService.GetInventoriesByToolName(toolName);
            return Ok(inventories);
        }

        [HttpPut]
        public IHttpActionResult UpdateInventoryQuantity(int inventoryId, int newQuantity)
        {
            var result = _inventoryService.UpdateInventoryQuantity(inventoryId, newQuantity);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        public IHttpActionResult GetAllInventory()
        {
            var inventories = _inventoryService.GetAllInventory();
            return Ok(inventories);
        }

        [HttpGet]
        public IHttpActionResult GetAvailableInventory()
        {
            var inventories = _inventoryService.GetAvailableInventory();
            return Ok(inventories);
        }

        [HttpGet]
        public IHttpActionResult GetUnavailableInventory()
        {
            var inventories = _inventoryService.GetUnavailableInventory();
            return Ok(inventories);
        }

        [HttpGet]
        public IHttpActionResult GetInventoryByTool(string toolName)
        {
            var inventories = _inventoryService.GetInventoryByTool(toolName);
            return Ok(inventories);
        }

        [HttpGet]
        public IHttpActionResult GetInventoryByDate(DateTime date)
        {
            var inventories = _inventoryService.GetInventoryByDate(date);
            return Ok(inventories);
        }

        [HttpGet]
        public IHttpActionResult GetInventoryByDateRange(DateTime startDate, DateTime endDate)
        {
            var inventories = _inventoryService.GetInventoryByDateRange(startDate, endDate);
            return Ok(inventories);
        }

        [HttpGet]
        public IHttpActionResult GetAdminInventory()
        {
            var inventories = _inventoryService.GetAdminInventory();
            return Ok(inventories);
        }

        [HttpPut]
        public IHttpActionResult UpdateAdminInventory(Inventory item)
        {
            var result = _inventoryService.UpdateAdminInventory(item);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpPost]
        public IHttpActionResult AddAdminInventory(Inventory item)
        {
            var result = _inventoryService.AddAdminInventory(item);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpGet]
        public IHttpActionResult GetAdminInventoryById(int itemId)
        {
            var inventory = _inventoryService.GetAdminInventoryById(itemId);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }

        [HttpDelete]
        public IHttpActionResult DeleteAdminInventory(int itemId)
        {
            var result = _inventoryService.DeleteAdminInventory(itemId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpPost]
        public IHttpActionResult AddInventory(Inventory inventory)
        {
            var inventoryId = _inventoryService.AddInventory(inventory);
            return Ok(inventoryId);
        }

        [HttpPut]
        public IHttpActionResult UpdateInventory(Inventory inventory)
        {
            var result = _inventoryService.UpdateInventory(inventory);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public IHttpActionResult DeleteInventory(int inventoryId)
        {
            var result = _inventoryService.DeleteInventory(inventoryId);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}