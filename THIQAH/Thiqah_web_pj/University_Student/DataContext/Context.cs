using Microsoft.EntityFrameworkCore;
using University_Student.Models;

namespace University_Student.DataContext
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }
        public DbSet<UserModel> User { get; set; }

        public DbSet<StudentProgramModel> StudentProgram { get; set; }

        public DbSet<ProgramModel> Program { get; set; }

        public DbSet<LevelOfStudyModel> LevelOfStudy { get; set; }

        public DbSet<FacultyModel> Faculty { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<UserModel>(b =>
            {
                b.ToTable("User");
            });

            modelBuilder.Entity<ProgramModel>(b =>
            {
                b.ToTable("Programs");
            });

            modelBuilder.Entity<FacultyModel>(b =>
            {
                b.ToTable("Faculty");
            });

            modelBuilder.Entity<LevelOfStudyModel>(b =>
            {
                b.ToTable("LevelOfStudy");
            });

            modelBuilder.Entity<StudentProgramModel>(b =>
            {
                b.ToTable("StudentProgram");
                //b.HasNoKey();
            });
        }
    }
}
