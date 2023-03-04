using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class DeleteRoleVM
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name REQUIRED")]
        public string RoleName { get; set; }
    }
}
