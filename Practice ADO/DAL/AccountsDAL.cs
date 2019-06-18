using System;
using System.Data;
using System.Data.SqlClient;
using BOLayer;
using System.Configuration;

namespace DAL
{
    public static class AccountDAL
    {
        public static bool Validate(string userName, string password)
        {
            #region  string assignment
            bool status = false;
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\RaviT\MVC\ECommerce\EStore\App_Data\TFLGreenhouse.mdf;Integrated Security=True";
            string connectionString = ConfigurationManager.ConnectionStrings["EStoreDBConnectionString"].ToString();
            string commandString = "SELECT * FROM Users WHERE userName=@UserName AND password=@Password";
            #endregion

            #region Command Exeuction context setting

            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = commandString;
            cmd.Parameters.Add(new SqlParameter("@UserName",userName));
            cmd.Parameters.Add(new SqlParameter("@Password", password));

            #endregion

            #region Query Processing

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader() as SqlDataReader;
                {
                    if (reader!=null)
                    {
                        if (reader.HasRows)
                        {
                            status = true;
                            reader.Close();
                        }
                    }
                   
                }
             }
            catch (SqlException exp)
            {
                throw exp;

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                 con.Close();
            }


            #endregion

            return status;
        }

    }
   











  /* public  class AccountsDAL
    {
        private static string connectionString = string.Empty;
        static AccountsDAL()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravit\source\repos\ECommerceSolution\EStore\App_Data\ECommerceDB.mdf;Integrated Security=True";

        }
        public static bool Validate(Credential theCredentail)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM users WHERE userName=@UserName AND password=@Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@UserName", theCredentail.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", theCredentail.Password));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                       {
                            status = true;
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
         

        }
    }

    */

}
