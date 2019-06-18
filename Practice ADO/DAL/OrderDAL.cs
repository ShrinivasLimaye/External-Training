using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BOLayer;
using System.Configuration;
namespace DAL
{
    public class OrderDAL
    {
        public static string conString = ConfigurationManager.ConnectionStrings["EStoreDBConnectionString"].ToString();

        public static bool Add(Product Prodfound)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO OrderDetails VALUES (@OrderID, @ProductID, @Qty, @UnitPrice,@Total)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@OrderID", Prodfound.ID + 1));
                    cmd.Parameters.Add(new SqlParameter("@ProductID", Prodfound.ID));
                    cmd.Parameters.Add(new SqlParameter("@Qty", Prodfound.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@UnitPrice", Prodfound.UnitPrice));
                    cmd.Parameters.Add(new SqlParameter("@Total", Prodfound.UnitPrice * Prodfound.Quantity));

                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }
    }
}
