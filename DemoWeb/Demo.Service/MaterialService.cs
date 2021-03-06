﻿using Demo.Data.Models;
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
    public class MaterialService : IMaterialService
    {

        private IMaterialRepository materialRepository;
        private IUserRepository userRepository;
        private IInventoryRepository inventoryRepository;


        public MaterialService()
        {
            this.materialRepository = new MaterialRepository();
            this.userRepository = new UserRepository();
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

            if (this.inventoryRepository.HaveInventory(instance.ID))
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

        public IList<MaterialInfo> GetAllHaveInfo()
        {
            var materialList = this.GetAll();
            var userList = this.userRepository.GetAll();
            var data = from t1 in materialList
                        join t2 in userList on t1.Creater equals t2.ID
                        join t3 in userList on t1.LastEditor equals t3.ID
                        select new MaterialInfo
                        {
                            ID = t1.ID,
                            Name = t1.Name,
                            No = t1.No,
                            Creater = t1.Creater,
                            CreatDate = t1.CreatDate,
                            LastEditor = t1.LastEditor,
                            LastUpdate = t1.LastUpdate,
                            CreaterName = t2.Name,
                            LastEditorName = t3.Name
                        };
            return data.ToList();
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
            return this.materialRepository.GetAll().Any(x => x.No.Equals(instance.No) && x.ID != instance.ID);
        }
    }
}
