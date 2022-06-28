using CyberSecurity.Business.Business.Login;
using CyberSecurity.Business.Business.User;
using CyberSecurity.DataAccessLayer.DataAccessLayer;
using CyberSecurity.Repository.Repository.Login;
using CyberSecurity.Repository.Repository.User;
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
            service.AddSingleton<IUserBusiness, UserBusiness>();
            service.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
