using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    /// <summary>
    /// 物料庫存
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// 索引序
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 物料ID
        /// </summary>
        public int MaterialID { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// 建立者
        /// </summary>
        public int Creater { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreatDate { get; set; }
        /// <summary>
        /// 最後編輯者
        /// </summary>
        public int LastEditor { get; set; }
        /// <summary>
        /// 最後編輯時間
        /// </summary>
        public DateTime LastUpdate { get; set; }
    }
}
