﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SchoolCS")));
        }
    }
}
