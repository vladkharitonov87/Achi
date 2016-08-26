using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using Achi.Data.Entities.Base;
using Achi.Data.Entities.SQL;
using Achi.Data.Infrastructure.Enums;
using Achi.Data.UnitOfWork;

namespace Achi.Data.SQL.UnitOfWork
{
	class AchiUnitOfWork : IQueryableUnitOfWork
	{
		protected AchiDbContext Context;

		public AchiUnitOfWork(AchiDbContext context)
		{
			Context = context;
		}

		public void SaveChanges()
		{
			try
			{
				Context.SaveChanges();
			}
			catch (DbUpdateConcurrencyException concurrencyException)
			{
				throw new DbUpdateConcurrencyException("Optimistic concurrency violation occurs.", concurrencyException);
			}
			catch (DbUpdateException dbUpdateException)
			{
				throw new DbUpdateException("UnitOfWork failed to commit changes.", dbUpdateException);
			}
		}

		/// <summary>
		/// Gets the specified entity by Id
		/// </summary>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		/// <typeparam name="TId">An entity Id</typeparam>
		public TEntity Find<TEntity, TId>(TId id) where TEntity : class
		{
			return Set<TEntity>().Find(id);
		}

		/// <summary>
		/// Gets the specified entity by composite Id. Be careful with the order of columns  (keyValues) when using Find (Object parameters [])
		/// </summary>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		/// <typeparam name="TId">An entity Id</typeparam>
		public TEntity Find<TEntity, TId>(params object[] keyValues) where TEntity : class
		{
			return Set<TEntity>().Find(keyValues);
		}

		/// <summary>
		/// Gets queryable dataset
		/// </summary>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public IQueryable<TEntity> AsQueryableFor<TEntity>() where TEntity : class
		{
			return Set<TEntity>().AsNoTracking();
		}

		/// <summary>
		/// Gets queryable dataset
		/// </summary>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public IQueryable<TEntity> AsQueryableForWithTracking<TEntity>() where TEntity : class
		{
			return Set<TEntity>();
		}

		public int ExecuteSqlCommand(string sql, params SqlParameter[] parameters)
		{
			object[] objects = ConvertParametersToObject(parameters);

			if (objects != null)
			{
				sql = GetSqlCommand(sql, parameters);
				return Context.Database.ExecuteSqlCommand(sql, objects);
			}

			return Context.Database.ExecuteSqlCommand(sql);
		}

		public IEnumerable<TEntity> SelectEntities<TEntity>(string procedure, params SqlParameter[] parameters)
		{
			object[] objects = ConvertParametersToObject(parameters);

			if (objects != null)
			{
				procedure = GetSqlCommand(procedure, parameters);

				return Context.Database.SqlQuery<TEntity>(procedure, objects);
			}

			return Context.Database.SqlQuery<TEntity>(procedure);
		}

		/// <summary>
		/// Creates the specified entity
		/// </summary>
		/// <param name="entity">Entity to add</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public TEntity Create<TEntity>(TEntity entity) where TEntity : class
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			return Set<TEntity>().Add(entity);
		}

		/// <summary>
		/// Deletes the specified entity
		/// </summary>
		/// <param name="entity">Entity to delete</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public void Delete<TEntity>(TEntity entity) where TEntity : class, IDeletableEntity
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			Set<TEntity>().Attach(entity);
			Context.Entry(entity).Entity.VersionStatus = Status.Deleted;
            Context.Entry(entity).State = EntityState.Modified;
			Context.ChangeTracker.DetectChanges();
		}

		/// <summary>
		/// Deletes the specified entity
		/// </summary>
		/// <param name="entity">Entity to delete</param>
		/// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public void Remove<TEntity>(TEntity entity) where TEntity : class
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			Set<TEntity>().Remove(entity);
		}

		/// <summary>
		/// Updates the specified entity
		/// </summary>
		/// <param name="entity">Entity to update</param>
		/// <typeparam name="TEntity">A POCO that represents an Entity Framework entity</typeparam>
		public void Update<TEntity>(TEntity entity) where TEntity : class
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));
			Set<TEntity>().Attach(entity);
			Context.Entry(entity).State = EntityState.Modified;
			Context.ChangeTracker.DetectChanges();
		}

		/// <summary>
		/// Commit all changes
		/// </summary>
		public void Commit()
		{
			DetectChanges();
			SaveChanges();
		}

		public void DetectChanges()
		{
			Context.ChangeTracker.DetectChanges();
		}

		internal IDbSet<TEntity> Set<TEntity>()
			where TEntity : class
		{
			return Context.Set<TEntity>();
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposing)
				return;

			if (Context == null)
				return;

			SaveChanges();
			Context.Dispose();
			Context = null;
		}

		private static object[] ConvertParametersToObject(SqlParameter[] parameters)
		{
			if (parameters != null)
			{
				object[] objects = new object[parameters.Length];
				for (int i = 0; i < parameters.Length; i++)
				{
					objects[i] = parameters[i];
				}

				return objects;
			}

			return null;
		}

		private static string GetSqlCommand(string procedure, IEnumerable<SqlParameter> parameters)
		{
			foreach (SqlParameter sqlParameter in parameters)
			{
				string parameterName = sqlParameter.ParameterName;
				if (!procedure.Contains(parameterName))
				{
					procedure = procedure + $" {parameterName},";
				}
			}
			return procedure.TrimEnd(',');
		}
	}
}
