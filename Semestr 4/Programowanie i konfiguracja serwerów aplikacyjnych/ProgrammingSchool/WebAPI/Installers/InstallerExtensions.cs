namespace WebAPI.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration) 
        { 
            // Fragment kodu jest odpowiedzialny za wyszukanie w projekcie wszystkich klas z instalatorami, utworzenie ich instancji, a następnie wywołanie metody InstallServices z odpowiednim argumentem
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }

    }
}
