using LoginXF.App.Entities;

namespace LoginXF.App.Services
{
    public interface IUserTokenService
    {
        void SaveUserToken(UserToken token);
        UserToken GetUserToken();
    }
}
