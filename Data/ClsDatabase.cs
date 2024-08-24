using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.Remoting.Messaging;
using System.Data;


namespace Data
{
    public class Database
    {
        private SqlConnection _Connection = null;
        private readonly string _ConnectionString = string.Empty;
        public Database(string connectionString)
        {
            _ConnectionString = connectionString;   
            _Connection = new SqlConnection(connectionString);
        }

        public SqlConnection Connection
        {
            get 
            { 
                if (_Connection == null)
                {
                    _Connection = new SqlConnection(_ConnectionString);
                }
                return _Connection;
            }
        }
            
        public SqlConnection Open ( out string errorMessage)
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

        public string Close () 
        {
            string strErrorMessage = string.Empty;
            if ( _Connection.State != ConnectionState.Closed)
            {
                try
                {
                    _Connection.Close();
                }
                catch (SqlException exSql)
                {
                    strErrorMessage = exSql.Message;
                }

                _Connection = null;
            }
            return strErrorMessage;
        }
    }
}
