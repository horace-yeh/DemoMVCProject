using Demo.Data.Models;
using Demo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilHelper;

namespace Demo.Repository
{
    public class UserRepository : IUserRepository
    {
        private DapperTool dapperTool;

        public UserRepository()
        {
            this.dapperTool = new DapperTool();
        }

        public void Create(User instance)
        {
            throw new NotImplementedException();
        }

        public void Delete(User instance)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User Get(int primaryID)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll()
        {
            var sql = @"SELECT [ID]
                    ,[Name]
                    ,[Account]
                    ,[Password]
                    ,[Creater]
                    ,[CreatDate]
                    ,[LastEditor]
                    ,[LastUpdate]
                    FROM [dbo].[User]";
            var data = dapperTool.DapperQuery<User>(sql, null);
            return data;
        }

        public void Update(User instance)
        {
            throw new NotImplementedException();
        }
    }
}
