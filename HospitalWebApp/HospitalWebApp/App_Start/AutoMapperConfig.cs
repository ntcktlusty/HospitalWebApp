using AutoMapper;

namespace HospitalWebApp.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.AddProfile<AutoMapperApiProfile>();
                cfg.AddProfile<AutoMapperMvcProfile>();
            });
        }
    }
}