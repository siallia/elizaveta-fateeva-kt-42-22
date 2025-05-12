using System.Text.Json.Serialization;

namespace elizaveta_fateeva_kt_42_22.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }


        public int Year { get; set; }

        public int? HeadOfDepartmentId { get; set; }
        
        [JsonIgnore] 
        public Teacher? HeadOfDepartment { get; set; }

    }
}
