using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecctDemoYAM.Models
{
   public class Course
    {
        private int courseID;
        private string name;
        private int credit;

        public Course()
        {

        }
        public Course(int courseID, string name, int credit)
        {
            this.CourseID = courseID;
            this.Name = name;
            this.Credit = credit;
        }

        public int CourseID { get => courseID; set => courseID = value; }
        public string Name
        {
            get => name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Course name is empty.");
                }

                name = value;
            }
        }
        public int Credit
        {
            get => credit;
            set
            {

                if (value < 0 && value > 6)
                {
                    throw new Exception("Invalid course credit.");
                }
                credit = value;
            }
        }

        public int GetAllCourseCount()
        {
            try
            {
                string query = $"select COUNT(CourseID) Courses from Course";
                return int.Parse( dbHelper.ExecuteQuery(query).Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CourseAdd(Course obj)
        {
            try
            {
                if (CourseExists(obj.Name))
                {
                    throw new Exception("Course with same name exists");
                }

                string query = $"INSERT INTO Course(Name,Credit)VALUES('{obj.Name}',{obj.Credit})";
                return dbHelper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int CourseUpdate(Course obj)
        {
            try
            {
                string query = $"UPDATE Course SET Name='{obj.Name}',Credit={obj.Credit} WHERE CourseID={obj.CourseID}";
                return dbHelper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CourseDelete(int cID)
        {
            try
            {
                string query = $"Delete from Registration where CourseID={cID}; DELETE Course WHERE CourseID={cID}";
                return dbHelper.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetAllCourse()
        {
            try
            {
                string query = $"select * from Course";
                return dbHelper.ExecuteQuery(query);  
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllDeparments Error: " + ex.Message);
            }
        }

        public DataTable GetCourseN(int N)
        {
            try
            {
                string query = $"select TOP({N}) * from Course order by Name";
                return dbHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllDeparments Error: " + ex.Message);
            }
        }

        public Course GetCourseByID(int cID)
        {
            try
            {
                Course course = null;
              string query = $"select * from Course  where CourseID={cID}";
              var dt =  dbHelper.ExecuteQuery(query);
                if (dt.Rows.Count>0)
                {
                    course = new Course();
                    course.CourseID = int.Parse(dt.Rows[0]["CourseID"].ToString());
                    course.Name = dt.Rows[0]["Name"].ToString();
                    course.Credit = int.Parse(dt.Rows[0]["Credit"].ToString());
                }

                return course;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllDeparments Error: " + ex.Message);
            }
        }

        public List<Course> GetCourseByName(string name)
        {
            try
            {
                List<Course> list = new List<Course>();
                string query = $"select * from Course where Name LIKE '%{name}%' ORDER BY Name";
                var dt = dbHelper.ExecuteQuery(query);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Course course = new Course();
                    course.CourseID = int.Parse(dt.Rows[i]["CourseID"].ToString());
                    course.Name = dt.Rows[i]["Name"].ToString();
                    course.Credit = int.Parse(dt.Rows[i]["Credit"].ToString());

                    list.Add(course);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllDeparments Error: " + ex.Message);
            }
        }

        private bool CourseExists(string name)
        {
            try
            {
                List<Course> list = new List<Course>();
                string query = $"select * from Course where Name='{name}'";
                var dt = dbHelper.ExecuteQuery(query);
                if (dt.Rows.Count>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("GetAllDeparments Error: " + ex.Message);
            }
        }
    }
}
