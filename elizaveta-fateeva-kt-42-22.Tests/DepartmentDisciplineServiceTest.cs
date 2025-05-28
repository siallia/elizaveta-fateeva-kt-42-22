using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using elizaveta_fateeva_kt_42_22.Database;
using elizaveta_fateeva_kt_42_22.Services;

namespace elizaveta_fateeva_kt_42_22.Tests
{
    public class DepartmentDisciplineServiceTest
    {

        [Collection("DbCollection")]
        public class Department2ServiceTests
        {
            private readonly DepartmentDbContext _ctx;

            public Department2ServiceTests(TestDbFixture fixture)
            {
                _ctx = fixture.Context;
            }

            [Fact]
            public async Task GetDisciplinesByHeadSurnameAsync_Head_AwaitTwoDisciplines()
            {
                var service = new DepartmentDisciplineService(_ctx);

                var cts = new CancellationTokenSource();
                CancellationToken token = cts.Token;

                var result = await service.GetDisciplinesByHeadSurnameAsync("Петров", token);
                Assert.Equal(2, result.Count);
            }
        }
    }
}
