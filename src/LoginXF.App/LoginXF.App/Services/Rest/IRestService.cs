using LoginXF.App.Entities;
using Refit;
using System.Threading.Tasks;

namespace LoginXF.App.Services
{
    public interface IMockyService
    {
        [Get("/v3/83599a37-9b03-47d1-970d-555f8835355c")]
        Task<UserToken> GetToken();
    }
}
