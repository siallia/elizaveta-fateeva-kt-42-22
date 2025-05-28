using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using elizaveta_fateeva_kt_42_22.Models;

namespace elizaveta_fateeva_kt_42_22.Tests
{
    public class DepartmentIntegrationTests
    {

        [Fact]
        public void IsValidDepartmentName_ValidName_True()
        {
            var department = new Department
            {
                DepartmentName = "Кафедра информатики"
            };
            var result = department.IsValidDepartmentName();
            Assert.True(result);
        }

        [Fact]
        public void IsValidDepartmentName_InvalidName_False()
        {
            var department = new Department
            {
                DepartmentName = "Кафедра ыавыав"
            };
            var result = department.IsValidDepartmentName();
            Assert.True(result);
        }
    }
}
