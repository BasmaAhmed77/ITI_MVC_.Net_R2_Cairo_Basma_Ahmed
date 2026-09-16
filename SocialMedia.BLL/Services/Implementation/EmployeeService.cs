using AutoMapper;
using SocialMedia.BLL.Helper;
using SocialMedia.BLL.ModelVM.EmployeeVM;
using SocialMedia.BLL.Services.Abstraction;
using SocialMedia.DAL.Entites;
using SocialMedia.DAL.Repo.Abstraction;
using SocialMedia.DAL.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.BLL.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo Repo;
        private readonly IMapper mapper;

        public EmployeeService(IEmployeeRepo _Repo, IMapper _mapper)
        {
            Repo = _Repo;
            mapper = _mapper;
        }

        public List<GetEmployeeVM> GetAll()
        {
            var data = Repo.GetAll(x => true);
            var AllEmpVM = mapper.Map<List<GetEmployeeVM>>(data);
            return AllEmpVM;
        }

        public GetEmployeeVM GetById(int Id)
        {
            var data = Repo.GetbyId(Id);
            var mapped = mapper.Map<GetEmployeeVM>(data);
            return mapped;
        }


        public bool Create(CreateEmployeeVM empVM)
        {
            if (empVM.Image != null)
            {
                empVM.PathImage = Upload.UploadFile("Files", empVM.Image);
            }
            var map = mapper.Map<Employee>(empVM);
            return Repo.Create(map);
        }

        public void Update(UpdateEmployeeVM empVM)
        {
            var existingEmp = Repo.GetbyId(empVM.EmployeeId);
            if (existingEmp == null) return;

            if (empVM.Image != null)
            {
                if (!string.IsNullOrEmpty(existingEmp.PathImage))
                {
                    Upload.RemoveFile("Files", existingEmp.PathImage);
                }
                existingEmp.PathImage = Upload.UploadFile("Files", empVM.Image);
            }

            existingEmp.Name = empVM.Name;
            existingEmp.Age = empVM.Age;
            existingEmp.DepartmentId = empVM.DepartmentId;

            Repo.Update(existingEmp);
        }

        public void Delete(int id)
        {
            var emp = Repo.GetbyId(id);
            if (emp != null)
            {
                if (!string.IsNullOrEmpty(emp.PathImage))
                {
                    Upload.RemoveFile("Files", emp.PathImage);
                }
                Repo.Delete(emp);
            }
        }
    }
}
