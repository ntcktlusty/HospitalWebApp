using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HospitalWebApp.Models;
using HospitalWebApp.ApiModels;

namespace HospitalWebApp.App_Start
{
    public class AutoMapperApiProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<MealType, MealTypeApiModel>().ReverseMap();
            CreateMap<Meal, MealApiModel>().ReverseMap();
            CreateMap<Order, OrderApiModel>().ReverseMap();
            CreateMap<Patient, PatientApiModel>().ReverseMap();
            CreateMap<Station, StationApiModel>().ReverseMap();
        }
    }
}