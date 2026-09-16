using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.DAL.Entites;
using SocialMedia.BLL.ModelVM.EmployeeVM;

namespace SocialMedia.BLL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, GetEmployeeVM>().ReverseMap();
            CreateMap<Employee, CreateEmployeeVM>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeVM>().ReverseMap();
            CreateMap<GetEmployeeVM, UpdateEmployeeVM>().ReverseMap();
        }
    }
}
