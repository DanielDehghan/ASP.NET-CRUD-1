//using BulkyBook.dataaccess.data;
//using microsoft.aspnetcore.mvc;
//using BulkyBook.models;
//using microsoft.entityframeworkcore;

//namespace BulkyBookweb.controllers
//{
//	public class priorcategorycontroller : controller
//	{

//		// because we already registred the applicationdbcontext in services 
//		// so we take the refrence of that 
//		// so we do constructor to do implementation of applicationdbcontext
//		private readonly applicationdbcontext _db;
//		public priorcategorycontroller(applicationdbcontext db)
//		{
//			// whatever implementation we get in the constructor we will assign that
//			// to _db local variable
//			_db = db;
//		}
//		public iactionresult index()
//		{
//			// getting all the objects that we seeded as data for category table 
//			list<category> objcategorylist = _db.categories.tolist();

//			// to pass the category to the view we just copy the list of objects 
//			// and pass it to view method parameter 
//			return view(objcategorylist);
//		}

//		public iactionresult create()
//		{
//			return view();
//		}
//		// it will be of the type httppost 
//		[httppost]
//		public iactionresult create(category obj)
//		{
//			//if (obj.name == obj.displayorder.tostring())
//			//{
//			//       modelstate.addmodelerror("name", "the displayorder cannot exactly match the name.");
//			//}
//			if (obj.name != null && obj.name.tolower() == "test")
//			{
//				modelstate.addmodelerror("", "test is an invalid value");
//			}
//			if (modelstate.isvalid)
//			{

//				_db.categories.add(obj);
//				_db.savechanges();
//				tempdata["success"] = "category created successfully";
//				return redirecttoaction("index");
//			}

//			return view("create");

//		}

	
//		public iactionresult edit(int? id)
//		{
//			// making nullable by adding ? 
//			if (id == null || id == 0)
//			{
//				// we cam also have and error page and return to that view
//				// displaying sth is not valid 
//				return notfound();
//			}
//			// multiple ways of finding the category by id 
//			category? categoryfromdb = _db.categories.find(id);
//			//category? categoryfromd1 = _db.categories.firstordefault(u => u.id == id);
//			//category? categoryfromdb2 = _db.categories.where(u => u.id == id).firstordefault();
//			if (categoryfromdb == null)
//			{
//				return notfound();
//			}

//			return view("edit", categoryfromdb);
//		}
//		// it will be of the type httppost 
//		[httppost]
//		public iactionresult edit(category obj)
//		{

//			if (modelstate.isvalid)
//			{

//				_db.categories.update(obj);
//				_db.savechanges();
//				tempdata["success"] = "category updated successfully";
//				return redirecttoaction("index");
//			}

//			return view("edit");

//		}

//		public iactionresult delete(int? id)
//		{
//			// making nullable by adding ? 
//			if (id == null || id == 0)
//			{
//				return notfound();
//			}
//			category? categoryfromdb = _db.categories.find(id);
		
//			if (categoryfromdb == null)
//			{
//				return notfound();
//			}

//			return view("delete", categoryfromdb);
//		}
//		// it will be of the type httppost 
//		// we can explicitly say this action method name is delete even that 
//		// it has a different name 
//		[httppost, actionname("delete")]
//		public iactionresult deletepost(int? id)
//		{
//			category? obj = _db.categories.find(id);
//			if (obj == null)
//			{
//				return notfound();
//			}

//			_db.categories.remove(obj);
//			_db.savechanges();
//			tempdata["success"] = "category deleted successfully";
//			return redirecttoaction("index");


//		}
//	}
//}
