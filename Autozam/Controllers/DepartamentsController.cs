using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autozam.Models;

namespace Autozam.Controllers
{
	public class DepartamentsController : Controller
	{
		private readonly IDepartamentRepository departamentRepository;

		// If you are using Dependency Injection, you can delete the following constructor
		public DepartamentsController()
			: this(new DepartamentRepository())
		{
		}

		public DepartamentsController(IDepartamentRepository departamentRepository)
		{
			this.departamentRepository = departamentRepository;
		}

		//
		// GET: /Departaments/

		public ViewResult Index()
		{
			return View(departamentRepository.AllIncluding(departament => departament.Categories));
		}

		//
		// GET: /Departaments/Details/5

		public ViewResult Details(int id)
		{
			return View(departamentRepository.Find(id));
		}

		//
		// GET: /Departaments/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Departaments/Create

		[HttpPost]
		public ActionResult Create(Departament departament)
		{
			if (ModelState.IsValid)
			{
				departamentRepository.InsertOrUpdate(departament);
				departamentRepository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		//
		// GET: /Departaments/Edit/5

		public ActionResult Edit(int id)
		{
			return View(departamentRepository.Find(id));
		}

		//
		// POST: /Departaments/Edit/5

		[HttpPost]
		public ActionResult Edit(Departament departament)
		{
			if (ModelState.IsValid)
			{
				departamentRepository.InsertOrUpdate(departament);
				departamentRepository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		//
		// GET: /Departaments/Delete/5

		public ActionResult Delete(int id)
		{
			return View(departamentRepository.Find(id));
		}

		//
		// POST: /Departaments/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			departamentRepository.Delete(id);
			departamentRepository.Save();

			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				departamentRepository.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

