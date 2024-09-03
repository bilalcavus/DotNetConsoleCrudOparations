using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDapper
{
    internal class StudentCoursesRepo
    {
        private readonly string _connectionString;
        public StudentCoursesRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        private SqlConnection GetOpenConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public int InsertSC(StudentCourse studentCourse) 
        {
            using var sqlConnection = GetOpenConnection();
            return sqlConnection.ExecuteScalar<int>("INSERT INTO studentCourses (student_id, course_id) VALUES(@student_id, @course_id)", studentCourse);
        }    
    }
}
