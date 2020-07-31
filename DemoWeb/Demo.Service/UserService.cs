using Demo.Data.Models;
using Demo.Repository;
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
        private UserRepository userRepository;

        public UserService()
        {
            this.userRepository = new UserRepository();
        }

        public bool CheckPassword(User instance)
        {
            var user = this.userRepository.GetAll()
                .Where( x => x.Account.Equals(instance.Account) 
                        && x.Password.Equals(instance.Password)
                      );
            if (user != null)
                return true;
            return false;
        }
    }
}
