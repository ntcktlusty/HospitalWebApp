using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;


namespace HospitalWebApp
{

    public class Global : HttpApplication
    {
        public static AutoMapper.IMapper mapper { get; set; }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            var config = new AutoMapper.MapperConfiguration(cfg => {
                cfg.CreateMap<Models.Meal,ViewModels.MealView>();
                cfg.CreateMap<Models.Order, ViewModels.OrderView>();
                cfg.CreateMap<Models.Patient, ViewModels.PatientView>();
                cfg.CreateMap<Models.Station, ViewModels.StationView>();
                cfg.CreateMap<Models.MealType, ViewModels.MealTypeView>();

                cfg.CreateMap<ViewModels.MealView,Models.Meal>();
                cfg.CreateMap<ViewModels.OrderView,Models.Order>();
                cfg.CreateMap< ViewModels.PatientView,Models.Patient>();
                cfg.CreateMap<ViewModels.StationView,Models.Station>();
                cfg.CreateMap<ViewModels.MealTypeView,Models.MealType>();
            });

            mapper = config.CreateMapper();
        }
    }
}