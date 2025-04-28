using System.ComponentModel.DataAnnotations.Schema;

namespace elizaveta_fateeva_kt_42_22.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }  

        public int DegreeId { get; set; }

        public Degree Degree { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public Department ManagedDepartment { get; set; }
    }
}
