using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zone_Obje.Karnel
{
    public class ConnectionProvider
    {
        private ConnectionProvider()
        { }
        internal static SqlConnection GetConnection(string ConnectionName)
        {
            SqlConnection _instance = new SqlConnection();
            _instance.ConnectionString = ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
            if (_instance.ConnectionString == null || _instance.ConnectionString == "")
            {
                _instance.ConnectionString = ConnectionString;
            }
            return _instance;
        }
        internal static SqlConnection GetConnection()
        {
            SqlConnection _instance = new SqlConnection();
            _instance.ConnectionString = ConnectionProvider.ConnectionString;
            return _instance;
        }
        internal static SqlConnection GetConnectionWithMy(string Constring)
        {
            SqlConnection _instance = new SqlConnection();
         
            _instance.ConnectionString = Constring;
            return _instance;
        }
        private static string ConnectionString
        {

            get
            {
                    string theConnectionString = "";
                    theConnectionString = ConfigurationManager.ConnectionStrings["erpConnStr"].ConnectionString;
                    return theConnectionString;
            }
        }
    }
}
