using CyberSecurity.Repository.Repository.Login;
using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.Business.Business.Login
{
    public class LoginBusiness : ILoginBusiness
    {
        ILoginRepository _repo;
        public LoginBusiness(ILoginRepository repo)
        {
            _repo = repo;
        }
        public CyberSecurityResponseCommon Request(CyberSecurityRequestCommon req)
        {
            return _repo.Request(req);
        }
    }
}
