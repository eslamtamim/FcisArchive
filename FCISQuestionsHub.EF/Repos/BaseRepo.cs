using FCISQuestionsHub.Core.Interfaces;
using FCISQuestionsHub.EF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FCISQuestionsHub.EF.Repos
{
	public class BaseRepo<T> : IBaseRepo<T> where T : class
	{
		private readonly ApplicationDbContext context_;

		public BaseRepo(ApplicationDbContext context)
		{
			context_ = context;
		}


		public T Add(T entity) => context_.Set<T>().Add(entity).Entity;


		public IEnumerable<T> Add(IEnumerable<T> entities)
		{
			context_.AddRange(entities);
			return entities;
		}

		public async Task<T> AddAsync(T entity)
		{
			var q = await context_.Set<T>().AddAsync(entity);
			return q.Entity;
		}


		public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
		{
			await context_.Set<T>().AddRangeAsync(entities);
			return entities;
		}

		public async Task<long> CountAsync() => await context_.Set<T>().LongCountAsync();

		public async Task<long> CountAsync(Expression<Func<T, bool>> expression)
			=> await context_.Set<T>().LongCountAsync(expression);

		public T Delete(long id)
		{
			T entity = GetById(id);
			if (entity is not null)
			{
				context_.Set<T>().Remove(entity);
			}
			return entity ?? throw new NullReferenceException();
		}

		public T Delete(T entity) => context_.Set<T>().Remove(entity).Entity;



		public IEnumerable<T> DeleteMany(IEnumerable<T> entities)
		{
			context_.Set<T>().RemoveRange(entities);
			return entities;
		}

		public async Task<T> FindAsync(Expression<Func<T, bool>> expression)
		{
			var q = await context_.Set<T>().FirstOrDefaultAsync(expression);
			return q;
		}

		public async Task<IEnumerable<T>> FindMany(Expression<Func<T, bool>> expression, long? take, long? skip)
		{
			

			IQueryable<T> query = context_.Set<T>().Where(expression);
			if (skip is not null)
			{
				query = query.Skip((int)skip);
			}

			if (take is not null)
			{
				query = query.Take((int)take);
			}
			return await query.ToListAsync();
		}


		public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression, long? take, long? skip)
		{
			IQueryable<T> query = context_.Set<T>();
			if (skip is not null)
			{
				query = query.Skip((int)skip);
			}

			if (take is not null)
			{
				query = query.Take((int)take);
			}
			return query.ToList();
		}

		public IEnumerable<T> GetAll() => context_.Set<T>().ToList();


		public T GetById(long id) => context_.Set<T>().Find(id) ?? throw new NullReferenceException();

		public async Task<T> GetByIdAsync(long id) => await context_.Set<T>().FindAsync(id) ?? throw new NullReferenceException();


		public async Task<long> SaveChanges() => await context_.SaveChangesAsync();


		public T Update(T entity) => context_.Set<T>().Update(entity).Entity;


	}
}
