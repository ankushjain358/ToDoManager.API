﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.DataModel;
using ToDoManager.Models;

namespace ToDoManager.Infrastructure
{
    public class DBToDomainProfile : Profile
    {
        public DBToDomainProfile()
        {
            CreateMap<Tasks, TaskModel>();
            CreateMap<Categories, CategoryModel>()
                .ForMember(dest => dest.TaskList, opt => opt.MapFrom(src => src.Tasks));
        }
    }
}
