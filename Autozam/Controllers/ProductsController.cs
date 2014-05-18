using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autozam.Models;
using System.IO;

namespace Autozam.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ICategoryRepository categoryRepository;
		private readonly IProductRepository productRepository;

		// If you are using Dependency Injection, you can delete the following constructor
		public ProductsController()
			: this(new CategoriesRepository(), new ProductRepository())
		{
		}

		public ProductsController(ICategoryRepository categoryRepository, IProductRepository productRepository)
		{
			this.categoryRepository = categoryRepository;
			this.productRepository = productRepository;
		}

		//
		// GET: /Products/

		public ViewResult Index()
		{
			return View(productRepository.AllIncluding(product => product.Images, product => product.Category));
		}

		//
		// GET: /Products/Details/5

		public ViewResult Details(int id)
		{
			var Product = productRepository.Find(id);
			//Regex regex = new Regex(@"\[img\](.*?)\[/img\]");
			//var v = regex.Match(Product.Description);
			var path = Url.Content(@"~/Images/products/");

			//string s = v.Groups[1].ToString();
			if (!string.IsNullOrWhiteSpace(Product.Description))
			{
				Product.Description = Product.Description.Replace("[img]", "<img src=\"" + path + Product.CategoryId + "/");

				Product.Description = Product.Description.Replace("[/img]", "\" align=\"right\">");
			}
			Product.Category = categoryRepository.Find(Product.CategoryId);
			return View(Product);
		}

		//
		// GET: /Products/Create

		public ActionResult Create()
		{
			ViewBag.PossibleCategories = categoryRepository.All;
			return View();
		}

		//
		// POST: /Products/Create

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Create(Product product)
		{
			if (ModelState.IsValid)
			{
				productRepository.InsertOrUpdate(product);
				productRepository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.PossibleCategories = categoryRepository.All;
				return View();
			}
		}

		//
		// GET: /Products/Edit/5

		public ActionResult Edit(int id)
		{
			ViewBag.PossibleCategories = categoryRepository.All;
			return View(productRepository.Find(id));
		}

		//
		// POST: /Products/Edit/5

		[HttpPost]
		[ValidateInput(false)]
		public ActionResult Edit(Product product)
		{
			if (ModelState.IsValid)
			{
				productRepository.InsertOrUpdate(product);
				productRepository.Save();
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.PossibleCategories = categoryRepository.All;
				return View();
			}
		}

		//
		// GET: /Products/Delete/5

		public ActionResult Delete(int id)
		{
			var Product = productRepository.Find(id);
			//Regex regex = new Regex(@"\[img\](.*?)\[/img\]");
			//var v = regex.Match(Product.Description);
			var path = Url.Content(@"~/Images/products/");

			//string s = v.Groups[1].ToString();
			if (!string.IsNullOrWhiteSpace(Product.Description))
			{
				Product.Description = Product.Description.Replace("[img]", "<img src=\"" + path + Product.CategoryId + "/");

				Product.Description = Product.Description.Replace("[/img]", "\" align=\"right\">");
			}
			Product.Category = categoryRepository.Find(Product.CategoryId);
			return View(Product);
		}

		//
		// POST: /Products/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			productRepository.Delete(id);
			productRepository.Save();

			return RedirectToAction("Index");
		}


		public ActionResult TelewizjaPrzemyslowa()
		{
			return View(productRepository.All.Where(m => m.CategoryId == 27));
		}

		public ActionResult GetPhotos()
		{
			DirectoryInfo directory = new DirectoryInfo(Server.MapPath(@"~/images/products/27"));
			var files = directory.GetFiles().Select(f => f.Name).ToList();
			return PartialView(files);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				categoryRepository.Dispose();
				productRepository.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}

