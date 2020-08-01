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
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        public bool CheckPassword(User instance)
        {
            return this.userRepository.GetAll().Any( x => x.Account.Equals(instance.Account) && x.Password.Equals(instance.Password));
        }

        public int GetIDByAccount(string account)
        {
            var temp = this.userRepository.GetAll().Where(x => x.Account.Equals(account)).FirstOrDefault();
            return temp.ID;
        }
    }
}
