﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.DAL.Entities
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string DepartmentName { get; set; }
        [StringLength(20)]
        public string DepartmentCode { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        
    }
}
