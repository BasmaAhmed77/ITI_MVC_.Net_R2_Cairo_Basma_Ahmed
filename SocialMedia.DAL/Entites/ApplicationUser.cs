using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.DAL.Entites
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string? Address { get; set; }
    }
}
