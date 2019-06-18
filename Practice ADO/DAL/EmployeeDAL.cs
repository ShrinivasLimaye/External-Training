using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BOLayer;

namespace DAL
{
    public class EmployeeDAL
    {
        private static string connectionString = string.Empty;

        static EmployeeDAL()
        {
            connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\.Net Training\Practice ADO\Practice ADO\App_Data\Database1.mdf;Integrated Security=True";
        }
        public static List<Employee> GetAll()
        {
            List<Employee> Employees = new List<Employee>();
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            string cmdString = "SELECT * FROM employees";
            IDbCommand cmd = new SqlCommand(cmdString, con as SqlConnection);

            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                DataTable dt = ds.Tables[0];
                foreach (DataRow datarow in dt.Rows)
                {
                    int id = int.Parse(datarow["Id"].ToString());
                    string name = datarow["Name"].ToString();
                    string gender = datarow["Gender"].ToString();
                    string city = datarow["City"].ToString();
                    string email = datarow["Email"].ToString();
                    int age =int.Parse (datarow["Age"].ToString());
                

                    Employee emp = new Employee
                    {
                        Id = id,
                        Email = email,
                        FullName = name,
                        Gender = gender,
                        Age =  age,
                        City=city
                    };
                    Employees.Add(emp);
                }
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return Employees;
        }
        public static Employee Get(int id)
        {
           Employee emp = null;
            
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            string txtCommand = "SELECT * FROM Employees WHERE id=" + id;
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

                int empId = int.Parse(datarow["Id"].ToString());
                string email = datarow["Email"].ToString();
                string fullName = datarow["FullName"].ToString();
                string contactNumber = datarow["ContactNumber"].ToString();
                string designation = datarow["Designation"].ToString();
                DateTime joinDate = Convert.ToDateTime(datarow["JointDate"].ToString());

                 emp = new Employee
                {
                    Id = empId,
                    Email = email,
                    FullName = fullName,
                    ContactNumber = contactNumber,
                    Designation = designation,
                    JoinDate = joinDate
                };
 
           }
            catch (SqlException exp)
            {
                throw exp;
            }

            return emp;
        }
        public static bool Insert(Employee emp)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO employees(Name,Gender,City,Email,Age)"+" VALUES (@Name, @Gender, @City, @Email, @Age)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@Name", emp.FullName));
                    cmd.Parameters.Add(new SqlParameter("@Gender", emp.Gender));
                    cmd.Parameters.Add(new SqlParameter("@City", emp.City));
                    cmd.Parameters.Add(new SqlParameter("@Email", emp.Email));
                    cmd.Parameters.Add(new SqlParameter("@Age", emp.Age));
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
        public static bool Update(Employee cstupdate)
        {
            bool status = false;
            ///
            //
            
            return status;


        }
        public static bool Delete(int id)
        {
            bool status = false;

            List<Employee> allEmployees = new List<Employee>();

            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;

            IDbCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Employees";
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

                DataRow datarow = ds.Tables[0].Rows.Find(id);
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
