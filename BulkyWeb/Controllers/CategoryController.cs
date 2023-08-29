using Bulky.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Controllers
{
	public class CategoryController : Controller
	{

		// because we already registred the applicationDbContext in Services 
		// so we take the refrence of that 
		// so we do constructor to do implementation of applicationDbContext
		private readonly ApplicationDbContext _db;
		public CategoryController(ApplicationDbContext db)
		{
			// whatever implementation we get in the constructor we will assign that
			// to _db local variable
			_db = db;
		}
		public IActionResult Index()
		{
			// Getting all the Objects that we seeded as data for Category Table 
			List<Category> objCategoryList = _db.Categories.ToList();

			// to pass the category to the view we just copy the list of objects 
			// and pass it to view method parameter 
			return View(objCategoryList);
		}

		public IActionResult Create()
		{
			return View();
		}
		// it will be of the type httpPost 
		[HttpPost]
		public IActionResult Create(Category obj)
		{
			//if (obj.Name == obj.DisplayOrder.ToString())
			//{
			//       ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
			//}
			if (obj.Name != null && obj.Name.ToLower() == "test")
			{
				ModelState.AddModelError("", "test is an invalid value");
			}
			if (ModelState.IsValid)
			{

				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}

			return View("Create");

		}

	
		public IActionResult Edit(int? id)
		{
			// Making nullable by adding ? 
			if (id == null || id == 0)
			{
				// we cam also have and error page and return to that view
				// displaying sth is not valid 
				return NotFound();
			}
			// Multiple ways of finding the category by id 
			Category? categoryFromDb = _db.Categories.Find(id);
			//Category? categoryFromD1 = _db.Categories.FirstOrDefault(u => u.Id == id);
			//Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View("Edit", categoryFromDb);
		}
		// it will be of the type httpPost 
		[HttpPost]
		public IActionResult Edit(Category obj)
		{

			if (ModelState.IsValid)
			{

				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index");
			}

			return View("Edit");

		}

		public IActionResult Delete(int? id)
		{
			// Making nullable by adding ? 
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);
		
			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View("Delete", categoryFromDb);
		}
		// it will be of the type httpPost 
		// We can Explicitly say this Action method name is Delete even that 
		// it has a different name 
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category? obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");


		}
	}
}
