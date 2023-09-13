using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.Core.Models;

[Index(nameof(Name))]
public class Lecture
{

    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Required]
    public string UploaderId { get; set; }

    [Required]
    public int SubjectId { get; set; }
    public virtual Subject Subject { get; set; }

    public virtual List<Question> Questions { get; set; }
}
