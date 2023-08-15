using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Student.Models
{
    [PrimaryKey("LevelOfStudyId")]
    public class LevelOfStudyModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelOfStudyId { get; set; }
        public string LevelOfStudyName { get; set; }
    }
}
