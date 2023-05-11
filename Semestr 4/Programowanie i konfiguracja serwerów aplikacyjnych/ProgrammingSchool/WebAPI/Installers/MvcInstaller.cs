using Application;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;

namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            // W każdej warstwie rejestrujemy serwisy dotyczące bezpośrednio danej warstwy
            // Do pozostałych serwisów (np. związanych z framework'iem lub zewnętrznymi bibliotekami) tworzymy dedykowane instalatory w warstwie prezentacji
            services.AddApplication();
            services.AddInfrastructure();
            services.AddControllers();
        }
    }
}
