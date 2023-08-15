using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_Student.DataContext;
using University_Student.Models;
using University_Student.Repos;
using University_Student.ViewModels;

namespace University_Student.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly IRepo _repo;
        private readonly Context _db;
        public StudentController(IRepo repo, Context db)
        {
            _repo = repo;
            _db = db;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]RegisterModel registerModel)
        {
            if (await _repo.IsUserExist(registerModel.email))
            {
                return Ok("Already Exist");
            }

            var memoryStream = new MemoryStream();
            
            await registerModel.photo.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();


            var user = new UserModel()
            {
                Email = registerModel.email,
                FirstName = registerModel.firstName,
                LastName = registerModel.lastName,
                BirthDate = registerModel.birthDate,
                Password = registerModel.password,
                Photo = imageBytes
            };

            var userId = await _repo.Register(user);

            var studentProgram = new StudentProgramModel()
            {
                UserId = userId,
                FacultyId = registerModel.facultyId,
                LevelOfStudyId = registerModel.levelOfStudyId,
                ProramId = registerModel.programId,
            };

            await _repo.AddStudentProgram(studentProgram);
            return Ok("Successfully registered!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if(await _repo.IsUserExist(loginModel.email))
            {
                if(await _repo.IsCredentialExist(loginModel.email, loginModel.password))
                {
                    return Ok(await _repo.GetUserId(loginModel.email));
                }

                return Ok("Email or password is not correct!");
            }
            return Ok("Email or password is not correct!");
        }

        [HttpGet("dashboard/{id:int}")]
        public async Task<IActionResult> Dashboard(int id)
        {
            var userDetails = await _repo.Dashboard(id);

            return Ok(userDetails);
        }

    }
}
