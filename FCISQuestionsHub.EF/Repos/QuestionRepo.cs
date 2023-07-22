using FCISQuestionsHub.Core.Interfaces;
using FCISQuestionsHub.Core.Models;
using FCISQuestionsHub.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.EF.Repos
{
	public class QuestionRepo : BaseRepo<Question>, IQuestionRepo
	{
		private readonly ApplicationDbContext _context;

		public QuestionRepo(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public IEnumerable<Question> GetBySubject(string subject)
		{
			return _context.questions.Where(q => q.Subject == subject).ToList();
		}

		public  void Load()
		{
			 _context.questions.Include(q => q.answers).Load();
			 //_context.questions.Include(q => q.students).Load();
			 //_context.questions.Include(q => q.studentQuestions).Load();
		}

		public IEnumerable<string> Subjects()
		{
			return _context.questions.Select(q => q.Subject).Distinct();	
		}
	}
}
