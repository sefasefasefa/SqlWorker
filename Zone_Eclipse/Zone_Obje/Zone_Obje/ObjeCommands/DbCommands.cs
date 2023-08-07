using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zone_Obje.Karnel;
namespace Zone_Obje.ObjeCommands
{
    public class DbCommands
    {
        private SqlConnection SqlCon = new SqlConnection();
        private ArrayList _parameters = new ArrayList();

        public DbCommands(bool LocalCon,String ConString = "")
        {
            if (LocalCon == true)
            {
                SqlCon = ConnectionProvider.GetConnection();
            }
            else
            {
                SqlCon = ConnectionProvider.GetConnectionWithMy(ConString);
            }
        }
        private void AddParameters(SqlCommand sqlcmnd)
        {
            foreach (SqlParameter parameter in _parameters)
            {
                sqlcmnd.Parameters.Add(parameter);
            }
        }
        private SqlCommand GetCommand(string commandText, CommandType commandType)
        {
            SqlCommand command = SqlCon.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return command;
        }
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {

            int rvalue = 0;
            SqlCommand myCommand = this.GetCommand(commandText, commandType);
            this.AddParameters(myCommand);
            try
            {
                if (myCommand.Connection.State != ConnectionState.Open)
                {
                    myCommand.Connection.Open();
                }
                rvalue = myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return rvalue;
        }
         
        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            object rvalue = null;
            SqlCommand myCommand = this.GetCommand(commandText, commandType);
            this.AddParameters(myCommand);
            try
            {
                if (myCommand.Connection.State != ConnectionState.Open)
                {
                    myCommand.Connection.Open();
                }
                rvalue = myCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return rvalue;
        }

       

        public List<String> ExecuteReader(string commandText, CommandType commandType)
        {
            List<String> _strings = new List<String>();
            SqlDataReader rvalue;
            SqlCommand myCommand = this.GetCommand(commandText, commandType);
            this.AddParameters(myCommand);
            try
            {
                if (myCommand.Connection.State != ConnectionState.Open)
                {
                    myCommand.Connection.Open();
                }
                rvalue = myCommand.ExecuteReader();
                for (int i = 0; i < rvalue.FieldCount; i++)
                {
                    while (rvalue.Read())
                    {
                        _strings.Add(rvalue[i].ToString());   
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return _strings;
        }

        public Dictionary<String, string> ExecuteReaderDictionary(string commandText, CommandType commandType)
        {
            Dictionary<String, string> _strings = new Dictionary<String, string>();
            SqlDataReader rvalue;
            SqlCommand myCommand = this.GetCommand(commandText, commandType);
            this.AddParameters(myCommand);
            try
            {
                if (myCommand.Connection.State != ConnectionState.Open)
                {
                    myCommand.Connection.Open();
                }
                rvalue = myCommand.ExecuteReader();
                foreach (var item in rvalue)
                {
                    // item is a DataRow object that contains the column name and data type
                    string columnName = rvalue["COLUMN_NAME"].ToString();
                    string dataType = rvalue["DATA_TYPE"].ToString();
                    _strings.Add(columnName, dataType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myCommand.Connection.Close();
            }
            return _strings;
        }
        public void Dispose()
        {
            try
            {
                SqlCon.Dispose();
            }
            catch
            {
            }
        }
    }
}
