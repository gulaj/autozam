using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autozam.Models;
using System.IO;

namespace Autozam.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly IDepartamentRepository departamentRepository;
		private readonly ICategoryRepository categoryRepository;
		private readonly IProductRepository productRepository;

		// If you are using Dependency Injection, you can delete the following constructor
		public CategoriesController()
			: this(new DepartamentRepository(), new CategoriesRepository(), new ProductRepository())
		{
		}

		public CategoriesController(IDepartamentRepository departamentRepository, ICategoryRepository categoryRepository, IProductRepository productRepository)
		{
			this.departamentRepository = departamentRepository;
			this.categoryRepository = categoryRepository;
			this.productRepository = productRepository;
		}

		//
		// GET: /Categories/

		public ViewResult Index()
		{
			return View(categoryRepository.AllIncluding(category => category.Products));
		}

		//
		// GET: /Categories/Details/5

		public ViewResult Details(int id)
		{
			var Category = categoryRepository.Find(id);
			var Products = productRepository.All.Where(prod => prod.CategoryId == id);
			Category.Products = Products.ToList();
			return View(Category);
		}

		//
		// GET: /Categories/Create

		public ActionResult Create()
		{
			ViewBag.PossibleDepartaments = departamentRepository.All;
			return View();
		}

		//
		// POST: /Categories/Create

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Create(Category category)
		{
			if (ModelState.IsValid)
			{
				categoryRepository.InsertOrUpdate(category);
				categoryRepository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.PossibleDepartaments = departamentRepository.All;
				return View();
			}
		}

		//
		// GET: /Categories/Edit/5

		public ActionResult Edit(int id)
		{
			ViewBag.PossibleDepartaments = departamentRepository.All;
			return View(categoryRepository.Find(id));
		}

		//
		// POST: /Categories/Edit/5

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Edit(Category category)
		{
			if (ModelState.IsValid)
			{
				categoryRepository.InsertOrUpdate(category);
				categoryRepository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.PossibleDepartaments = departamentRepository.All;
				return View();
			}
		}

		//
		// GET: /Categories/Delete/5

		public ActionResult Delete(int id)
		{
			var Category = categoryRepository.Find(id);
			var Products = productRepository.All.Where(prod => prod.CategoryId == id);
			Category.Products = Products.ToList();
			return View(Category);
		}

		//
		// POST: /Categories/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			categoryRepository.Delete(id);
			categoryRepository.Save();

			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				departamentRepository.Dispose();
				categoryRepository.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

