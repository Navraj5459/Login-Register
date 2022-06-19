using CyberSecurity.SharedCommon.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurity.DataAccessLayer.DataAccessLayer
{
    public class DataAccess: IDataAccess
    {
        IConfiguration _config;
        SqlConnection _conn;
        public DataAccess(IConfiguration config)
        {
            _config = config;
            Init();
        }
        private string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }
        private int GetConnectionTimeOut()
        {
            int timeout = 120;
            if (string.IsNullOrEmpty(_config.GetConnectionString("GetConnectionTimeOut")))
            {
                timeout = 120;
            }
            else
            {
                timeout = Convert.ToInt32(_config.GetConnectionString("GetConnectionTimeOut"));
            }
            return timeout;
        }
        private void Init()
        {
            _conn = new SqlConnection(GetConnectionString());
        }
        private void OpenConnection()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
            }
            _conn.Open();
        }
        private void CloseConnection()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
            }
        }
        public DataSet ExecuteDataSet(string sql)
        {
            DataSet ds = new DataSet();
            var cmd = new SqlCommand(sql, _conn);
            SqlDataAdapter da;
            try
            {
                OpenConnection();
                cmd.CommandTimeout = GetConnectionTimeOut();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                CloseConnection();
            }
            catch
            {
                CloseConnection();
            }
            finally
            {
                da = null;
                CloseConnection();
            }
            return ds;
        }
        public DataTable ExecuteDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (var ds = ExecuteDataSet(sql))
            {
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        dt = ds.Tables[0];
                    }
                    else
                    {
                        dt = null;
                    }
                }
                else
                {
                    dt = null;
                }
            }
            return dt;
        }
        public DbResponse ParseDbResponse(DataTable dt)
        {
            DbResponse res = new DbResponse();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    res.ErrorCode = Convert.ToInt32(dt.Rows[0][0]);
                    res.Message = dt.Rows[0][1].ToString();
                    if (dt.Columns.Count >= 3)
                    {
                        res.Id = dt.Rows[0][2].ToString();
                        res.ExtraId = dt.Rows[0][3].ToString();
                    }
                }
            }
            else
            {
                res.ErrorCode = 1;
                res.Message = null;
            }
            return res;
        }
        public DbResponse ParseDbResponse(string sql)
        {
            return ParseDbResponse(ExecuteDataTable(sql));
        }
        public string FilterString(string str)
        {
            var strval = "";
            if (string.IsNullOrEmpty(str))
            {
                strval = "null";
            }
            else
            {
                strval = "'" + str + "'";
            }
            return strval;
        }
    }
}
