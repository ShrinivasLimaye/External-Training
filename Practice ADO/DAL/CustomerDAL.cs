using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BOLayer;

namespace DAL
{
    public class CustomerDAL
    {
        private static string connectionString = string.Empty;

        static CustomerDAL()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ravit\source\repos\ECommerceSolution\EStore\App_Data\ECommerceDB.mdf;Integrated Security=True";
        }
        public static List<Customer> GetAll()
        {
            List<Customer> Customers = new List<Customer>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            string cmdString = "SELECT * FROM customers";
            SqlCommand cmd = new SqlCommand(cmdString, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow datarow in dt.Rows)
                {
                    int custID = int.Parse(datarow["Id"].ToString());
                    string firstName = datarow["firstName"].ToString();
                    string lastName = datarow["lastName"].ToString();
                    string email = datarow["Email"].ToString();
                    string city = datarow["City"].ToString();
                    string contactNo = datarow["ContactNumber"].ToString();
                    
                    Customer cust = new Customer
                    {
                        ID = custID,
                        FirstName = firstName,
                        LastName = lastName,
                        City = city,
                        Email = email,
                        ContactNumber = contactNo,
                    };
                    Customers.Add(cust);
                }
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return Customers;
        }
        public static Customer Get(int id)
        {
            Customer cst = null;
            List<Customer> Customers = new List<Customer>();

            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            string txtCommand = "SELECT * FROM Customers WHERE id=" + id;
            SqlCommand cmd = new SqlCommand(txtCommand, con as SqlConnection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = dt.Columns["Id"];
                dt.PrimaryKey = keyColumns;

                DataRow datarow = ds.Tables[0].Rows.Find(id);

                string empid = datarow["Id"].ToString();
                string firstName = datarow["FirstName"].ToString();
                string lastName = datarow["LastName"].ToString();
                string email = datarow["Email"].ToString();
                string contactNo = datarow["ContactNumber"].ToString();
                string city = datarow["City"].ToString();

                cst = new Customer
                {

                    ID = int.Parse(empid),
                    FirstName = firstName,
                    LastName = lastName,
                    City = city,
                    Email = email,
                    ContactNumber = contactNo,

                };
           }
            catch (SqlException exp)
            {
                throw exp;
            }

            return cst;
        }
        public static List<Customer> GetByCity(string city)
        {
            List<Customer> Customers = new List<Customer>();

            IDbConnection con = new SqlConnection(connectionString);
            string txtCommand = "SELECT * FROM Customers WHERE City=" + city;
            SqlCommand cmd = new SqlCommand(txtCommand, con as SqlConnection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);

                DataTable dt = ds.Tables["customers"];

                foreach (DataRow row in dt.Rows)
                {
                    int custID = int.Parse(row["Id"].ToString());
                    string firstName = row["FirstName"].ToString();
                    string lastName = row["LastName"].ToString();
                    string contactNo = row["ContactNumber"].ToString();
                    string email = row["Email"].ToString();
                    city = row["City"].ToString();

                    Customer cst = new Customer
                    {
                        ID = custID,
                        FirstName = firstName,
                        LastName = lastName,
                        City = city,
                        Email = email,
                        ContactNumber = contactNo
                    };

                    Customers.Add(cst);
                }

            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
                throw exp;
            }

            return Customers;
        }

        public static List<Customer> GetCustomersParam(string city)

        {
            List<Customer> allCustomers = new List<Customer>();

            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;

            //1.Define Parameterised Query
            string cmdStr = @"select * from Customers where City = @City";

            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con as SqlConnection;
            cmd.CommandText = cmdStr;

            // 2. define parameters used in command object
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@City";
            param.DbType = DbType.String;
            param.Value = city;

            // 3. add new parameter to command object
            cmd.Parameters.Add(param);
            // get data stream

            //Disconnected Data Access
            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }


            DataTable dt = ds.Tables["Customers"];
            foreach (DataRow datarow in dt.Rows)
            {
                int custID = int.Parse(datarow["Id"].ToString());
                string firstName = datarow["FirstName"].ToString();
                string lastName = datarow["LastName"].ToString();
                string email = datarow["Email"].ToString();
                string custCity = datarow["City"].ToString();
                string contactNo = datarow["ContactNumber"].ToString();

                Customer cst = new Customer
                {
                    ID = custID,
                    FirstName = firstName,
                    LastName = lastName,
                    City = custCity,
                    Email = email,
                    ContactNumber = contactNo
                };

                allCustomers.Add(cst);
            }
            return allCustomers;
        }
        public static bool Insert(Customer cust)
        {
            bool status = false;
            List<Customer> custo = new List<Customer>();
            using (SqlConnection sqlcon = new SqlConnection(connectionString)) 
            {
                sqlcon.Open();
                string query = ("INSERT INTO customers VALUES(@customerID,@firstName,@lastName,@email,@registrationDate,@state,@officeCity");
                SqlCommand cmd = new SqlCommand(query,sqlcon);
                cmd.Parameters.AddWithValue("@customerID",cust.ID);
                cmd.Parameters.AddWithValue("@firstName",cust.FirstName);
                cmd.Parameters.AddWithValue("@lastName",cust.LastName);
                cmd.Parameters.AddWithValue("@email",cust.Email);
                cmd.Parameters.AddWithValue("@registrationDate",cust.RegistrationDate);
                cmd.Parameters.AddWithValue("@state",cust.Location);
                cmd.Parameters.AddWithValue("@officeCity",cust.City);
                status = true;

            return status;
        }


        //    bool status = false;

        //    IDbConnection con = new SqlConnection();
        //    con.ConnectionString = connectionString;

        //    //1.Define Parameterised Query

        //    string cmdStr = "select * from Customers";
        //    IDbCommand cmd = new SqlCommand();
        //    cmd.Connection = con as SqlConnection;
        //    cmd.CommandText = cmdStr;

        //    //Disconnected Data Access
        //    SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        SqlCommandBuilder cmdBldr = new SqlCommandBuilder(da);
        //        da.Fill(ds);

        //        //Creating empty record
        //        DataRow newRow = ds.Tables[0].NewRow();
        //        newRow["Id"] = cust.ID;
        //        newRow["FirstName"] = cust.FirstName;
        //        newRow["LastName"] = cust.LastName;
        //        newRow["Email"] = cust.Email;
        //        newRow["City"] = cust.City;
             
        //        // add new record in  exsting data rows
        //        ds.Tables[0].Rows.Add(newRow);

        //        //update changes back to database using batch operations
        //        da.Update(ds);
        //        status = true;

        //    }
        //    catch (SqlException exp)
        //    {
        //        string exceptionMessage = exp.Message;
        //    }
        //    return status;
        //}
        //public static bool Update(Customer cstupdate)
        //{
        //    bool status = false;

        //    List<Customer> allCustomers = new List<Customer>();

        //    IDbConnection con = new SqlConnection();
        //    con.ConnectionString = connectionString;

        //    IDbCommand cmd = new SqlCommand();
        //    cmd.CommandText = "SELECT * FROM Customers";
        //    cmd.Connection = con;

        //    SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        SqlCommandBuilder cmdbldr = new SqlCommandBuilder(da);
        //        da.Fill(ds);

        //        DataColumn[] keyColumns = new DataColumn[1];
        //        keyColumns[0] = ds.Tables[0].Columns["Id"];
        //        ds.Tables[0].PrimaryKey = keyColumns;

        //        DataRow datarow = ds.Tables[0].Rows.Find(cstupdate.ID);

        //        datarow["FirstName"] = cstupdate.FirstName;
        //        datarow["LastName"] = cstupdate.LastName;
        //        datarow["Email"] = cstupdate.Email;
        //        datarow["City"] = cstupdate.City;
               
        //        da.Update(ds);
        //    }
        //    catch (SqlException exp)
        //    {
        //        string exceptionMessage = exp.Message;
        //    }
        //    return status;


        }
        public static bool Delete(Customer cst)
        {
            bool status = false;

            List<Customer> allCustomers = new List<Customer>();

            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;

            IDbCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Customers";
            cmd.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();

            try
            {
                SqlCommandBuilder cmdbldr = new SqlCommandBuilder(da);
                da.Fill(ds);

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["Id"];
                ds.Tables[0].PrimaryKey = keyColumns;

                DataRow datarow = ds.Tables[0].Rows.Find(cst.ID);
                datarow.Delete();
                da.Update(ds);
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return status;
        }
    }
}
