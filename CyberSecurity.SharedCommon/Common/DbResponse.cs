using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.SharedCommon.Common
{
    public class DbResponse
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string? Id { get; set; }
        public string ExtraId { get; set; }
    }
}
