using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Interface
{
    public interface IMaterialService
    {
        /// <summary>
        /// 新增物料
        /// </summary>
        /// <param name="instance"></param>
        void Create(Material instance);

        /// <summary>
        /// 編輯物料
        /// </summary>
        /// <param name="instance"></param>
        void Update(Material instance);

        /// <summary>
        /// 刪除物料
        /// </summary>
        /// <param name="instance"></param>
        void Delete(Material instance);

        /// <summary>
        /// 取得所有物料資訊
        /// </summary>
        /// <returns></returns>
        IList<Material> GetAll();
        
        /// <summary>
        /// 依照ID取得物料
        /// </summary>
        /// <param name="primaryID"></param>
        /// <returns></returns>
        Material Get(int primaryID);

    }
}
