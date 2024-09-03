using Dapper;
using Microsoft.Data.SqlClient;
using System;

namespace DotNetDapper
{
    public class TeacherRepo
    {
        private readonly string _connectionString;

        public TeacherRepo(string connectionString)
        {
            _connectionString = connectionString;
        }


        private SqlConnection GetOpenConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public int InsertTeacher(Teacher teacher)
        {
            using var sqlConnection = GetOpenConnection(); 
            return sqlConnection.ExecuteScalar<int>("INSERT INTO teachers (teacher_name) " +
                "VALUES (@teacher_name); " +
                "SELECT SCOPE_IDENTITY();", teacher);
        }

        public void UpdateTeacher(int teacher_id, string teacher_name)
        {
            using var sqlConnection = GetOpenConnection();
            sqlConnection.Execute("UPDATE teachers " +
                "SET teacher_name = @teacher_name " +
                "WHERE teacher_id = @teacher_id", new {teacher_id,teacher_name});
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            using var sqlConnection = GetOpenConnection();
            return sqlConnection.Query<Teacher>("SELECT * FROM teachers");   
        }

        public void DeleteTeacher(int id)
        {
            using var sqlConnection = GetOpenConnection();
            sqlConnection.Execute("DELETE FROM Teachers " +
                "WHERE teacher_id = @teacher_id", new { teacher_id = id });
        }

        public bool TeacherExists(int teacher_id)
        {
            using var sqlConnection = GetOpenConnection();
            var result = sqlConnection.QuerySingleOrDefault<int>(
                "SELECT COUNT(1) " +
                "FROM teachers " +
                "WHERE teacher_id = @teacher_id",
                new { teacher_id }
            );
            return result > 0;
        }

    }


}