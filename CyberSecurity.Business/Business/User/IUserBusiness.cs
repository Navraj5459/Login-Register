﻿using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.Business.Business.User
{
    public interface IUserBusiness
    {
        CyberSecurityResponseCommon Request(CyberSecurityRequestCommon req);
    }
}
