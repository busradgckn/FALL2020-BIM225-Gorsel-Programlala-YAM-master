using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecctDemoYAM.Models
{
    public class Department
    {
        int departmentID;
        string name;

        public Department()
        {

        }
        public static int GetAllDepartmentCount()
        {
            try
            {
                string query = $"select COUNT(DepartmentID) Departs from Department";
                return int.Parse(dbHelper.ExecuteQuery(query).Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Department(int departmentID, string name)
        {
            this.departmentID = departmentID;
            this.name = name;
        }

        public void Display()
        {
            Console.WriteLine($"ID = {departmentID}, Name  = {name}");
        }

        public DataTable GetAllDeparments()
        {
            try
            {
                string connectionString = "Server=YUK-5CD8282ZY6;Database=SMS;Trusted_Connection=True;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                if (sqlConnection.State == ConnectionState.Open)
                {
                    string query = $"select * from Department";

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
