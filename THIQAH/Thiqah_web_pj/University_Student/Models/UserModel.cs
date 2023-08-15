using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace University_Student.Models
{
    [PrimaryKey("UserId")]
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public byte[] Photo { get; set; }

        }
}
