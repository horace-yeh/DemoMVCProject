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
    public class MaterialRepository : IMaterialRepository
    {
        private DapperTool dapperTool;

        public MaterialRepository()
        {
            this.dapperTool = new DapperTool();
        }

        public void Create(Material instance)
        {
            var sql = @"INSERT INTO [dbo].[Material]
                        ([Name]
                        ,[No]
                        ,[Creater]
                        ,[LastEditor])
                         VALUES
                        (@Name,@No,@Creater,@LastEditor)";
            var pms = new 
            {
                Name = this.dapperTool.ToNVarchar(instance.Name, 250),
                No = this.dapperTool.ToVarchar(instance.No, 250),
                Creater = instance.Creater,
                LastEditor = instance.LastEditor,
            };
            var data = this.dapperTool.DapperNonQuery(sql,pms);
        }

        public void Delete(Material instance)
        {
            var sql = @"DELETE FROM [dbo].[Material]
                        WHERE [ID] = @ID";
            var pms = new { ID = instance.ID};
            var data = this.dapperTool.DapperNonQuery(sql,pms);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Material Get(int primaryID)
        {
            var sql = @"SELECT [ID]
                                ,[Name]
                                ,[No]
                                ,[Creater]
                                ,[CreatDate]
                                ,[LastEditor]
                                ,[LastUpdate]
                            FROM [dbo].[Material]
                            WHERE [ID] = @ID";
            var pms = new 
            {
                ID = primaryID
            };
            var data = this.dapperTool.DapperQuery<Material>(sql, pms).FirstOrDefault();
            return data;
        }

        public IList<Material> GetAll()
        {
            var sql = @"SELECT [ID]
                        ,[Name]
                        ,[No]
                        ,[Creater]
                        ,[CreatDate]
                        ,[LastEditor]
                        ,[LastUpdate]
                    FROM [dbo].[Material]";
            var data = this.dapperTool.DapperQuery<Material>(sql,null);
            return data;
        }

        public void Update(Material instance)
        {
            var sql = @"UPDATE [dbo].[Material]
                          SET [Name] = @Name
                             ,[No] = @No
                             ,[LastUpdate] = GETDATE()
                             ,[LastEditor] = @LastEditor
                        WHERE [ID] = @ID";
            var pms = new 
            {
                Name = this.dapperTool.ToNVarchar(instance.Name,250),
                No = this.dapperTool.ToVarchar(instance.No,250),
                LastEditor = instance.LastEditor,
                ID = instance.ID
            };
            var data = this.dapperTool.DapperNonQuery(sql, pms);
        }
    }
}
