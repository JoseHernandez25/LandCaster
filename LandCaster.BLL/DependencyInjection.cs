using LandCaster.BLL.ILogic;
using LandCaster.BLL.Logic;
using LandCaster.DAL;
using LandCaster.DAL.Repository;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entitites.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LandCaster.BLL
{
    public static class DependencyInjection
    {
        public static void RegisterBLLDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IManageLogic, ManageLogic>();

            // Registrar los repositorios
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();

            // Registrar la lógica de negocio
            services.AddScoped<IRoleLogic, RoleLogic>();
            services.AddScoped<IPermissionLogic, PermissionLogic>();

        }
    }
}
