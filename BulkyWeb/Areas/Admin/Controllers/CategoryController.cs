using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;


namespace BulkyBookWeb.Controllers
{
	/// <summary>
	/// this is the updated category controller after adding repository
	/// the other former controller is called IRepository
	/// </summary>
	[Area("Admin")]
	public class CategoryController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;

		public CategoryController( IUnitOfWork unitOfWork)
		{
			
			this._unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			// Getting all the Objects that we seeded as data for Category Table 
			List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();

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

				_unitOfWork.Category.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}

			return View("Create");

		}

		// this willget the one that we want to update
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
			Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
			//Category? categoryFromD1 = _db.Categories.FirstOrDefault(u => u.Id == id);
			//Category? categoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View("Edit", categoryFromDb);
		}
		// it will be of the type httpPost 
		// this will update it 
		[HttpPost]
		public IActionResult Edit(Category obj)
		{

			if (ModelState.IsValid)
			{

				_unitOfWork.Category.Update(obj);
				_unitOfWork.Save();
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
			Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);

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
			Category? obj = _unitOfWork.Category.Get(u => u.Id ==  id);
			if (obj == null)
			{
				return NotFound();
			}

			_unitOfWork.Category.Remove(obj);
			_unitOfWork.Save();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");


		}

	}
}
