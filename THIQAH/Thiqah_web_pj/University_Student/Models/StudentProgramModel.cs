using Microsoft.EntityFrameworkCore;

namespace University_Student.Models
{
    [PrimaryKey("UserId")]
    public class StudentProgramModel
    {
        public long UserId { get; set; }
        public int LevelOfStudyId { get; set; }
        public int ProramId { get; set; }
        public int FacultyId { get; set; }

    }
}
