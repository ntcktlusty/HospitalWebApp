using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalWebApp.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void RegisterMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperApiProfile>();
                cfg.AddProfile<AutoMapperMvcProfile>();
            });

            Mapper = config.CreateMapper();
        }
    }
}