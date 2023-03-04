using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter Dpartment Name")]
        [MaxLength(50, ErrorMessage = "Max Length is 50")]
        [MinLength(3, ErrorMessage = "Min Length is 3")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Salary")]
        [Range(3000, 10000, ErrorMessage = "Enter Range Btween 3K : 10K")]
        
        public float Salary { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        //[RegularExpression("[0-9]{2,5}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}-[a-zA-Z]{3,50}", ErrorMessage = "Enter lik 12- Street Name - City Name - Country Name")]
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int DistrictId { get; set; }
        public string? DistrictName { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public string? PhotoName { get; set; }
        public IFormFile CVUrl { get; set; }
        public string? CVName { get; set; }
    }
}
