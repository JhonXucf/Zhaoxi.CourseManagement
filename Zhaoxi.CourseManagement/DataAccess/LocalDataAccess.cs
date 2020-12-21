using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Zhaoxi.CourseManagement.DataAccess
{
   public class LocalDataAccess
    {
        private static LocalDataAccess instance;
        private LocalDataAccess(){}
        public LocalDataAccess GetInstance()
        {
            return instance ?? (new LocalDataAccess());
        }
        SqlConnection sqlCon;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDataAdapter;
        private void Dispose()
        {
            if (sqlCmd != null)
            {
                sqlCmd.Dispose();
                sqlCmd = null;
            }
            if (sqlDataAdapter != null)
            {
                sqlDataAdapter.Dispose();
                sqlDataAdapter = null;
            }
            if (sqlCmd != null)
            {
                sqlCon.Close();
                sqlCon.Dispose();
                sqlCon = null;
            }
        }
        public bool DBConnection()
        {
            string sqlConString = ConfigurationManager.ConnectionStrings["sqlDB"].ConnectionString;
            if (this.sqlCon == null)
            {
                this.sqlCon = new SqlConnection(sqlConString);
            }
            try
            {
                this.sqlCon.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
