using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDapper
{
    public class StudentRepo
    {
        private readonly string _connectionString;

        public StudentRepo(string connectionString) 
        {
            _connectionString = connectionString;   
        }

        private SqlConnection GetOpenConnection() 
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public int InsertStudent(Student student)
        {
            using var sqlConnection = GetOpenConnection();
            return sqlConnection.ExecuteScalar<int>("INSERT INTO students (student_name, student_grade) " +
                "VALUES (@student_name, @student_grade); " +
                "SELECT SCOPE_IDENTITY();",student);
        }

        public void UpdateStudent(int student_id, string student_name, int student_grade)
        {
            using var sqlConnection = GetOpenConnection();
            sqlConnection.Execute("UPDATE students " +
                "SET student_name = @student_name , student_grade = @student_grade " +
                "WHERE student_id = @student_id", new { student_id, student_name, student_grade });
        }

        public IEnumerable<Student> GetAllStudents()
        {
            using var sqlConnection = GetOpenConnection();
            return sqlConnection.Query<Student>("SELECT * FROM students");
        }

        public void DeleteStudent(int id)
        {
            using var sqlConnection = GetOpenConnection();
            sqlConnection.Execute("DELETE FROM students " +
                "WHERE student_id = @student_id", new { student_id = id });
        }

        public bool StudentsExists(int student_id)
        {
            using var sqlConnection = GetOpenConnection();
            var result = sqlConnection.QuerySingleOrDefault<int>(
                "SELECT COUNT(1) " +
                "FROM students " +
                "WHERE student_id = @student_id",
                new { student_id }
            );
            return result > 0;
        }

    }
}
