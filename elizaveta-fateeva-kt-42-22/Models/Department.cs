using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

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
        public bool IsValidDepartmentName()
        {
            var regex = new Regex(@"^Кафедра [а-яё0-9№.,«»""–—\-'\/s]+(имени [А-ЯЁA-Z][а-яёa-zA-ZЁ\-\. ]+)?$");
            return regex.IsMatch(DepartmentName);
        }
    }
}
