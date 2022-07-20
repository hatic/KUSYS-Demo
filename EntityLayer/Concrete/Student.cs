using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Birth Date")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime BirthDate { get; set; }
        public string CourseId { get; set; }
        public Course Course{ get; set; }
    }
}
