using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace BelatrixTest
{
    public class LogDatabase
    {
        public string connectionString = System.Configuration.ConfigurationManager.
                                         ConnectionStrings["connectionStringBelatrix"].ConnectionString;
        public string table = "";

        public bool AddLogDataBase(string message, TypeMessage type)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var cmd = connection.CreateCommand();
                    cmd.Connection = connection;

                    cmd.CommandText = "Insert into Log Values( '" + message + "','" + type.ToString() + "')";
                    return Convert.ToInt32(cmd.ExecuteNonQuery()) > 0;
                    //transaction.Commit();
                }
                catch (Exception ex)
                {
                    return false;
                    //transaction.Rollback();
                }
            }
        }

    }
}
