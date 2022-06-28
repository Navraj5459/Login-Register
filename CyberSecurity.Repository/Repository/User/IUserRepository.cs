using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.Repository.Repository.User
{
    public interface IUserRepository
    {
        CyberSecurityResponseCommon Request(CyberSecurityRequestCommon req);
    }
}
