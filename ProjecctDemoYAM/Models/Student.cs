using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

//ctrl + H
namespace ProjecctDemoYAM.Models
{
  public  class Student:Person
    {
        int studentID;
        int programID;
        int semesterID;
        public Student()
        {

        }

        public Student(int studentID, string firstName, string lastName, string gender, 
            string email, string password, string address, DateTime dateOfBirth, 
            int departmentID, int programID, int semesterID)
            :base(firstName, lastName, gender,email, password, address, dateOfBirth,
            departmentID)
        {
            this.studentID = studentID;
            this.studentID = studentID;
            this.programID = programID;
            this.semesterID = semesterID;
        }

        public int GetAllStudentCount()
        {
            try
            {
                string query = $"select COUNT(StudentID) Stds from Student";
                return int.Parse(dbHelper.ExecuteQuery(query).Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Display()
        {
            Console.WriteLine($"ID = {studentID} \tName = {FirstName} {LastName}\t Department = {DepartmentID}");
        }

        public override Person Login(string email, string password)
        {
            try
            {
                if (email == "std" && password == "123")
                {
                    Console.WriteLine("Welcome, Student.");
                }
                else
                {
                    Console.WriteLine("Username or password is incorrect.");

                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Login.");
            }
        }

        public DataTable GetAllStudents()
        {
            try
            {
                string connectionString = "Server=YUK-5CD8282ZY6;Database=SMS;Trusted_Connection=True;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                if (sqlConnection.State == ConnectionState.Open)
                {
                    string query = $"select * from Student";

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
