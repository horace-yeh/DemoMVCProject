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
    public class MaterialService : IMaterialService
    {

        private IMaterialRepository materialRepository;
        private InventoryRepository inventoryRepository;

        public MaterialService()
        {
            this.materialRepository = new MaterialRepository();
            this.inventoryRepository = new InventoryRepository();
        }


        public void Create(Material instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            if (HaveSomeNo(instance))
            {
                throw new Exception(@"料號重覆");
            }

            this.materialRepository.Create(instance);
        }

        public void Delete(Material instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            if (MaterialHaveinventory(instance))
            {
                throw new Exception(@"該物料有庫存資訊無法刪除");
            }

            this.materialRepository.Delete(instance);
        }

        public Material Get(int primaryID)
        {
            return this.materialRepository.Get(primaryID);
        }

        public IList<Material> GetAll()
        {
            return this.materialRepository.GetAll();
        }

        public void Update(Material instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            if (HaveSomeNo(instance))
            {
                throw new Exception(@"料號重覆");
            }

            this.materialRepository.Update(instance);
        }

        /// <summary>
        /// 檢查料號唯一性
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        private bool HaveSomeNo(Material instance)
        {
            return this.materialRepository.GetAll().Any(x => x.Name.Equals(instance.Name));
        }

        /// <summary>
        /// 判斷是否有庫存資料
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        private bool MaterialHaveinventory(Material instance) 
        {
            return this.inventoryRepository.GetAll().Any(x => x.MaterialID.Equals(instance.ID));
        }


    }
}
