using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Data;

namespace BulkyBook.DataAccess.Repository.IRepository
{
	/// <summary>
	/// we will use UnitOfWork in our controller because it internally has category repository as well 
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;
		public ICategoryRepository Category { get; private set; }
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
		}


		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
