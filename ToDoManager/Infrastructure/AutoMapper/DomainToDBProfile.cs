using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoManager.DataModel;
using ToDoManager.Models;

namespace ToDoManager.Infrastructure
{
    public class DomainToDBProfile : Profile
    {
        public DomainToDBProfile()
        {
            CreateMap<CreateUpdateTaskModel, Tasks>().AfterMap((src, dest) =>
            {
                dest.CreatedOn = DateTime.Now;
            });
            CreateMap<CreateUpdateCategoryModel, Categories>();
        }
    }
}
