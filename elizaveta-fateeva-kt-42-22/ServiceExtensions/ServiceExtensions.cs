using elizaveta_fateeva_kt_42_22.Interfaces;
using elizaveta_fateeva_kt_42_22.Services;

namespace elizaveta_fateeva_kt_42_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IDisciplineService, DisciplineService>();
            services.AddScoped<IStudyLoadService, StudyLoadService>();
            return services;
        }
    }
}
