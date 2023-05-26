using Data.Contracts;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly HeliBajaDBContext _dbContext;

        public InventoryRepository(HeliBajaDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Inventory> GetInventoriesByToolName(string toolName)
        {
            return _dbContext.Inventories.Where(i => i.Name == toolName).ToList();
        }

        public bool UpdateInventoryQuantity(int inventoryId, int newQuantity)
        {
            var inventory = _dbContext.Inventories.Find(inventoryId);
            if (inventory == null)
            {
                return false;
            }
            inventory.Amount = newQuantity;
            _dbContext.SaveChanges();
            return true;
        }

        public List<Inventory> GetAllInventory()
        {
            return _dbContext.Inventories.ToList();
        }

        public List<Inventory> GetAvailableInventory()
        {
            return _dbContext.Inventories.Where(i => i.Available).ToList();
        }

        public List<Inventory> GetUnavailableInventory()
        {
            return _dbContext.Inventories.Where(i => !i.Available).ToList();
        }

        public List<Inventory> GetInventoryByTool(string toolName)
        {
            return _dbContext.Inventories.Where(i => i.Name.Contains(toolName)).ToList();
        }

        public List<Inventory> GetInventoryByDate(DateTime date)
        {
            return _dbContext.Inventories.Where(i => DbFunctions.TruncateTime(i.Date) == DbFunctions.TruncateTime(date)).ToList();
        }

        public List<Inventory> GetInventoryByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Inventories.Where(i => i.Date >= startDate && i.Date <= endDate).ToList();
        }

        public List<Inventory> GetAdminInventory()
        {
            return _dbContext.Inventories.Where(i => i.AdminInventory).ToList();
        }

        public bool UpdateAdminInventory(Inventory item)
        {
            if (!_dbContext.Inventories.Local.Any(i => i.Id_Inventory == item.Id_Inventory))
            {
                _dbContext.Inventories.Attach(item);
            }
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public bool AddAdminInventory(Inventory item)
        {
            _dbContext.Inventories.Add(item);
            _dbContext.SaveChanges();
            return true;
        }

        public Inventory GetAdminInventoryById(int itemId)
        {
            return _dbContext.Inventories.FirstOrDefault(i => i.Id_Inventory == itemId && i.AdminInventory);
        }

        public bool DeleteAdminInventory(int itemId)
        {
            var inventory = _dbContext.Inventories.FirstOrDefault(i => i.Id_Inventory == itemId && i.AdminInventory);
            if (inventory != null)
            {
                _dbContext.Inventories.Remove(inventory);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public int Add(Inventory entity)
        {
            _dbContext.Inventories.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id_Inventory;
        }

        public Inventory Get(int id)
        {
            return _dbContext.Inventories.FirstOrDefault(i => i.Id_Inventory == id);
        }

        public bool Update(Inventory entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var inventory = _dbContext.Inventories.FirstOrDefault(i => i.Id_Inventory == id);
            if (inventory != null)
            {
                _dbContext.Inventories.Remove(inventory);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}