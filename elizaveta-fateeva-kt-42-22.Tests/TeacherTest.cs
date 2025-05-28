

using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Tests
{
    public class TeacherTest
    {
        [Fact]
        public void IsValidTeacherName_True()
        {
            var testTeacher = new Teacher
            {
                TeacherId = 1,
                TeacherName = "Петров"
            };

            var result = testTeacher.IsTeacherNameValid();

            Assert.True(result);    
        }
    }
}