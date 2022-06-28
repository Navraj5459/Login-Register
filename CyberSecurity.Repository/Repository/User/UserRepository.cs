using CyberSecurity.DataAccessLayer.DataAccessLayer;
using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.Repository.Repository.User
{
    public class UserRepository: IUserRepository
    {
        IDataAccess _dao;
        public UserRepository(IDataAccess dao)
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
                        case "getuserdetailbyid":
                            response = GetUserDetailById(req);
                            break;
                        case "changepassword":
                            response = ChangePassword(req);
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
        private CyberSecurityResponseCommon GetUserDetailById(CyberSecurityRequestCommon req)
        {
            var response = new CyberSecurityResponseCommon();
            try
            {
                var sql = new StringBuilder();
                sql.Append("EXEC spaUser ");
                sql.Append("@Flag = " + _dao.FilterString(req.RequestedFlag));
                sql.Append(" ,@UserId = " + _dao.FilterString(req.RequestedId));
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
        private CyberSecurityResponseCommon ChangePassword(CyberSecurityRequestCommon req)
        {
            var response = new CyberSecurityResponseCommon();
            try
            {
                var common = (UserDetailCommon)req.RequestCommon;
                var sql = new StringBuilder();
                sql.Append("EXEC spaUser ");
                sql.Append("@Flag = " + _dao.FilterString(req.RequestedFlag));
                sql.Append(" ,@UserId = " + _dao.FilterString(common.UserId));
                sql.Append(" ,@OldPassword = " + _dao.FilterString(common.OldPassword));
                sql.Append(" ,@Password = " + _dao.FilterString(common.Password));
                sql.Append(" ,@ConfirmPassword = " + _dao.FilterString(common.ConfirmPassword));
                sql.Append(" ,@User = " + _dao.FilterString(req.RequestedBy));
                var res = _dao.ParseDbResponse(sql.ToString());
                if (res != null)
                {
                    response.Result = res;
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
