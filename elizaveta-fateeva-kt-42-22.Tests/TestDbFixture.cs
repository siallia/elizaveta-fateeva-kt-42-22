using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using elizaveta_fateeva_kt_42_22.Database;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Tests
{
    public class TestDbFixture : IDisposable
    {
        public DepartmentDbContext Context { get; }

        public TestDbFixture()
        {
            var options = new DbContextOptionsBuilder<DepartmentDbContext>()
                .UseInMemoryDatabase("Tests")
                .Options;

            Context = new DepartmentDbContext(options);

            if (!Context.Teachers.Any())
            {
                var department = new Department { DepartmentId = 1, DepartmentName = "1" , HeadOfDepartmentId = 1};
                var department2 = new Department { DepartmentId = 2, DepartmentName = "2", HeadOfDepartmentId = 2 };
                var position = new Position { PositionId = 1, PositionName = "Профессор" };
                var position2 = new Position { PositionId = 2, PositionName = "Доцент" };

                var teacher = new Teacher
                {
                    TeacherId = 1,
                    TeacherName = "Иванов",
                    PositionId = 2,
                    DepartmentId = 1
                };
                var teacher2 = new Teacher
                {
                    TeacherId = 2,
                    TeacherName = "Петров",
                    PositionId = 1,
                    DepartmentId = 2
                };
                var teacher3 = new Teacher
                {
                    TeacherId = 3,
                    TeacherName = "Сидоров",
                    PositionId = 1,
                    DepartmentId = 2
                };

                var discipline1 = new Discipline
                { 
                    DisciplineId = 1 ,
                    DisciplineName = "Мат анализ"
                };

                var discipline2 = new Discipline
                {
                    DisciplineId = 2,
                    DisciplineName = "Информатика"
                };

                var studyLoad1 = new StudyLoad
                {
                    StudyLoadId = 1,
                    TeacherId = 1,
                    DisciplineId = 1,
                    hours = 10
                };

                var studyLoad2 = new StudyLoad
                {
                    StudyLoadId = 2,
                    TeacherId = 2,
                    DisciplineId = 1,
                    hours = 10
                };

                var studyLoad3 = new StudyLoad
                {
                    StudyLoadId = 3,
                    TeacherId = 3,
                    DisciplineId = 2,
                    hours = 20
                };



                Context.Departments.AddRange(department, department2);
                Context.Positions.AddRange(position, position2);
                Context.Teachers.AddRange(teacher, teacher2, teacher3);

                Context.Disciplines.AddRange(discipline1, discipline2);
                Context.StudyLoads.AddRange(studyLoad1, studyLoad2, studyLoad3);

                Context.SaveChanges();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
