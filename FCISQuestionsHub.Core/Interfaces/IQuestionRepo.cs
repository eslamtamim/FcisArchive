using FCISQuestionsHub.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.Core.Interfaces
{
	public interface IQuestionRepo : IBaseRepo<Question>
	{
		IEnumerable<string> Subjects();
		IEnumerable<Question> GetBySubject(string subject);
		void Load();
	}
}
