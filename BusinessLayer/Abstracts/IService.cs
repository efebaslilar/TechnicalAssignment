using EntityLayer.ResultModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IService<T, Id>
    {
        IDataResult<T> Add(T model);
        IResult Update(T model);
        IResult Delete(T model);
        IDataResult<T> GetById(Id id);
        IDataResult<T> GetByConditions(Expression<Func<T, bool>> filter = null);
        IDataResult<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
