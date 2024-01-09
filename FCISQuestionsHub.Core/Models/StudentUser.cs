using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace FCISQuestionsHub.Core.Models;

public enum Department
{
    General, IT, CS, IS
}
public class StudentUser : IdentityUser
{
   
    [Required,MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    public string Image { get; set; }

    [MaxLength(50)]
    public string  DisplayName { get; set; }
    public Year? AcademicYear { get; set; }
    public Department ?Department { get; set; }
    public int ? Section { get; set; }

    public DateTime? JoinDate { get; set; } = DateTime.UtcNow;

    public virtual List<Question> questions { get; set; }
    public virtual List<StudentQuestionAnswer> studentQuestions { get; set; }

    


    // SetFirstNameAsync

    // SetLastNameAsync
 


}

