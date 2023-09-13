using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FCISQuestionsHub.Core.Models;

[Index(nameof(Name), IsUnique = true)]
public class Subject
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public Year Year { get; set; }
    [Required]
    public Semester Semester { get; set; }
    public virtual List<Lecture> Lectures { get; set; }

}
