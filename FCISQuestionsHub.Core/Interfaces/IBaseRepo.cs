using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.Core.Interfaces
{
	public interface IBaseRepo<T> where T : class
	{
		T GetById(long id);
		Task<T> GetByIdAsync(long id);

		IEnumerable<T> GetAll();

		IEnumerable<T> GetAll(Expression<Func<T, bool>> expression, long? take, long? skip);
		Task<T> FindAsync(Expression<Func<T, bool>> expression);
		Task<IEnumerable<T>> FindMany(Expression<Func<T, bool>> expression);
		Task<long> CountAsync();
		Task<long> CountAsync(Expression<Func<T,bool>> expression);

		T Add(T entity);
		IEnumerable<T> Add(IEnumerable<T> entities);
		Task<T> AddAsync(T entity);
		Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities);
		T Update(T entity);
		T Delete(long id);
		T Delete(T entity);
		IEnumerable<T> DeleteMany(IEnumerable<T> entities);
	
		Task<long> SaveChanges();


	}
}
