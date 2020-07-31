using Demo.Data.Models;
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
    }
}
