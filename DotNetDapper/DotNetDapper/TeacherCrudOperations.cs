using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotNetDapper
{
    internal class TeacherCrudOperations
    {
        public void TeacherAdd()
        {
            var connectionString = SqlStringConn();
            var teacherRepo = new TeacherRepo(connectionString);
            Console.WriteLine("Enter the teacher name:");
            var teacherName = Console.ReadLine();
            var teacher = new Teacher
            {
                teacher_name = teacherName
            };

            int teacher_id = teacherRepo.InsertTeacher(teacher);
            Console.WriteLine($"Teacher added with ID: {teacher_id}");

        }

        public void GetTeacherList()
        {
            var connectionString = SqlStringConn();
            var teacherRepo = new TeacherRepo(connectionString);
            Console.WriteLine("All of the teachers: ");
            IEnumerable<Teacher> teachers = teacherRepo.GetAllTeachers();

            foreach (var item in teachers)
            {
                Console.WriteLine($"ID : {item.teacher_id}, Name: {item.teacher_name}");
            }

        }

        public void TeacherUpdate()
        {
            var connectionString = SqlStringConn();
            var teacherRepo = new TeacherRepo(connectionString);

            Console.WriteLine("Enter the ID of the teacher you want to update:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int teacherID) && teacherID > 0)
            {
                
                if (teacherRepo.TeacherExists(teacherID))
                {
                    Console.WriteLine("Enter the new name for the teacher:");
                    string teacherName = Console.ReadLine();

                   
                    teacherRepo.UpdateTeacher(teacherID, teacherName);
                    Console.WriteLine($"Teacher with ID: {teacherID} has been updated with the new name: {teacherName}");
                }
                else
                {
                    Console.WriteLine($"Teacher with ID: {teacherID} does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a valid positive numeric ID.");
            }
        }




        public void TeacherDelete()
        {
            var connectionString = SqlStringConn();
            var teacherRepo = new TeacherRepo(connectionString);

            Console.WriteLine("Write the ID number of the teacher that you want to delete:");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int teacherID) && teacherID > 0)
            {
                if (teacherRepo.TeacherExists(teacherID))
                {
                    teacherRepo.DeleteTeacher(teacherID);
                    Console.WriteLine($"Teacher with ID: {teacherID} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Teacher with ID: {teacherID} does not exist.");

                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a valid positive numeric ID.");
            }
        }

        public string SqlStringConn()
        {
            return "Server=.\\SQLEXPRESS;Database=SchoolDatabase;User Id=sa;Password=admin;TrustServerCertificate=True;";
        }

    }
}
