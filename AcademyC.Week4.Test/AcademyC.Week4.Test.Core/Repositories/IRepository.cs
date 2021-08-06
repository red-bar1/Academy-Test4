using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyC.Week4.Test.Core.Repositories
{
    public interface IRepository<T>
    {
        List<T> Fetch();
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool DeleteById(int id);
    }
}
