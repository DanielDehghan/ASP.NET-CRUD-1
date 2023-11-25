using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Data;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		// we use Repository<Category> as base class so we have the implementation
		// of other methods because we dont want implement 
		// other methods we just wanna implement the 2 that we need 
		private ApplicationDbContext _db;

		// when we get the implementations we want to pass
		// the implementation to the base class 
		public CategoryRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Category obj)
		{
			_db.Categories.Update(obj);
			
		}


	}
}
