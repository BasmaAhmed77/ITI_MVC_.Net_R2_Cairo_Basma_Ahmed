using SocialMedia.BLL.ModelVM.EmployeeVM;
using SocialMedia.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.BLL.Services.Abstraction
{
    public interface IEmployeeService
    {
        bool Create(CreateEmployeeVM empVM);
        void Update(UpdateEmployeeVM empVM); 
        void Delete(int id); 
        GetEmployeeVM GetById(int Id);
        List<GetEmployeeVM> GetAll();

    }
}
