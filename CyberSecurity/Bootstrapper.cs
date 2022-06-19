using CyberSecurity.Business.Business;
using CyberSecurity.DataAccessLayer.DataAccessLayer;
using CyberSecurity.Repository.Repository.Login;
using Microsoft.Extensions.DependencyInjection;

namespace CyberSecurity
{
    public static class Bootstrapper
    {
        public static void Initialise(IServiceCollection service)
        {
            service.AddSingleton<IDataAccess, DataAccess>();
            service.AddSingleton<ILoginBusiness, LoginBusiness>();
            service.AddSingleton<ILoginRepository, LoginRepository>();
        }
    }
}
