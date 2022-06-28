using CyberSecurity.SharedCommon.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace CyberSecurity.Library
{
    public static class StaticData
    {
        static HttpContextAccessor _context;
        static string SaltKey = "CCDB5731BB484E";
        public static void InitHttpContext()
        {
            _context = new HttpContextAccessor();
        }
        public static string Base64Encode(string plainString)
        {
            plainString = string.Concat(plainString, SaltKey);
            var encode = System.Text.Encoding.UTF8.GetBytes(plainString);
            return Convert.ToBase64String(encode);
        }
        public static string Base64Decode(string encyptString)
        {
            var str = Convert.FromBase64String(encyptString);
            var Base64Decode = System.Text.Encoding.UTF8.GetString(str);
            Base64Decode = Base64Decode.Replace(SaltKey, "");
            return Base64Decode;
        }
        public static bool CheckSession()
        {
            InitHttpContext();
            if (_context.HttpContext.Session.Keys.Contains("UserId"))
            {
                if (string.IsNullOrEmpty(_context.HttpContext.Session.GetString("UserId")))
                {
                    _context.HttpContext.Session.Clear();
                    _context.HttpContext.Response.Redirect("/Login/LogOff");
                    return false;
                }
            }
            else
            {
                _context.HttpContext.Session.Clear();
                _context.HttpContext.Response.Redirect("/Login/LogOff");
                return false;
            }
            return true;
        }
        public static string GetUser()
        {
            InitHttpContext();
            string user = string.Empty;
            var keys = _context.HttpContext.Session.Keys;
            if (keys.Contains("UserName"))
            {
                if (!string.IsNullOrEmpty(_context.HttpContext.Session.GetString("UserName")))
                {
                    user = _context.HttpContext.Session.GetString("UserName");
                }
                else
                {
                    user = "";
                }
            }
            else
            {
                user = "";
            }
            return user;
        }
        public static string GetUserFullName()
        {
            InitHttpContext();
            string user = string.Empty;
            var keys = _context.HttpContext.Session.Keys;
            if (keys.Contains("FullName"))
            {
                if (!string.IsNullOrEmpty(_context.HttpContext.Session.GetString("FullName")))
                {
                    user = _context.HttpContext.Session.GetString("FullName");
                }
                else
                {
                    user = "";
                }
            }
            else
            {
                user = "";
            }
            return user;
        }
        public static string GetUserId()
        {
            InitHttpContext();
            string user = string.Empty;
            var keys = _context.HttpContext.Session.Keys;
            if (keys.Contains("UserId"))
            {
                if (!string.IsNullOrEmpty(_context.HttpContext.Session.GetString("UserId")))
                {
                    user = _context.HttpContext.Session.GetString("UserId");
                }
                else
                {
                    user = "";
                }
            }
            else
            {
                user = "";
            }
            return user;
        }
        public static string GetSessionValue(string key)
        {
            InitHttpContext();
            string str = string.Empty;
            var keys = _context.HttpContext.Session.Keys;
            if (keys.Contains(key))
            {
                if (!string.IsNullOrEmpty(_context.HttpContext.Session.GetString(key)))
                {
                    str = _context.HttpContext.Session.GetString(key);
                }
                else
                {
                    str = "";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }
        public static void SetSession(string key, string value)
        {
            InitHttpContext();
            _context.HttpContext.Session.SetString(key, value);
        }
        public static void SetMessageInSession(DbResponse res)
        {
            InitHttpContext();
            if (res != null)
            {
                _context.HttpContext.Session.SetString("dbresponse", JsonConvert.SerializeObject(res));
            }
        }
        public static DbResponse GetSessionMessage()
        {
            InitHttpContext();
            var result = new DbResponse();
            var dbresponse = _context.HttpContext.Session.Keys.Contains("dbresponse");
            if (dbresponse == true)
            {
                if (!string.IsNullOrEmpty(_context.HttpContext.Session.GetString("dbresponse")))
                {
                    result = JsonConvert.DeserializeObject<DbResponse>(_context.HttpContext.Session.GetString("dbresponse"));
                    _context.HttpContext.Session.Remove("dbresponse");
                }
            }
            return result;
        }
    }
}
