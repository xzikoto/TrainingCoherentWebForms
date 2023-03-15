namespace WebFormsTrainingSecondTask.Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialSecond : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Age = c.Int(nullable: false),
                        GenderId = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gender", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "GenderId", "dbo.Gender");
            DropIndex("dbo.User", new[] { "GenderId" });
            DropTable("dbo.Gender");
            DropTable("dbo.User");
        }
    }
}
