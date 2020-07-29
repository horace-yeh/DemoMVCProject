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
    public class InventoryRepository : IInventoryRepository
    {
        private DapperTool dapperTool;

        public InventoryRepository()
        {
            this.dapperTool = new DapperTool();
        }

        public void Create(Inventory instance)
        {
            var sql = @"INSERT INTO [dbo].[Inventory]
                         ([MaterialID]
                         ,[Quantity]
                         ,[Creater]
                         ,[LastEditor])
                          VALUES
                         (@MaterialID
                         ,@Quantity
                         ,@Creater
                         ,@LastEditor)";
            var pms = new
            {
                MaterialID = instance.MaterialID,
                Quantity = instance.Quantity,
                Creater = instance.Creater,
                LastEditor = instance.LastEditor
            };
            var data = this.dapperTool.DapperNonQuery(sql, pms);
        }

        public void Delete(Inventory instance)
        {
            var sql = @"DELETE FROM [dbo].[Inventory]
                        WHERE [ID] = @ID";
            var pms = new 
            {
                ID = instance.ID
            };
            var data = this.dapperTool.DapperNonQuery(sql, pms);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Inventory Get(int primaryID)
        {
            var sql = @"SELECT [ID]
                         ,[MaterialID]
                         ,[Quantity]
                         ,[Creater]
                         ,[CreatDate]
                         ,[LastEditor]
                         ,[LastUpdate]
                     FROM [dbo].[Inventory]
                     WHERE [ID] = @ID";
            var pms = new { ID = primaryID };
            var data = this.dapperTool.DapperQuery<Inventory>(sql, pms).FirstOrDefault();
            return data;
        }

        public IList<Inventory> GetAll()
        {
            var sql = @"SELECT [ID]
                        ,[MaterialID]
                        ,[Quantity]
                        ,[Creater]
                        ,[CreatDate]
                        ,[LastEditor]
                        ,[LastUpdate]
                    FROM [dbo].[Inventory]";
            var data = this.dapperTool.DapperQuery<Inventory>(sql, null);
            return data;
        }

        public void Update(Inventory instance)
        {
            var sql = @"UPDATE [dbo].[Inventory]
                          SET [MaterialID] = @MaterialID
                             ,[Quantity] = @Quantity
                             ,[LastEditor] = @LastEditor
                             ,[LastUpdate] = GETDATE()
                        WHERE [ID] = @ID";
            var pms = new 
            {
                ID = instance.ID,
                MaterialID = instance.MaterialID,
                Quantity = instance.Quantity,
                LastEditor = instance.LastEditor
            };
            var data = this.dapperTool.DapperNonQuery(sql, pms);
        }
    }
}
