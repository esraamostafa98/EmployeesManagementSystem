using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class DepartmentVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Enter Dpartment Name")]
        [MaxLength(20,ErrorMessage = "Max Length is 20")]
        [MinLength(3,ErrorMessage = "Min Length is 3")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Enter Dpartment Code")]
        public string DepartmentCode { get; set; }
    }
}
