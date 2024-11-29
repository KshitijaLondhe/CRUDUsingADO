using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [Display(Name="Employee Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employee Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Employee Salary")]
        public double Salary { get; set; }
    }
}
