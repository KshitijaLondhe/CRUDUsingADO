using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDUsingADO.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name="Student Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Student Percentage")]
        public int percentage { get; set; }

        [Required]
        [Display(Name = "Student Branch")]
        public string branch{ get; set; }
    }
}
