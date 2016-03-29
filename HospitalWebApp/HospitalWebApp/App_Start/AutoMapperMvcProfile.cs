using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using HospitalWebApp.Models;
using HospitalWebApp.ViewModels;

namespace HospitalWebApp.App_Start
{
    public class AutoMapperMvcProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<MealType, MealTypeView>().ReverseMap();
        }
    }
}