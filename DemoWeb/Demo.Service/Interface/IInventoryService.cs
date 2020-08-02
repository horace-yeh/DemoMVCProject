using Demo.Data.Models;
using Demo.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Interface
{
    public interface IInventoryService
    {
        /// <summary>
        /// 物料入庫
        /// </summary>
        /// <param name="instance"></param>
        void StockIn(Inventory instance);

        /// <summary>
        /// 物料出庫
        /// </summary>
        /// <param name="instance"></param>
        void StockOut(Inventory instance);

        /// <summary>
        /// 取得所有庫存資料(包含物料名稱、人員資訊)
        /// </summary>
        /// <returns></returns>
        IList<InventoryInfo> GetAllHaveInfo();

        /// <summary>
        /// 取得所有庫存資料
        /// </summary>
        /// <returns></returns>
        IList<Inventory> GetAll();

    }
}
