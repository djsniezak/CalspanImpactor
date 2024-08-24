using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Data;


namespace Dats
{
    public class Database
    {
        private readonly SqlConnection _Connection = null;
        public Database() 
        {
            _Connection = new SqlConnection()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["CALSPAN_SLED"].ConnectionString
            };
            
        }
        protected SqlConnection Open ( out string errorMessage)
        {
            errorMessage = string.Empty;
            if (_Connection.State == ConnectionState.Closed)
            {
                try
                {
                    _Connection.Open ();    
                }
                catch (SqlException exSql)
                {
                    errorMessage = "An exception occured opening the Connection to the database; Exception = " + exSql.Message;
                }
            }

            return _Connection;
        }

        protected string Close () 
        {
            string strErrorMessage = string.Empty;
            return strErrorMessage;
        }

    }
}
