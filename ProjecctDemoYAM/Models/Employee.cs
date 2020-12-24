using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ProjecctDemoYAM.Models
{
    // bi object ve birden fazla parent: Multiple Inheritance
    //C# multiple inheritance izin verimiyor
    // multi-level inheritance
   public class Employee:Person
    {
        int employeeID;
        float salary;
        string role;
        float tax;
        public Employee()
        {
            //Console.WriteLine("In Employee Constructor.");
        }

        public static int GetAllEmployeeCount()
        {
            try
            {
                string query = $"select COUNT(EmployeeID) Emps from Employee";
                return int.Parse(dbHelper.ExecuteQuery(query).Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Employee(string firstName, string lastName, string gender, string email, 
            string password, string address, DateTime dateOfBirth, int departmentID,
            int employeeID, float salary, string role, float tax) 
            : base(firstName, lastName, gender, email, password, address, dateOfBirth, departmentID)
        {
            this.EmployeeID = employeeID;
            this.Salary = salary;
            this.Role = role;
            this.Tax = tax;
        }

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public float Salary { get => salary; set => salary = value; }
        public string Role { get => role; set => role = value; }
        public float Tax { get => tax; set => tax = value; }

        public override Person Login(string email, string password)
        {
            try
            {
                string connectionString = "Server=YUK-5CD8282ZY6;Database=SMS;Trusted_Connection=True;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                if (sqlConnection.State ==ConnectionState.Open)
                {
                    string query = $"select EmployeeID, FirstName +' ' + LastName as Name,Email from employee " +
                        $"where Email = '{email}' AND Password = '{password}'";
                    
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);

                    if (dt.Rows.Count>0)
                    {
                        Employee emp = new Employee();
                        emp.EmployeeID = int.Parse( dt.Rows[0]["EmployeeID"].ToString());
                        emp.FirstName = dt.Rows[0]["Name"].ToString();
                        emp.Email= dt.Rows[0]["Email"].ToString();

                        return emp;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    throw new Exception("Failed to connect to Database.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Log In Error: " + ex.Message);
            }
        }

        public DataTable GetAllEmployees()
        {
            try
            {
                string connectionString = "Server=YUK-5CD8282ZY6;Database=SMS;Trusted_Connection=True;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                if (sqlConnection.State == ConnectionState.Open)
                {
                    string query = $"select e.EmployeeID,e.FirstName,e.LastName,e.Email,d.Name  as DepartmentName " +
                        $"from employee e JOIN  Department d ON d.DepartmentID = e.DepartmentID";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                    adapter.Fill(dt);

                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Log In Error: " + ex.Message);
            }
        }
    }
    
}
