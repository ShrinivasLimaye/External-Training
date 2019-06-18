using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BOLayer;
using System.Configuration;

namespace DAL
{
    public class ProductDAL
    {
       // public static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravit\source\repos\ECommerceSolution\EStore\App_Data\ECommerceDB.mdf;Integrated Security=True";
        public static string conString = ConfigurationManager.ConnectionStrings["EStoreDBConnectionString"].ToString();
        public static List<Product> GetAll()
        {
            List<Product> products = new List<Product>();


            /*products.Add(new Product() { ID=1, Title = "Gerbera", Description="Wedding flower", UnitPrice = 25, Quantity = 2450 });
            products.Add(new Product() { ID = 2, Title = "Jasmine", Description = "Worship flower", UnitPrice = 345, Quantity = 5000 });
            products.Add(new Product() { ID = 3, Title = "Lily", Description = "Smelling flower", UnitPrice = 65, Quantity = 6000 });
            products.Add(new Product() { ID = 4, Title = "Rose", Description = "Valentine flower", UnitPrice = 123, Quantity = 12000 });
            products.Add(new Product() { ID = 5, Title = "Carnation", Description = "Festival flower", UnitPrice = 45, Quantity = 500 });
            products.Add(new Product() { ID = 6, Title = "Marigold", Description = "Dasara flower", UnitPrice = 43, Quantity = 3000 });
           */

            //ADO.NET  (JDBC)
            // lot of ready made classess provide by FCL
            // Connection, Command, DataReader, Adapter,
            // DataSet,etc.
            // Fetch data from database
            // CRUD operations againest database
            // perform Transations against database
            // import namespace : System.data.dll
            //namespace: System.Data
            //namespace: System.Data.Sqlclient
            // SqlConnection, SqlCommand,SqlDataReader,
            // SqlDataAdapter, DataSet,etc.


            //namespace: System.Data.Oracle
            // OracleConnection, OracleCommand,OralcleDataReader,
            // OracleDataAdapter, DataSet,etc.


            //Step 1:
            //Create Connection object with connection string
            //Create Command object with Query
            //Open Connection 
            //Execute Query
            //Fetch records from result
            //create List of Products by fetching from each record
            //retrurn list of products




            //Create Connection object with connection string
           // string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravit\source\repos\ECommerceSolution\EStore\App_Data\ECommerceDB.mdf;Integrated Security=True";

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * FROM flowers";
             IDbCommand cmd = new SqlCommand(query, con as SqlConnection);


            #region  Connected Data Access 
          
            /*
            try
            {
                con.Open();
                IDataReader reader = cmd.ExecuteReader();


                //Online data using streaming mechanism

                while(reader.Read())
                {
                    int id = int.Parse(reader["Id"].ToString());
                    string title = reader["Title"].ToString();
                    string description = reader["Description"].ToString();
                    int unitPrice = int.Parse(reader["UnitPrice"].ToString());
                    int quantity = int.Parse(reader["Quantity"].ToString());
                    string image = reader["Image"].ToString();
                    int likes = int.Parse(reader["Likes"].ToString());

                    products.Add(new Product() { ID = id, Title =title, Description =description,
                                                    UnitPrice = unitPrice, Quantity = quantity,
                                                    Image =image,Likes=likes });

                }
                reader.Close();
            }

            catch(SqlException exp)
            {
                string message = exp.Message;
                //report to developer 
                //log exception message log file

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

                 */

            #endregion


            #region Disconnected Data Access

            IDbDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            da.Fill(ds);



            //Offline data 

            DataRowCollection rows=ds.Tables[0].Rows;
            foreach( DataRow row in rows)
            {   int id = int.Parse(row["ProductId"].ToString());
                string title = row["Title"].ToString();
                string description = row["Description"].ToString();
                int unitPrice = int.Parse(row["price"].ToString());
                int quantity = int.Parse(row["Quantity"].ToString());
                string image = row["Picture"].ToString();
               // int likes = int.Parse(row["Likes"].ToString());

                products.Add(new Product()
                {
                    ID = id,
                    Title = title,
                    Description = description,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Image = image
                    //Likes = likes
                });



            }



            #endregion

            //Create Command object with Query
            //Open Connection 
            //Execute Query
            //Fetch records from result
            //create List of Products by fetching from each record
            //retrurn list of products

            //ORM Technique
            //Entity Framework

            return products;
        }

       public static bool Insert(Product product)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO flowers (productID,title, description, picture, price, quantity) " +
                        "VALUES (@productID,@title, @description, @picture, @price, @quantity)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@productID", 1));

                    cmd.Parameters.Add(new SqlParameter("@title", product.Title));
                    cmd.Parameters.Add(new SqlParameter("@description", product.Description));
                    cmd.Parameters.Add(new SqlParameter("@picture", product.Image));
                    cmd.Parameters.Add(new SqlParameter("@price", product.UnitPrice));       
                    cmd.Parameters.Add(new SqlParameter("@quantity", product.Quantity));
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

        public static bool Updatequant(Product ProdFound)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE flowers SET quantity=@Quantity " + "WHERE productID=@Id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@Id", ProdFound.ID));
                    cmd.Parameters.Add(new SqlParameter("@Quantity", ProdFound.Quantity));
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

        public static bool Delete(int productId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM products WHERE Id=@ProductId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ProductId", productId));
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

        public static Product Get(int productId)
        {
            Product product = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Products WHERE Id=@ProductId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ProductId", productId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                product = new Product()
                                {   ID = int.Parse(reader["ProductId"].ToString()),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Image = reader["Image"].ToString(),
                                    UnitPrice = int.Parse(reader["UnitPrice"].ToString()),
                                    Quantity = int.Parse(reader["Quantity"].ToString()),
                                    Likes = int.Parse(reader["Likes"].ToString())
                                };
                            }
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

            return product;
        }

        public static Product Get(string productName)
        {
            Product product = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Products WHERE Title=@ProductName";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ProductName", productName));
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                product = new Product()
                                {
                                    ID = int.Parse(reader["ProductId"].ToString()),
                                    Title = reader["Title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Image = reader["Image"].ToString(),
                                    UnitPrice = int.Parse(reader["UnitPrice"].ToString()),
                                    Quantity = int.Parse(reader["Quantity"].ToString()),
                                    Likes = int.Parse(reader["Likes"].ToString())
                                };
                            }
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

            return product;
        }
    }
}
