using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Autozam.Models
{
	public class UsersContext : DbContext
	{
		public UsersContext()
			: base("AutozamConnectionString")
		{
		}

		public DbSet<UserProfile> UserProfiles { get; set; }
	}

	[Table("UserProfile")]
	public class UserProfile
	{
		[Key]
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int UserId { get; set; }
		public string UserName { get; set; }
	}

	public class RegisterExternalLoginModel
	{
		[Required]
		[Display(Name = "Nazwa użytkownika")]
		public string UserName { get; set; }

		public string ExternalLoginData { get; set; }
	}

	public class LocalPasswordModel
	{
		[Required(ErrorMessage = "Podanie bieżącega hasła jest wymagane")]
		[DataType(DataType.Password)]
		[Display(Name = "Bieżące hasło")]
		public string OldPassword { get; set; }

		[Required(ErrorMessage = "Podanie nowego hasła jest wymagane")]
		[StringLength(100, ErrorMessage = "{0} musi mieć conajmniej {2} znaków.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Nowe hasło")]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Potwierdź hasło")]
		[Compare("NewPassword", ErrorMessage = "Hasło i potwierdzenie hasła są niezgodne.")]
		public string ConfirmPassword { get; set; }
	}

	public class LoginModel
	{
		[Required]
		[Display(Name = "Użytkownik")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Hasło")]
		public string Password { get; set; }

		[Display(Name = "Logowanie automatyczne?")]
		public bool RememberMe { get; set; }
	}

	public class RegisterModel
	{
		[Required]
		[Display(Name = "Nazwa użytkownika")]
		public string UserName { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Hasło")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Potwierdzenie hasła")]
		[Compare("Password", ErrorMessage = "Hasło i potwierdzenie hasła są niezgodne.")]
		public string ConfirmPassword { get; set; }
	}

	public class ExternalLogin
	{
		public string Provider { get; set; }
		public string ProviderDisplayName { get; set; }
		public string ProviderUserId { get; set; }
	}
}
