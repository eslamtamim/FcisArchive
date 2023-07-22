using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FCISQuestionsHub.Core.Models
{
	public enum QuestionType { MCQ, TrueFalse }


	[Index(nameof(Text))]
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
			this.Subject = q.Subject;
			this.Photo = q.Photo;
			this.Hint = q.Hint;
			this.QuestionType = q.QuestionType;
			this.answers = q.answers;
			this.students = q.students;
			this.studentQuestions = q.studentQuestions;

        }
        [Key]
		[Required]
		public long Id { get; set; }
		[Required]
		public string Text { get; set; }
		[Required]
		[MaxLength(250)]
		public string Subject { get; set; }
		public string? Photo { get; set; }
		[MaxLength(50)]
		public string? Hint { get; set; }
		public QuestionType? QuestionType { get; set; }
		public virtual List<Answer> answers { get; set; }
        public virtual List<StudentUser> students { get; set; }

		public virtual List<StudentQuestionAnswer> studentQuestions { get; set; }


	}
}
