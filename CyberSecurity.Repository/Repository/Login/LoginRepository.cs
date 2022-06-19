using CyberSecurity.DataAccessLayer.DataAccessLayer;
using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.Repository.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        IDataAccess _dao;
        public LoginRepository(IDataAccess dao)
        {
            _dao = dao;
        }
        public CyberSecurityResponseCommon Request(CyberSecurityRequestCommon req)
        {
            CyberSecurityResponseCommon response = new CyberSecurityResponseCommon();
            var result = new DbResponse();
            switch (req.RequestedMethod)
            {
                case RequestType.UserDefined:
                    switch (req.ActionName.ToLower())
                    {
                        case "":
                            break;
                        default:
                            result.ErrorCode = 1;
                            result.Message = "Content Not Found!";
                            break;
                    }
                    break;
                default:
                    result.ErrorCode = 1;
                    result.Message = "Content Not Found!";
                    break;
            }
            response.Result = result;
            return response;
        }
    }
}
