using System;
using SocialMedia.DAL.Repo.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMedia.DAL.Entites;
using System.Linq.Expressions;
using SocialMedia.DAL.Database;

namespace SocialMedia.DAL.Repo.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly SocialMediaDbContext db;
        
        public EmployeeRepo(SocialMediaDbContext _db)
        {
            db = _db;
        }
        public bool Create(Employee emp)
        {
            try
            {
                var result = db.Employees.Add(emp);
                db.SaveChanges();
                if(result.Entity.EmployeeId > 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        public List<Employee> GetAll(Expression<Func<Employee, bool>> filter)
        {
            var result = db.Employees.Where(filter).ToList();
            return result;
        }
        public Employee GetbyId(int id)
        {
            var result = db.Employees.FirstOrDefault(e => e.EmployeeId == id);
            return result;
        }
        public void Update(Employee emp)
        {
            var result = db.Employees.Update(emp);
            db.SaveChanges();
        }

        public void Delete(Employee emp)
        {
            var result = db.Employees.Remove(emp);
            db.SaveChanges();
        }
    }
}
