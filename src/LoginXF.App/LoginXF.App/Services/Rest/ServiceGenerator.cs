using Refit;

namespace LoginXF.App.Services
{
    public class ServiceGenerator
    {
        public static IMockyService GetMockyService()
        {
            return RestService.For<IMockyService>("https://run.mocky.io");
        }
    }
}
