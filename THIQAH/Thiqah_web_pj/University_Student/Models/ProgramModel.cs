using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Student.Models
{
    [PrimaryKey("ProgramId")]
    public class ProgramModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }

        public int FacultyId { get; set; }
    }
}
