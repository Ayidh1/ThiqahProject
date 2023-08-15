using University_Student.Models;
using University_Student.ViewModels;

namespace University_Student.Repos
{
    public interface IRepo
    {
        Task<long> Register(UserModel userModel);

        Task<bool> IsUserExist(string email);

        Task AddStudentProgram(StudentProgramModel studentProgram);

        Task<bool> IsCredentialExist(string email, string password);

        Task<StudentDashboard> Dashboard(int id);

        Task<long> GetUserId(string email);
    }
}
