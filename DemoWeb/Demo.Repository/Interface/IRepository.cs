using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Get(int primaryID);
        IList<TEntity> GetAll();
        void Create(TEntity instance);
        void Update(TEntity instance);
        void Delete(TEntity instance);
    }
}
