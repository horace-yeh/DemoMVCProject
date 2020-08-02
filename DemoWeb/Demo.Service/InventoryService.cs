using Demo.Data.Models;
using Demo.Data.ViewModels;
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
        private IMaterialRepository materialRepository;
        private IUserRepository userRepository;

        public InventoryService()
        {
            this.inventoryRepository = new InventoryRepository();
            this.materialRepository = new MaterialRepository();
            this.userRepository = new UserRepository();
        }

        public IList<Inventory> GetAll()
        {
            return this.inventoryRepository.GetAll();
        }

        public IList<InventoryInfo> GetAllHaveInfo()
        {
            var inventoryList = this.GetAll();
            var userList = this.userRepository.GetAll();
            var materialList = this.materialRepository.GetAll();
            var data = from t1 in inventoryList
                       join t2 in userList on t1.Creater equals t2.ID
                       join t3 in userList on t1.LastEditor equals t3.ID
                       join t4 in materialList on t1.MaterialID equals t4.ID
                       select new InventoryInfo
                       {
                           ID = t1.ID,
                           MaterialID = t1.MaterialID,
                           Quantity = t1.Quantity,
                           MaterialName = t4.Name,
                           MaterialNo = t4.No,
                           Creater = t1.Creater,
                           CreatDate = t1.CreatDate,
                           LastEditor = t1.LastEditor,
                           LastUpdate = t1.LastUpdate,
                           CreaterName = t2.Name,
                           LastEditorName = t3.Name
                       };
            return data.ToList();
        }

        public void StockIn(Inventory instance)
        {
            if (this.inventoryRepository.HaveInventory(instance.MaterialID))
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
