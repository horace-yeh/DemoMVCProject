using Demo.Data.Models;
using Demo.Repository;
using Demo.Repository.Interface;
using Demo.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service
{
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository inventoryRepository;

        public InventoryService()
        {
            this.inventoryRepository = new InventoryRepository();
        }

        public IList<Inventory> GetAll()
        {
            return this.inventoryRepository.GetAll();
        }

        public bool HaveInventory(int MaterialID)
        {
            return this.inventoryRepository.GetAll().Any(x => x.MaterialID.Equals(MaterialID));
        }

        public void StockIn(Inventory instance)
        {
            if (HaveInventory(instance.MaterialID))
            {
                var original = this.inventoryRepository.GetAll().Where(x => x.MaterialID.Equals(instance.MaterialID)).FirstOrDefault();
                original.Quantity += instance.Quantity;
                this.inventoryRepository.Update(original);
                return;
            }
            this.inventoryRepository.Create(instance);
        }

        public void StockOut(Inventory instance)
        {
            var original = this.inventoryRepository.GetAll().Where(x => x.MaterialID.Equals(instance.MaterialID)).FirstOrDefault();
            if (instance.Quantity > original.Quantity)
            {
                throw new Exception(@"出庫數量大於庫存數量");
            }
            original.Quantity -= instance.Quantity;
            this.inventoryRepository.Update(original);
        }
    }
}
