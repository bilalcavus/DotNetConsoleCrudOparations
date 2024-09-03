using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotNetDapper
{
    internal class StudentCrudOperations
    {
        public void StudentAdd()
        {
            StudentRepo studentRepo = SqlStringAndStudentRepoCall();

            Console.WriteLine("Enter student name:");
            var studentName = Console.ReadLine();
            Console.WriteLine("Enter student grade ");
            var studentGrade = Console.ReadLine();  
            var student = new Student
            {
                student_name = studentName,
                student_grade = studentGrade
            };
            int student_id = studentRepo.InsertStudent(student);
            Console.WriteLine($"Student added with ID: {student_id}");
        }

        public void StudentDelete()
        {
            StudentRepo studentRepo = SqlStringAndStudentRepoCall();
            Console.WriteLine("Enter student id");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int studentId) && studentId > 0)
            {
                if (studentRepo.StudentsExists(studentId))
                {
                    studentRepo.DeleteStudent(studentId);
                    Console.WriteLine($"Student with ID: {studentId} has been deleted.");
                }
                else 
                {
                    Console.WriteLine($"Student with ID: {studentId} does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a valid positive numeric ID.");
            }
        }

        public void GetAllStudents()
        {
            StudentRepo studentRepo = SqlStringAndStudentRepoCall();
            Console.WriteLine("All of students: ");
            IEnumerable<Student> students = studentRepo.GetAllStudents();

            foreach (var item in students)
            {
                Console.WriteLine($"ID : {item.student_id}, Name: {item.student_name} Grade: {item.student_grade}");
            }
        }
        
        public void StudentUpdate()
        {
            StudentRepo studentRepo = SqlStringAndStudentRepoCall();
            Console.WriteLine("Enter the ID of the teacher you want to update: ");
            string inputId = Console.ReadLine();
          
            

            if (int.TryParse(inputId, out int studentID) && studentID > 0)
            {

                if (studentRepo.StudentsExists(studentID))
                {
                    Console.WriteLine("Enter the new name for the student: ");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("Enter the new student grade: ");
                    string inputGrade = Console.ReadLine();
                    if (int.TryParse(inputGrade , out int studentGrade) && studentGrade > 0)
                    {
                        studentRepo.UpdateStudent(studentID, studentName, studentGrade);
                        Console.WriteLine($"Student with ID: {studentID} has been updated with the new name: {studentName} and new grade: {studentGrade}");
                    }
                   
                }
                else
                {
                    Console.WriteLine($"Student with ID: {studentID} does not exist.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a valid positive numeric ID.");
            }
        }

        private StudentRepo SqlStringAndStudentRepoCall()
        {
            var connectionString = SqlStringConn();
            var studentRepo = new StudentRepo(connectionString);
            return studentRepo;
        }

        

        public string SqlStringConn()
        {
            return "Server=.\\SQLEXPRESS;Database=SchoolDatabase;User Id=sa;Password=admin;TrustServerCertificate=True;";
        }
    }
}
