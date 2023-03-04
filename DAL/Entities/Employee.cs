using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
       
        public float Salary { get; set; }
       
        public string Address { get; set; }
        public DateTime HireDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Note { get; set; }
        public string PhotoName { get; set; }
        public string CVName { get; set; }

        public int DepartmentId { get; set;}
        public int DistrictId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        [ForeignKey("DistrictId")]
        public District District { get; set; }
    }
}
