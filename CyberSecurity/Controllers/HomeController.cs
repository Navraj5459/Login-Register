using CyberSecurity.Business.Business.Login;
using CyberSecurity.Business.Business.User;
using CyberSecurity.Library;
using CyberSecurity.Models;
using CyberSecurity.SharedCommon.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CyberSecurity.Controllers
{
    [SessionExpiryFilter]
    public class HomeController : Controller
    {
        IUserBusiness _buss;
        public HomeController(IUserBusiness buss)
        {
            _buss = buss;
        }
        public ActionResult Index()
        {
            StaticData.CheckSession();
            return View();
        }
        public ActionResult ChangePassword()
        {
            StaticData.CheckSession();
            CyberSecurityRequestCommon req = new CyberSecurityRequestCommon();
            req.RequestedMethod = RequestType.UserDefined;
            req.RequestedBy = StaticData.GetUser(); ;
            req.ActionName = "GetUserDetailById";
            req.RequestedFlag = "GetUserDetailById";
            req.RequestedId = StaticData.GetUserId();
            var res = _buss.Request(req);
            if (res != null)
            {
                if (res.Result != null)
                {
                    if (res.Result.ErrorCode.Equals(0))
                    {
                        if (res.ResultCommon != null)
                        {
                            var data = (UserDetailCommon)res.ResultCommon;
                            var model = new UserDetailModel();
                            model.UserName = data.UserName;
                            model.FullName = data.FullName;
                            return View(model);
                        }
                        else
                        {
                            StaticData.SetMessageInSession(new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" });
                        }
                    }
                    else
                    {
                        StaticData.SetMessageInSession(res.Result);
                    }
                }
                else
                {
                    StaticData.SetMessageInSession(new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" });
                }
            }
            else
            {
                StaticData.SetMessageInSession(new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" });
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserDetailModel model)
        {
            StaticData.CheckSession();
            if (string.IsNullOrEmpty(model.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "OLD PASSWORD SHOULD NOT BE NULL OR EMPTY!");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "PASSWORD SHOULD NOT BE NULL OR EMPTY!");
            }
            if (string.IsNullOrEmpty(model.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "CONFIRM PASSWORD SHOULD NOT BE NULL OR EMPTY!");
            }
            if(model.Password == model.OldPassword)
            {
                ModelState.AddModelError("Password", "NEW PASSWORD SHOULD NOT BE SAME AS OLD PASSWORD!");
            }
            if(model.ConfirmPassword != model.Password)
            {
                ModelState.AddModelError("ConfirmPassword", "PASSWORD AND CONFIRM PASSWORD DOEST NOT MATCHED!");
            }
            if (ModelState.IsValid)
            {
                var common = new UserDetailCommon();
                common.UserId = StaticData.GetUserId();
                common.OldPassword = StaticData.Base64Encode(model.OldPassword);
                common.Password = StaticData.Base64Encode(model.Password);
                common.ConfirmPassword = StaticData.Base64Encode(model.ConfirmPassword);
                var req = new CyberSecurityRequestCommon();
                req.ActionName = "ChangePassword";
                req.RequestedFlag = "ChangePassword";
                req.RequestedMethod = RequestType.UserDefined;
                req.RequestedBy = StaticData.GetUser();
                req.RequestCommon = common;
                var res = _buss.Request(req);
                if(res != null)
                {
                    if(res.Result != null)
                    {
                        if (res.Result.ErrorCode.Equals(0))
                        {
                            TempData["dbresponse"] = JsonConvert.SerializeObject(res.Result);
                            return RedirectToAction("LogOff", "Login");
                        }
                        else
                        {
                            StaticData.SetMessageInSession(res.Result);
                            return RedirectToAction("ChangePassword");
                        }
                    }
                    else
                    {
                        StaticData.SetMessageInSession(new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" });
                        return RedirectToAction("ChangePassword");
                    }
                }
                else
                {
                    StaticData.SetMessageInSession(new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" });
                    return RedirectToAction("ChangePassword");
                }
            }
            else
            {
                var errors = string.Join(" ; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                StaticData.SetMessageInSession(new DbResponse() { ErrorCode = 1, Message = errors });
                return RedirectToAction("ChangePassword");
            }
        }
    }
}