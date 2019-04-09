using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepositories
{
    public interface IRepo<T>: IDisposable
    {
        T Add(T item);
        bool Update(T item);
        bool Delete(T item);
        bool Detelte(int id);
        T Get(int id);
        List<T> GetList();

    }
}
