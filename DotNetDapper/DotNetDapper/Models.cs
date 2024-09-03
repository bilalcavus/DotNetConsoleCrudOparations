using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDapper
{

    public class Teacher : ITeacherId
    {
        public string teacher_name { get; set; }
        public int teacher_id { get; set; }


    }

    public class Student : IStudentId
    {
        public string student_name { get; set; }
        public string student_grade { get; set; }
        public int student_id { get; set; }
    }

    public class Course : ITeacherId
    {
        public string course_name { get; set; }
        public int course_id { get; set; }
        public int teacher_id { get; set; }

    }

    public class StudentCourse : IStudentId, ICourseId
    {
        public int scId { get; set; }
        public int student_id { get; set; }
        public int course_id { get; set; }

    }



    public interface IStudentId
    {
        int student_id { get; set; }
    }

    public interface ITeacherId
    {
        int teacher_id { get; set; }
    }

    public interface ICourseId
    {
        int course_id { get; set; }
    }
}