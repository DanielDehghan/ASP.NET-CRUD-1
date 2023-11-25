using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
	// it will implement the base functionality we have for all the repository 
	void Update(Category obj);
	
}