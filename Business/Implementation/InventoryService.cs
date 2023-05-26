using Business.Contracts;
using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public List<Inventory> GetInventoriesByToolName(string toolName)
        {
            return _inventoryRepository.GetInventoriesByToolName(toolName);
        }

        public bool UpdateInventoryQuantity(int inventoryId, int newQuantity)
        {
            return _inventoryRepository.UpdateInventoryQuantity(inventoryId, newQuantity);
        }

        public List<Inventory> GetAllInventory()
        {
            return _inventoryRepository.GetAllInventory();
        }

        public List<Inventory> GetAvailableInventory()
        {
            return _inventoryRepository.GetAvailableInventory();
        }

        public List<Inventory> GetUnavailableInventory()
        {
            return _inventoryRepository.GetUnavailableInventory();
        }

        public List<Inventory> GetInventoryByTool(string toolName)
        {
            return _inventoryRepository.GetInventoryByTool(toolName);
        }

        public List<Inventory> GetInventoryByDate(DateTime date)
        {
            return _inventoryRepository.GetInventoryByDate(date);
        }

        public List<Inventory> GetInventoryByDateRange(DateTime startDate, DateTime endDate)
        {
            return _inventoryRepository.GetInventoryByDateRange(startDate, endDate);
        }

        public List<Inventory> GetAdminInventory()
        {
            return _inventoryRepository.GetAdminInventory();
        }

        public bool UpdateAdminInventory(Inventory item)
        {
            return _inventoryRepository.UpdateAdminInventory(item);
        }

        public bool AddAdminInventory(Inventory item)
        {
            return _inventoryRepository.AddAdminInventory(item);
        }

        public Inventory GetAdminInventoryById(int itemId)
        {
            return _inventoryRepository.GetAdminInventoryById(itemId);
        }

        public bool DeleteAdminInventory(int itemId)
        {
            return _inventoryRepository.DeleteAdminInventory(itemId);
        }

        public int AddInventory(Inventory inventory)
        {
            return _inventoryRepository.Add(inventory);
        }

        public bool UpdateInventory(Inventory inventory)
        {
            return _inventoryRepository.Update(inventory);
        }

        public bool DeleteInventory(int inventoryId)
        {
            return _inventoryRepository.Delete(inventoryId);
        }
    }
}