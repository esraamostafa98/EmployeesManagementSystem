using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DAL.Entities
{
    [Table("District")]
    public class District
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string DistrictName { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City Citry { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
