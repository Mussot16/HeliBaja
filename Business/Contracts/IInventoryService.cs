using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IInventoryService
    {
        List<Inventory> GetInventoriesByToolName(string toolName);
        bool UpdateInventoryQuantity(int inventoryId, int newQuantity);
        List<Inventory> GetAllInventory();
        List<Inventory> GetAvailableInventory();
        List<Inventory> GetUnavailableInventory();
        List<Inventory> GetInventoryByTool(string toolName);
        List<Inventory> GetInventoryByDate(DateTime date);
        List<Inventory> GetInventoryByDateRange(DateTime startDate, DateTime endDate);
        List<Inventory> GetAdminInventory();
        bool UpdateAdminInventory(Inventory item);
        bool AddAdminInventory(Inventory item);
        Inventory GetAdminInventoryById(int itemId);
        bool DeleteAdminInventory(int itemId);
        int AddInventory(Inventory inventory);
        bool UpdateInventory(Inventory inventory);
        bool DeleteInventory(int inventoryId);
    }
}