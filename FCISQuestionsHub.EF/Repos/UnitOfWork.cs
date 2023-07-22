using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCISQuestionsHub.Core.Interfaces;
using FCISQuestionsHub.Core.Models;
using FCISQuestionsHub.EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace FCISQuestionsHub.EF.Repos
{
    public class UnitOfWork : IUnitOfWork
    {

        private IDbContextTransaction transaction;


        private readonly ApplicationDbContext context_;
        public IQuestionRepo questions { get; set; }
        public IBaseRepo<Answer> answers { get; set; }
        public IBaseRepo<StudentQuestionAnswer> studentQuestions { get; set; }


		public UnitOfWork(ApplicationDbContext context_)
        {
            this.context_ = context_;
            questions = new QuestionRepo(context_);
            answers = new BaseRepo<Answer>(context_);
            studentQuestions = new BaseRepo<StudentQuestionAnswer>(context_);

        }
        public IDbContextTransaction BeginTransaction()
        {
           return transaction = context_.Database.BeginTransaction();
        }
        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }


        public void Dispose()
        {
            context_.Dispose();
        }
        public void DisposeTransaction()
        {
            transaction.Dispose();
        }

        public Task<int> SaveChangesAsync() => context_.SaveChangesAsync();

	
	}
}
