using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Autozam.Models
{
	public class DepartamentRepository : IDepartamentRepository
	{
		PageModels context = new PageModels();

		public IQueryable<Departament> All
		{
			get { return context.Departaments; }
		}

		public IQueryable<Departament> AllIncluding(params Expression<Func<Departament, object>>[] includeProperties)
		{
			IQueryable<Departament> query = context.Departaments;
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query;
		}

		public Departament Find(int id)
		{
			return context.Departaments.Find(id);
		}

		public void InsertOrUpdate(Departament departament)
		{
			if (departament.Id == default(int))
			{
				// New entity
				context.Departaments.Add(departament);
			}
			else
			{
				// Existing entity
				context.Entry(departament).State = EntityState.Modified;
			}
		}

		public void Delete(int id)
		{
			var departament = context.Departaments.Find(id);
			context.Departaments.Remove(departament);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		public void Dispose()
		{
			context.Dispose();
		}
	}

	public interface IDepartamentRepository : IDisposable
	{
		IQueryable<Departament> All { get; }
		IQueryable<Departament> AllIncluding(params Expression<Func<Departament, object>>[] includeProperties);
		Departament Find(int id);
		void InsertOrUpdate(Departament departament);
		void Delete(int id);
		void Save();
	}
}