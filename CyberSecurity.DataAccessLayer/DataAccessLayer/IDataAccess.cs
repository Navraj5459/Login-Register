using CyberSecurity.SharedCommon.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.DataAccessLayer.DataAccessLayer
{
    public interface IDataAccess
    {
        public DataSet ExecuteDataSet(string sql);
        public DataTable ExecuteDataTable(string sql);
        public DbResponse ParseDbResponse(DataTable dt);
        public DbResponse ParseDbResponse(string sql);
        public string FilterString(string sql);
    }
}
