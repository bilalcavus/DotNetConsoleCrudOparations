using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;

namespace DotNetDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TeacherCrudOperations crudOps = new TeacherCrudOperations();
            //crudOps.TeacherAdd();
            //crudOps.GetTeacherList();
            //crudOps.TeacherDelete();
            //crudOps.TeacherUpdate();

            StudentCrudOperations studentCrudOperations = new StudentCrudOperations();
            studentCrudOperations.StudentAdd();
            studentCrudOperations.GetAllStudents();
        }
    }
}
