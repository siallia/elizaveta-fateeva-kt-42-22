using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace elizaveta_fateeva_kt_42_22.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

        public int? DepartmentId { get; set; }

        [JsonIgnore] public Department? Department { get; set; }  

        public int DegreeId { get; set; }

        [JsonIgnore]  public Degree? Degree { get; set; }

        public int PositionId { get; set; }

        [JsonIgnore] public Position? Position { get; set; }

        [JsonIgnore] public Department? ManagedDepartment { get; set; }

        public bool IsTeacherNameValid()
        {

            return !string.IsNullOrEmpty(TeacherName) && Regex.IsMatch(TeacherName, @"^[A-ZА-Я][a-zа-яё]*$");
        }
    }
}
