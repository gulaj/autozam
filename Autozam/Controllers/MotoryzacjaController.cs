using Autozam.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Autozam.Controllers
{
	public class MotoryzacjaController : Controller
	{
		//
		// GET: /Motoryzacja/
		PageModels context = new PageModels();

		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Asortyment()
		{
			List<int> zakres = new List<int>
			{
				1,2
			};
			var categories = context.Categories.Where(cat => zakres.Contains(cat.DepartamentId)).OrderBy(c => c.Order);
			return View(categories);
		}
		public ActionResult Kategoria(int id)
		{
			var description = context.Categories.Where(cat => cat.Id == id).FirstOrDefault();
			return View(description);

		}


		public ActionResult Produkt(int id)
		{
			var Product = context.Products.Where(p => p.Id == id).FirstOrDefault();
			//Regex regex = new Regex(@"\[img\](.*?)\[/img\]");
			//var v = regex.Match(Product.Description);
			var path = Url.Content(@"~/Images/products/");

			//string s = v.Groups[1].ToString();
			if (!string.IsNullOrWhiteSpace(Product.Description))
			{
				Product.Description = Product.Description.Replace("[img]", "<img src=\"" + path + Product.CategoryId + "/");

				Product.Description = Product.Description.Replace("[/img]", "\" align=\"right\">");
			}
			return View(Product);
		}

		public ActionResult _ListaProduktow(int id)
		{
			var items = context.Products.Where(p => p.CategoryId == id);
			return PartialView(items);
		}
	}
}
