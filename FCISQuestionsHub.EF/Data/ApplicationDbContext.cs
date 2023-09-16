using Microsoft.EntityFrameworkCore;
using FCISQuestionsHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FCISQuestionsHub.Core.Models.UploadingModels;
using System.Reflection.Emit;

namespace FCISQuestionsHub.EF.Data
{
    public class ApplicationDbContext : IdentityDbContext<StudentUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudentUser>().ToTable("Users", "security")
                .Ignore(u => u.PhoneNumber).Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.LockoutEnabled).Ignore(u => u.LockoutEnd)
                .Ignore(u => u.AccessFailedCount).Ignore(u => u.TwoFactorEnabled);
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

            // for sql server
            //builder.Entity<StudentUser>().HasMany(q => q.questions).WithMany(s => s.students)
            //    .UsingEntity<StudentQuestionAnswer>(
            //        j => j.HasOne(sq => sq.question).WithMany(q => q.studentQuestions).HasForeignKey(sq => sq.questionId).OnDelete(DeleteBehavior.NoAction),
            //        j => j.HasOne(sq => sq.student).WithMany(s => s.studentQuestions).HasForeignKey(sq => sq.studentsId).OnDelete(DeleteBehavior.NoAction),
            //        j =>
            //        {
            //            j.HasKey(sqa => new { sqa.studentsId, sqa.questionId });
            //        }
            //);

            //builder.Entity<Question>().HasOne(q => q.Subject).WithMany(s => s.Questions).HasForeignKey(q => q.SubjectId).OnDelete(DeleteBehavior.NoAction);
            //for postgresql
            builder.Entity<StudentUser>().HasMany(q => q.questions).WithMany(s => s.students)
                .UsingEntity<StudentQuestionAnswer>(
                    j => j.HasOne(sq => sq.question).WithMany(q => q.studentQuestions).HasForeignKey(sq => sq.questionId).OnDelete(DeleteBehavior.Cascade),
                    j => j.HasOne(sq => sq.student).WithMany(s => s.studentQuestions).HasForeignKey(sq => sq.studentsId).OnDelete(DeleteBehavior.Cascade),
                    j =>
                    {
                        j.HasKey(sqa => new { sqa.studentsId, sqa.questionId });
                    }
                );
            builder.Entity<FileUpload>().HasOne(f => f.PdfUpload).WithMany(s => s.Files).HasForeignKey(f => f.RequestID).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Subject>().HasIndex(s => s.Name).IsUnique();



        }

        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<StudentQuestionAnswer> studentQuestionAnswer { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Lecture> lectures { get; set; }

        public DbSet<PdfUploads> PdfUploads { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
        public DbSet<FileErrors> FileErrors { get; set; }

    }
}
