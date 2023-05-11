using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        // Klasa odpowiada za poprawne wywołanie zdefiniowanych przez nas mapowań
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            // Fragment kodu odpowiada za wyszukanie w projekcie wszystkich klas Dto, utworzenie ich instancji, a następnie wywołanie metody Mapping w przypadku użycia danego mapowania
            var types = assembly.GetExportedTypes().Where(x => 
                typeof(IMap).IsAssignableFrom(x) && !x.IsInterface).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }

    }
}
