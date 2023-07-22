using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace FCISQuestionsHub.Core.Models
{
    public class StudentUser : IdentityUser
    {
        //public StudentUser() { 
        //    UserName = Email!.Substring(0, Email.IndexOf('@'));
        //}
        [Required,MaxLength(50)]
        public string? FirstName { get; set; }
        [Required, MaxLength(50)]
        public string? LastName { get; set; }
        public virtual List<Question> questions { get; set; }
        public virtual List<StudentQuestionAnswer> studentQuestions { get; set; }


        // SetFirstNameAsync

        // SetLastNameAsync
     


    }
}
