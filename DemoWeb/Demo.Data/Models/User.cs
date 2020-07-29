using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Models
{
    /// <summary>
    /// 使用者
    /// </summary>
    public class User
    {
        /// <summary>
        /// 索引序
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }
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
