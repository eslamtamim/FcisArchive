using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCISQuestionsHub.Core.Models;

public enum QuestionType { MCQ, TrueFalse }
public enum Year { First = 1, Second, Third, Fourth }
public enum Semester { First = 1, Second }



[Index(nameof(SubjectId),nameof(LectureId))]
public class Question
{
    public Question()
    {
        // initialize the lists
    }
    public Question(Question q)
    {
        // map all the properties
        this.Id = q.Id;
        this.Text = q.Text;
        this.Photo = q.Photo;
        this.Hint = q.Hint;
        this.QuestionType = q.QuestionType;
        this.AuthorName = q.AuthorName;
        this.LectureId = q.LectureId;
        this.Lecture = q.Lecture;
        this.SubjectId = q.SubjectId;
        this.Subject = q.Subject;
        this.answers = q.answers;
        this.students = q.students;
        this.studentQuestions = q.studentQuestions;

    }
    [Key]
    [Required]
    public long Id { get; set; }
    [Required]
    public string Text { get; set; }


    public string Photo { get; set; }

    [MaxLength(500)]
    public string Hint { get; set; }
    
    [MaxLength(50)]
    public string AuthorName { get; set; }

    public QuestionType QuestionType { get; set; }

    [Required]
    public int SubjectId { get; set; }

    [Required]
    public int LectureId { get; set; }

    public virtual Subject Subject { get; set; }
    public virtual Lecture Lecture { get; set; }

    public virtual List<Answer> answers { get; set; }
    public virtual List<StudentUser> students { get; set; }
    public virtual List<StudentQuestionAnswer> studentQuestions { get; set; }


}
