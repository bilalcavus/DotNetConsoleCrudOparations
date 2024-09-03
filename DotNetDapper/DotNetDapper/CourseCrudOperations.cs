using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDapper
{
    internal class CourseCrudOperations
    {
        public void AddCourse()
        {
            var connectionString = SqlStringConn();
            var courseRepo = new CourseRepo(connectionString);
            Console.WriteLine("Enter the course name: ");
            var courseName = Console.ReadLine();
            Console.WriteLine("enter the teacher id");
            var teacherIdInput = Console.ReadLine();

            if (int.TryParse(teacherIdInput, out int teacherId))
            {
                var course = new Course()
                {
                    course_name = courseName,
                    teacher_id = teacherId

                };
                int course_id = courseRepo.InsertCourse(course);
                Console.WriteLine($"Course added with ID: {course_id}");
            }
            else
            {
                Console.WriteLine("error");
            }

        }







        public string SqlStringConn()
        {
            return "Server=.\\SQLEXPRESS;Database=SchoolDatabase;User Id=sa;Password=admin;TrustServerCertificate=True;";
        }
    }
}
