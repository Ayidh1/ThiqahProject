using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Student.Models
{
    [PrimaryKey("FacultyId")]
    public class FacultyModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacultyId { get; set; }
        public string FaculatyName { get; set; }
    }
}
