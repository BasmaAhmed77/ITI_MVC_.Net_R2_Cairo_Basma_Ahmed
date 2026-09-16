using SocialMedia.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        bool Create(Employee emp);
        void Update(Employee emp); 
        void Delete(Employee emp); 
        List<Employee> GetAll(Expression<Func<Employee, bool>> filter);
        Employee GetbyId(int id);
    }
}
