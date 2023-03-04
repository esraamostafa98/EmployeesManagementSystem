using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.DAL.Entities
{
    [Table("City")]
    public class City
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CityName { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
