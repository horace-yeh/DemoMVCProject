using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Interface
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        /// <summary>
        /// 判斷是否有庫存資料
        /// </summary>
        /// <param name="MaterialID"></param>
        /// <returns></returns>
        bool HaveInventory(int MaterialID);
    }
}
