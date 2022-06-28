using CyberSecurity.Business.Business.Login;
using CyberSecurity.Library;
using CyberSecurity.Models;
using CyberSecurity.SharedCommon.Common;
using DNTCaptcha.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CyberSecurity.Controllers
{
    public class LoginController : Controller
    {
        ILoginBusiness _buss;
        private readonly IDNTCaptchaValidatorService _captchaValidator;
        //private readonly DNTCaptchaOptions _captchaoption;
        public LoginController(ILoginBusiness buss, IDNTCaptchaValidatorService captchaValidator/*, IOptions<DNTCaptchaOptions> captchaoption*/)
        {
            _buss = buss;
            _captchaValidator = captchaValidator;
            //_captchaoption = captchaoption == null ? throw new ArgumentNullException(nameof(captchaoption)) : captchaoption.Value;
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (TempData.ContainsKey("dbresponse"))
            {
                ViewData["dbresponse"] = TempData["dbresponse"];
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var common = new LoginCommon();
                common.UserName = model.UserName;
                common.Password = StaticData.Base64Encode(model.Password);
                CyberSecurityRequestCommon req = new CyberSecurityRequestCommon();
                req.RequestedMethod = RequestType.UserDefined;
                req.RequestedBy = model.UserName;
                req.ActionName = "Login";
                req.RequestedFlag = "Login";
                req.RequestCommon = common;
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
                                HttpContext.Session.SetString("UserId", data.UserId);
                                HttpContext.Session.SetString("UserName", data.UserName);
                                HttpContext.Session.SetString("FullName", data.FullName);
                                HttpContext.Session.SetString("Email", data.Email);
                                HttpContext.Session.SetString("MobileNumber", data.MobileNumber);
                                StaticData.SetMessageInSession(new DbResponse() { ErrorCode = 0, Message = "LOGIN SUCCESSFULLY!" });
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                TempData["dbresponse"] = JsonConvert.SerializeObject(new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" });
                            }
                        }
                        else
                        {
                            TempData["dbresponse"] = JsonConvert.SerializeObject(res.Result);
                        }
                    }
                    else
                    {
                        TempData["dbresponse"] = JsonConvert.SerializeObject(new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" });
                    }
                }
                else
                {
                    TempData["dbresponse"] = JsonConvert.SerializeObject(new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" });
                }
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var errors = string.Join(" ; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                TempData["dbresponse"] = JsonConvert.SerializeObject(new DbResponse() { ErrorCode = 1, Message = errors });
                return RedirectToAction("Login", "Login");
            }
        }
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SignUp(SignUpModel model)
        {
            if (!_captchaValidator.HasRequestValidCaptchaEntry(Language.English, DisplayMode.ShowDigits))
            {
                ModelState.AddModelError("DNTCaptchaInputText", "Please enter the security code.");
            }
            if (ModelState.IsValid)
            {
                var common = new SignUpCommon();    
                common.UserName = model.UserName;
                common.Password = StaticData.Base64Encode(model.Password);
                common.ConfirmPassword = StaticData.Base64Encode(model.ConfirmPassword);
                common.FullName = model.FullName;
                common.Email = model.Email;
                common.MobileNumber = model.MobileNumber;
                CyberSecurityRequestCommon req = new CyberSecurityRequestCommon();
                req.RequestedMethod = RequestType.UserDefined;
                req.RequestedBy = model.UserName;
                req.ActionName = "SignUp";
                req.RequestedFlag = "SignUp";
                req.RequestCommon = common;
                var res = _buss.Request(req);
                if (res != null)
                {
                    if (res.Result != null)
                    {
                        if (res.Result.ErrorCode.Equals(0))
                        {
                            TempData["dbresponse"] = Json(res.Result);
                            return RedirectToAction("Login", "Login");
                        }
                        else
                        {
                            ViewData["dbresponse"] = res.Result;
                        }
                    }
                    else
                    {
                        ViewData["dbresponse"] = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                    }
                }
                else
                {
                    ViewData["dbresponse"] = new DbResponse() { ErrorCode = 1, Message = "USER NOT FOUND!" };
                }
                return View(model);
            }
            else
            {
                var errors = string.Join(" ; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                TempData["dbresponse"] = JsonConvert.SerializeObject(new DbResponse() { ErrorCode = 1, Message = errors });
                return View(model);
            }
        }
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            HttpContext.Session.Clear();
            if (TempData.ContainsKey("dbresponse"))
            {
                var dbresponse = TempData["dbresponse"];
                TempData["dbresponse"] = dbresponse;
            }
            else
            {
                ViewData["dbresponse"] = JsonConvert.SerializeObject(new DbResponse() { ErrorCode = 1, Message = "Session Has Been Expired!" });
                TempData["dbresponse"] = ViewData["dbresponse"];
            }
            return RedirectToAction("Login", "Login");
        }
    }
}
