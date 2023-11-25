using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
	// setting type <T> for a generic class 
	public interface IRepository<T> where T : class
	{
		// T - Category(T is known as Category)
		//Get All
		IEnumerable<T> GetAll();

		//Getting Individual 
		T Get(Expression<Func<T,bool>> filter);

		//Add 
		void Add(T entity);
		void Remove(T entity);

		// this one will delete multiple entities in a single call 

		void RemoveRange(IEnumerable<T> entities);



	}
}
