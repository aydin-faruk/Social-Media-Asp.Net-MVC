using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Interfaces
{
    //[ServiceContract]
    public interface IGenericService<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> predicate);

        //[OperationContract]
        List<T> GetAll();

        //[OperationContract]
        T Get(int id);

        //[OperationContract]
        T Add(T entity);

        //[OperationContract]
        bool Delete(int id);

        //[OperationContract]
        void Update(T entity);

        //[OperationContract]
        int Save(T entity);
    }
}
