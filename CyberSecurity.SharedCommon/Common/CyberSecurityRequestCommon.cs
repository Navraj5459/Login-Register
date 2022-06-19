using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.SharedCommon.Common
{
    public enum RequestType
    {
        Insert,
        Update,
        Delete,
        UserDefined
    }
    public class CyberSecurityRequestCommon
    {
        public DbResponse Result { get; set; }
        public object RequestCommon { get; set; }
        public RequestType RequestedMethod { get; set; }
        public string ActionName { get; set; }
        public string RequestedFlag { get; set; }
        public string RequestedMedium { get; set; }
        public string RequestedBy { get; set; }
        public string RequestedId { get; set; }
    }
}
