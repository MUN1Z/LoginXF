using LoginXF.App.Entities;
using LoginXF.App.Ioc;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoginXF.App.Data
{
    public class BaseRepository<T> : IDisposable, IRepositoryBase<T> where T : IBaseEntity, new()
    {
        #region Protected Members

        protected readonly SQLiteConnection Connection;

        #endregion

        #region Constructors

        public BaseRepository(ISqLiteConnection connection)
        {
            Connection = connection.GetConnection();
        }

        #endregion

        #region Public Methods Implementations

        public bool Persist(T obj) => Connection.Insert(obj) > 0;

        public IEnumerable<T> GetAll() => Connection.Table<T>().AsEnumerable();

        public T GetById(string id) => Connection.Table<T>().AsEnumerable<T>().FirstOrDefault(c => c.Id.Equals(id));

        public bool Delete(T obj) => Connection.Delete(obj) > 0;

        public bool Delete(string id) => Connection.Delete(GetById(id)) > 0;

        public bool DeleteAll() => Connection.DeleteAll<T>() > 0;

        public void Dispose() => Connection.Dispose();

        #endregion
    }
}
