using Microsoft.EntityFrameworkCore;
using FCISQuestionsHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
                .Ignore(u =>u.PhoneNumber).Ignore(u => u.PhoneNumberConfirmed)
                .Ignore(u => u.LockoutEnabled).Ignore(u => u.LockoutEnd)
                .Ignore(u => u.AccessFailedCount).Ignore(u => u.TwoFactorEnabled);
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");


            builder.Entity<StudentUser>().HasMany(q => q.questions).WithMany(s => s.students)
                .UsingEntity<StudentQuestionAnswer>(
                    j => j.HasOne(sq => sq.question).WithMany(q => q.studentQuestions).HasForeignKey(sq => sq.questionId),
                    j => j.HasOne(sq => sq.student).WithMany(s => s.studentQuestions).HasForeignKey(sq => sq.studentsId),
                    j =>
                    {
                        j.HasKey(sqa => new { sqa.studentsId, sqa.questionId });
                    }
                ) ;
		}

        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }

    }
}
