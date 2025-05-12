using System.Text.Json.Serialization;

namespace elizaveta_fateeva_kt_42_22.Models
{
    public class StudyLoad
    {
        public int StudyLoadId { get; set; }

        public int TeacherId {  get; set; }

        [JsonIgnore] public Teacher? Teacher { get; set; }    

        public int DisciplineId { get; set; }

        [JsonIgnore] public Discipline? Discipline { get; set; }  

        public int hours { get; set; }

    }
}
