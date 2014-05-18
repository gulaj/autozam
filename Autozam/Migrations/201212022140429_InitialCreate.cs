namespace Autozam.Migrations
{
	using System;
	using System.Data.Entity.Migrations;

	public partial class InitialCreate : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"dbo.Departament",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(),
						Order = c.Int(nullable: false),
					})
				.PrimaryKey(t => t.Id);

			CreateTable(
				"dbo.Category",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(),
						Description = c.String(),
						Order = c.Int(nullable: false),
						DepartamentId = c.Int(nullable: false),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Departament", t => t.DepartamentId, cascadeDelete: true)
				.Index(t => t.DepartamentId);

			CreateTable(
				"dbo.Product",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(),
						Description = c.String(),
						PriceFrom = c.Decimal(nullable: false, precision: 18, scale: 2),
						PriceTo = c.Decimal(nullable: false, precision: 18, scale: 2),
						CategoryId = c.Int(nullable: false),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
				.Index(t => t.CategoryId);

			CreateTable(
				"dbo.Image",
				c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(),
						Product_Id = c.Int(),
						isMain = c.Boolean()
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("dbo.Product", t => t.Product_Id)
				.Index(t => t.Product_Id);

		}

		public override void Down()
		{
			DropIndex("dbo.Image", new[] { "Product_Id" });
			DropIndex("dbo.Product", new[] { "CategoryId" });
			DropIndex("dbo.Category", new[] { "DepartamentId" });
			DropForeignKey("dbo.Image", "Product_Id", "dbo.Product");
			DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
			DropForeignKey("dbo.Category", "DepartamentId", "dbo.Departament");
			DropTable("dbo.Image");
			DropTable("dbo.Product");
			DropTable("dbo.Category");
			DropTable("dbo.Departament");
		}
	}
}
