using LoginXF.App.Entities;
using System;
using System.Collections.Generic;

namespace LoginXF.App.Data
{
    public interface IRepositoryBase<T> where T : IBaseEntity
    {
        bool Persist(T obj);
        IEnumerable<T> GetAll();
        T GetById(string key);
        bool Delete(string obj);
        bool Delete(T obj);
        bool DeleteAll();
        void Dispose();
    }
}
