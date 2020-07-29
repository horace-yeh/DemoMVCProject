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
            var sql = @"INSERT INTO [dbo].[User]
                        ([Name],[Account],[Password],[Creater],[LastEditor])
                        VALUES
                        (@Name,@Account,@Password,@Creater,@LastEditor)";
            var pms = new
            {
                Name = dapperTool.ToNVarchar(instance.Name,50),
                Account = dapperTool.ToVarchar(instance.Account,250),
                Password = dapperTool.ToVarchar(instance.Password,250),
                Creater = instance.Creater,
                LastEditor = instance.LastEditor
            };
            var data = dapperTool.DapperNonQuery(sql, pms);
        }

        public void Delete(User instance)
        {
            var sql = @"DELETE FROM [dbo].[User]
                         WHERE [ID] = @ID";
            var pms = new
            {
                ID = instance.ID
            };
            var data = dapperTool.DapperNonQuery(sql, pms);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User Get(int primaryID)
        {
            var sql = @"SELECT [ID]
                                ,[Name]
                                ,[Account]
                                ,[Password]
                                ,[Creater]
                                ,[CreatDate]
                                ,[LastEditor]
                                ,[LastUpdate]
                            FROM [dbo].[User]
                            WHERE [ID] = @ID";
            var pms = new
            {
                ID = primaryID
            };
            var data = dapperTool.DapperQuery<User>(sql, pms).FirstOrDefault();
            return data;
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
            var sql = @"UPDATE [dbo].[User]
                          SET [Name] = @Name
                             ,[Account] = @Account
                             ,[Password] = @Password
                             ,[LastEditor] = @LastEditor
                             ,[LastUpdate] = GETDATE()
                        WHERE [ID] = @ID";
            var pms = new 
            {
                ID = instance.ID,
                Name = dapperTool.ToNVarchar(instance.Name, 50),
                Account = dapperTool.ToVarchar(instance.Account, 250),
                Password = dapperTool.ToVarchar(instance.Password, 250),
                LastEditor = instance.LastEditor
            };
            var data = dapperTool.DapperNonQuery(sql, pms);
        }
    }
}
