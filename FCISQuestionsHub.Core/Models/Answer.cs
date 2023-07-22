using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.Core.Models
{
	[Index(nameof(Text))]
	public class Answer
	{
		[Key]
		[Required]
		public long Id { get; set; }
		[Required]
	
		public string Text { get; set; }
		[Required]
		public bool IsCorrect { get; set; } = false;
		[Required]
		public long QuestionId { get; set; }
		public virtual Question Question { get; set; }
	}
}
