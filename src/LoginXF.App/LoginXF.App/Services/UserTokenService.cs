using LoginXF.App.Entities;

namespace LoginXF.App.Services
{
    public class UserTokenService : IUserTokenService
    {
        #region Private Members

        private UserToken _userToken;

        #endregion

        #region Public Methods Implementations

        public UserToken GetUserToken() => _userToken;

        public void SaveUserToken(UserToken token) => _userToken = token;

        #endregion
    }
}
