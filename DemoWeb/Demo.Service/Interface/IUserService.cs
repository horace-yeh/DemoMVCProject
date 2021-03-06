﻿using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// 驗證帳號密碼
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool CheckPassword(User instance);

        /// <summary>
        /// 依帳號取得使用者ID
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        int GetIDByAccount(string account);

        IList<User> GetAll();
    }
}
