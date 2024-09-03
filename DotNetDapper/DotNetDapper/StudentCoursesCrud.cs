using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDapper
{
    internal class StudentCoursesCrud
    {
        public void InsertSc()
        {
            var connectionString = SqlStringConn();
            var studentCoursesRepo = new StudentCoursesRepo(connectionString);
            Console.WriteLine("Enter the course id: ");
            var courseIdInput = Console.ReadLine();
            Console.WriteLine("enter the student id");
            var studentIdInput = Console.ReadLine();

       
            var studentCourse = new StudentCourse();

        }



        public string SqlStringConn()
        {
            return "Server=.\\SQLEXPRESS;Database=SchoolDatabase;User Id=sa;Password=admin;TrustServerCertificate=True;";
        }
    }


 
}
