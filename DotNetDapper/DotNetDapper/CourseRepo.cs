using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDapper
{
    public class CourseRepo
    {
        private readonly string _connectionString;
        public CourseRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetOpenConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public int InsertCourse(Course course)
        {
            using var sqlConnection = GetOpenConnection();
            return sqlConnection.ExecuteScalar<int>("INSERT INTO courses(course_name , teacher_id) " +
                "VALUES (@course_name, @teacher_id)",course);
        }
        public int DeleteCourse(int id)
        {
            using var sqlConnection = GetOpenConnection();
            return sqlConnection.Execute("DELETE FROM courses" +
                "WHERE course_id = @course_id " ,new { course_id = id});
        }
        public int UpdateCourse(int course_id , string course_name , int teacher_id) 
        { 
            using var sqlConnection = GetOpenConnection();
            return sqlConnection.Execute("UPDATE courses " +
                "SET course_name = @course_name , teacher_id = @teacher_id " +
                "WHERE course_id = @course_id", new {course_id, course_name, teacher_id});
        
        }
        public IEnumerable<Course> GetAllCourses()
        {
            using var sqlConnection = GetOpenConnection();
            return sqlConnection.Query<Course>("SELECT * FROM courses");
        }

        public bool CoursesExists(int course_id)
        {
            using var sqlConnection = GetOpenConnection();
            var result = sqlConnection.QuerySingleOrDefault<int>(
                "SELECT COUNT(1) " +
                "FROM students " +
                "WHERE course_id = @course_id",
                new { course_id }
            );
            return result > 0;
        }
    }
}
