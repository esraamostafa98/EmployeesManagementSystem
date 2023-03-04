using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CreateRoleVM
    {
        [Required(ErrorMessage = "Role Name REQUIRED")]
        public string RoleName { get; set; }
    }
}
