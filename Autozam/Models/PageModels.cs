using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Autozam.Models
{
	public class PageModels : DbContext
	{
		public PageModels()
			: base("AutozamConnectionString")
		{
		}

		public DbSet<Departament> Departaments { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Image> Images { get; set; }
	}
	[Table("Departament")]
	public class Departament
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public int? Order { get; set; }
		public virtual ICollection<Category> Categories { get; set; }
	}
	[Table("Category")]
	public class Category
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Display(Name = "Nazwa")]
		public string Name { get; set; }
		[Display(Name = "Opis")]
		public string Description { get; set; }
		[Display(Name = "Kolejność")]
		public int? Order { get; set; }
		public int DepartamentId { get; set; }

		public ICollection<Product> Products { get; set; }

	}
	[Table("Product")]
	public class Product
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Display(Name = "Nazwa")]
		public string Name { get; set; }
		[Display(Name = "Opis:")]
		public string Description { get; set; }
		[Display(Name = "Już od ")]
		public decimal? PriceFrom { get; set; }
		[Display(Name = " do ")]
		public decimal? PriceTo { get; set; }
		public ICollection<Image> Images { get; set; }

		public int CategoryId { get; set; }
		[Display(Name = "Kategoria:")]
		public Category Category { get; set; }
		[Display(Name = "Kolejność:")]
		public int? Order { get; set; }

	}
	[Table("Image")]
	public class Image
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Name { get; set; }
		public bool? isMain { get; set; }
	}


}