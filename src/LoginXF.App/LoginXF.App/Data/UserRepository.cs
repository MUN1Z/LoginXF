using LoginXF.App.Entities;
using LoginXF.App.Ioc;
using System.Linq;

namespace LoginXF.App.Data
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Constructors

        public UserRepository(ISqLiteConnection connection) : base(connection)
        {
            //Connection.DeleteAll<User>();
            Connection.CreateTable<User>();
        }
        #endregion

        #region Public Methods Implementations

        public bool Login(string email, string password)
        {
            var users = GetAll();
            return users.Any(c => c.Email.Equals(email) && c.Password.Equals(password));
        }

        #endregion
    }
}
