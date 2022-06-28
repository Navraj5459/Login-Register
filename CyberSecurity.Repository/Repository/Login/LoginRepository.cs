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
                        case "login":
                            response = Login(req);
                            break;
                        case "signup":
                            response = SignUp(req);
                            break;
                        default:
                            result.ErrorCode = 1;
                            result.Message = "Content Not Found!";
                            response.Result = result;
                            break;
                    }
                    break;
                default:
                    result.ErrorCode = 1;
                    result.Message = "Content Not Found!";
                    response.Result = result;
                    break;
            }
            return response;
        }
        private CyberSecurityResponseCommon Login(CyberSecurityRequestCommon req)
        {
            var response = new CyberSecurityResponseCommon();
            try
            {
                var common = (LoginCommon)req.RequestCommon;
                var sql = new StringBuilder();
                sql.Append("EXEC spaLogin ");
                sql.Append("@Flag = " + _dao.FilterString(req.RequestedFlag));
                sql.Append(" ,@UserName = " + _dao.FilterString(common.UserName));
                sql.Append(" ,@Password = " + _dao.FilterString(common.Password));
                sql.Append(" ,@User = " + _dao.FilterString(req.RequestedBy));
                var res = _dao.ExecuteDataSet(sql.ToString());
                if (res != null)
                {
                    var dt1 = res.Tables[0];
                    if (dt1 != null)
                    {
                        var result = _dao.ParseDbResponse(dt1);
                        response.Result = result;
                        if (response.Result != null)
                        {
                            if (response.Result.ErrorCode.Equals(0))
                            {
                                var dt2 = res.Tables[1];
                                if (dt2 != null)
                                {
                                    var item = dt2.Rows[0];
                                    var data = new UserDetailCommon();
                                    data.UserId = item["Id"].ToString();
                                    data.UserName = item["UserName"].ToString();
                                    data.FullName = item["FullName"].ToString();
                                    data.Email = item["Email"].ToString();
                                    data.MobileNumber = item["MobileNumber"].ToString();
                                    response.ResultCommon = data;
                                }
                                else
                                {
                                    response.Result = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                                }
                            }
                        }
                        else
                        {
                            response.Result = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                        }
                    }
                    else
                    {
                        response.Result = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                    }
                }
                else
                {
                    response.Result = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Result = new DbResponse() { ErrorCode = 1, Message = ex.Message };
                return response;
            }
        }
        private CyberSecurityResponseCommon SignUp(CyberSecurityRequestCommon req)
        {
            var response = new CyberSecurityResponseCommon();
            try
            {
                var common = (SignUpCommon)req.RequestCommon;
                var sql = new StringBuilder();
                sql.Append("EXEC spaLogin ");
                sql.Append("@Flag = " + _dao.FilterString(req.RequestedFlag));
                sql.Append(" ,@UserName = " + _dao.FilterString(common.UserName));
                sql.Append(" ,@Password = " + _dao.FilterString(common.Password));
                sql.Append(" ,@ConfirmPassword = " + _dao.FilterString(common.ConfirmPassword));
                sql.Append(" ,@FullName = " + _dao.FilterString(common.FullName));
                sql.Append(" ,@Email = " + _dao.FilterString(common.Email));
                sql.Append(" ,@MobileNumber = " + _dao.FilterString(common.MobileNumber));
                sql.Append(" ,@User = " + _dao.FilterString(req.RequestedBy));
                var res = _dao.ExecuteDataSet(sql.ToString());
                if (res != null)
                {
                    var dt1 = res.Tables[0];
                    if (dt1 != null)
                    {
                        var result = _dao.ParseDbResponse(dt1);
                        response.Result = result;
                        if (response.Result != null)
                        {
                            response.Result = response.Result;
                        }
                        else
                        {
                            response.Result = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                        }
                    }
                    else
                    {
                        response.Result = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                    }
                }
                else
                {
                    response.Result = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                }
                return response;
            }
            catch (Exception ex)
            {
                response.Result = new DbResponse() { ErrorCode = 1, Message = ex.Message };
                return response;
            }
        }
    }
}
