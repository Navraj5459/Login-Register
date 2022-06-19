using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.Repository.Repository.Login
{
    public interface ILoginRepository
    {
        CyberSecurityResponseCommon Request(CyberSecurityRequestCommon req);
    }
}
