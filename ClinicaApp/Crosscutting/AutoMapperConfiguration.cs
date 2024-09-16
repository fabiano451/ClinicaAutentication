using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ClinicaApp.Crosscutting
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(

                mc => 
                {
                    mc.AddProfile(new EntityToDTOMaper());
                    mc.AddProfile(new DTOToEntityMapper());

                });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
