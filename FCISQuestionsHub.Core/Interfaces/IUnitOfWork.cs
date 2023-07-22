using FCISQuestionsHub.Core.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.Core.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
        public IQuestionRepo questions { get; set; }
        public IBaseRepo<Answer> answers { get; set; }
		public IBaseRepo<StudentQuestionAnswer> studentQuestions { get; set; }

		public IDbContextTransaction BeginTransaction();
        public void DisposeTransaction();

        public void Commit();

        public void Rollback();
        Task<int> SaveChangesAsync();


	}
}
