using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.Business.Business.Login
{
    public interface ILoginBusiness
    {
        CyberSecurityResponseCommon Request(CyberSecurityRequestCommon req);
    }
}
