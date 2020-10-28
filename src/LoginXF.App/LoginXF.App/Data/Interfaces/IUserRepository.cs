using LoginXF.App.Entities;

namespace LoginXF.App.Data
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        bool Login(string email, string password);
    }
}
