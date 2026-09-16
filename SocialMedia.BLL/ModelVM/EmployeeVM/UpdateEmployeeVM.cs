using Microsoft.AspNetCore.Http;
using SocialMedia.DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.BLL.ModelVM.EmployeeVM
{
    public class UpdateEmployeeVM
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Min Length = 3 characters")]
        public string Name { get; set; }

        [Range(19, 60, ErrorMessage = "Age must be between 19 - 60")]
        public int Age { get; set; }

        public IFormFile? Image { get; set; }
        public string? PathImage { get; set; }
        public string? DepartmentName { get; set; }
        public int? DepartmentId { get; set; }
    }
}
