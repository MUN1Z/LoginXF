using Prism.Mvvm;
using SQLite;
using System;

namespace LoginXF.App.Entities
{
    public class User : BindableBase, IBaseEntity
    {
        #region Constructors

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        #endregion

        #region Properties

        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        #endregion
    }
}
