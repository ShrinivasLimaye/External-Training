using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace DAL
{
    public class CartDAL
    {
        public static string conString = ConfigurationManager.ConnectionStrings["EStoreDBConnectionString"].ToString();

        public static List<Product> Getcart()
        {
            List<Product> product = new List<Product>();

            SqlConnection con = new SqlConnection(conString);
            string query = "SELECT * FROM Cart";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);


            DataRowCollection rows=ds.Tables[0].Rows;
            foreach( DataRow row in rows)
            {   int id = int.Parse(row["OrderID"].ToString());
                string title = row["Product Name"].ToString();
                int unitPrice = int.Parse(row["price"].ToString());
                int quantity = int.Parse(row["Quantity"].ToString());
                string image = row["Picture"].ToString();
               // int likes = int.Parse(row["Likes"].ToString());

                product.Add(new Product()
                {
                    ID = id,
                    Title = title,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Image = image
                    //Likes = likes
                });
            }
            return product;


        }
    

     
        public static bool Addcart(Product Prodfound)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Cart VALUES (@OrderID, @Product_Name, @picture, @Quantity, @Price)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@OrderID", Prodfound.ID + 1));
                    cmd.Parameters.Add(new SqlParameter("@Product_Name", Prodfound.Title));
                    cmd.Parameters.Add(new SqlParameter("@picture", Prodfound.Image));
                    cmd.Parameters.Add(new SqlParameter("@Price", Prodfound.UnitPrice));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", Prodfound.Quantity));
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
        public static bool Removecart(Product Prodfound)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM cart WHERE [Product Name] =@ProductId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ProductId", Prodfound.Title));
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
        public static bool Purge()
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "TRUNCATE TABLE cart";
                    SqlCommand cmd = new SqlCommand(query, con);
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
