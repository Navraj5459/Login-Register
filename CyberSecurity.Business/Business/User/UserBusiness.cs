using CyberSecurity.Repository.Repository.User;
using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.Business.Business.User
{
    public class UserBusiness: IUserBusiness
    {
        IUserRepository _repo;
        public UserBusiness(IUserRepository repo)
        {
            _repo = repo;
        }
        public CyberSecurityResponseCommon Request(CyberSecurityRequestCommon req)
        {
            return _repo.Request(req);
        }
    }
}
