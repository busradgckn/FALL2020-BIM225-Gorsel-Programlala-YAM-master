using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjecctDemoYAM.Models
{
    class Registeration
    {
        int studentID;
        int courseID;
        DateTime registrationDate;

        public Registeration(int studentID, int courseID, DateTime registrationDate)
        {
            this.studentID = studentID;
            this.courseID = courseID;
            this.registrationDate = registrationDate;
        }
    }
}
