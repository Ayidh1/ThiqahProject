using University_Student.DataContext;
using Microsoft.EntityFrameworkCore;
using University_Student.Models;
using University_Student.ViewModels;

namespace University_Student.Repos
{
    public class Repo : IRepo
    {
        private readonly Context _db;
        public Repo(Context db)
        {
            _db = db;
        }

        public async Task AddStudentProgram(StudentProgramModel studentProgram)
        {
            await _db.StudentProgram.AddAsync(studentProgram);
            await _db.SaveChangesAsync();
        }

        public async Task<StudentDashboard> Dashboard(int id)
        {
            var user = await _db.User.Where(x => x.UserId == id).Select(x => new { x.FirstName, x.LastName, x.Photo }).FirstOrDefaultAsync();

            var studentprogram = await _db.StudentProgram.Where(x => x.UserId == id).FirstOrDefaultAsync();

            var study = await _db.LevelOfStudy.Where(x => x.LevelOfStudyId == studentprogram.LevelOfStudyId).FirstOrDefaultAsync();

            var program = await _db.Program.Where(x => x.ProgramId == studentprogram.ProramId).FirstOrDefaultAsync();

            var faculty = await _db.Faculty.Where(x => x.FacultyId == studentprogram.FacultyId).FirstOrDefaultAsync();

            var studentDashboardDetail = new StudentDashboard()
            {
                faculty = faculty.FaculatyName,
                program = program.ProgramName,
                study = study.LevelOfStudyName,
                studentName = user.FirstName + " " + user.LastName,
                photo = user.Photo
            };

            return studentDashboardDetail;
        }

        public async Task<long> GetUserId(string email)
        {
            return await _db.User.Where(x => x.Email.ToLower().Equals(email.ToLower())).Select(x => x.UserId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsCredentialExist(string email, string password)
        {
            return await _db.User.Where(x => x.Email.ToLower().Equals(email.ToLower()) && x.Password.ToLower().Equals(password.ToLower())).AnyAsync();
        }

        public async Task<bool> IsUserExist(string email)
        {
            return await _db.User.Where(x => x.Email.ToLower().Equals(email.ToLower())).AnyAsync();
        }

        public async Task<long> Register(UserModel registerModel)
        {
            await _db.User.AddAsync(registerModel);
            var userId = await _db.SaveChangesAsync();
            return registerModel.UserId;
        }
    }
}
