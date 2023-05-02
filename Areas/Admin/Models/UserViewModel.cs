using FinalProjectRyan.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProjectRyan.Areas.Admin.Models
{
    public class UserViewModel
    {
        public IEnumerable<AdminUser> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}
