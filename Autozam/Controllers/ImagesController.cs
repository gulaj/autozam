using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autozam.Models;

namespace Autozam.Controllers
{
	public class ImagesController : Controller
	{
		private readonly IImageRepository imageRepository;

		// If you are using Dependency Injection, you can delete the following constructor
		public ImagesController()
			: this(new ImageRepository())
		{
		}

		public ImagesController(IImageRepository imageRepository)
		{
			this.imageRepository = imageRepository;
		}

		//
		// GET: /Images/

		public ViewResult Index()
		{
			return View(imageRepository.All);
		}

		//
		// GET: /Images/Details/5

		public ViewResult Details(int id)
		{
			return View(imageRepository.Find(id));
		}

		//
		// GET: /Images/Create

		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Images/Create

		[HttpPost]
		public ActionResult Create(Image image)
		{
			if (ModelState.IsValid)
			{
				imageRepository.InsertOrUpdate(image);
				imageRepository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		//
		// GET: /Images/Edit/5

		public ActionResult Edit(int id)
		{
			return View(imageRepository.Find(id));
		}

		//
		// POST: /Images/Edit/5

		[HttpPost]
		public ActionResult Edit(Image image)
		{
			if (ModelState.IsValid)
			{
				imageRepository.InsertOrUpdate(image);
				imageRepository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}

		//
		// GET: /Images/Delete/5

		public ActionResult Delete(int id)
		{
			return View(imageRepository.Find(id));
		}

		//
		// POST: /Images/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			imageRepository.Delete(id);
			imageRepository.Save();

			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				imageRepository.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

