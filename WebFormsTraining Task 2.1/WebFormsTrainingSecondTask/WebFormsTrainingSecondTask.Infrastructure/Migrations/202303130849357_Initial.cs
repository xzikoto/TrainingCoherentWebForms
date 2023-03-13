namespace WebFormsTrainingSecondTask.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "CategoryId", "dbo.Category");
            DropIndex("dbo.Task", new[] { "CategoryId" });
            DropTable("dbo.Category");
            DropTable("dbo.Task");
        }
    }
}
