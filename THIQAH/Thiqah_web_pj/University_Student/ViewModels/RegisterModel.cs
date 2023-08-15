using System.ComponentModel.DataAnnotations;

namespace University_Student.ViewModels
{
    public class RegisterModel
    {
        [EmailAddress]
        public string email { get; set; }
        [Required, StringLength(50)]
        public string firstName{ get; set; }
        [Required,StringLength(50)]
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string password { get; set; }
        public IFormFile photo { get; set; }

        public int programId { get; set; }
        public int levelOfStudyId { get; set; }
        public int facultyId { get; set; }
    }
}
