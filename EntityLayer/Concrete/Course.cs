using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public Student Student { get; set; }
    }
}
