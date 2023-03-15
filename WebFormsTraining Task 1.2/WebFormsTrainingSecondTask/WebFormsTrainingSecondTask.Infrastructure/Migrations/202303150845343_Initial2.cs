namespace WebFormsTrainingSecondTask.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionOption",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Option = c.String(),
                        QuestionId = c.Guid(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserQuestionAnswer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        QuestionId = c.Guid(nullable: false),
                        OptionId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        Name = c.String(),
                        QuestionOption_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuestionOption", t => t.QuestionOption_Id)
                .Index(t => t.QuestionOption_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserQuestionAnswer", "QuestionOption_Id", "dbo.QuestionOption");
            DropForeignKey("dbo.QuestionOption", "QuestionId", "dbo.Question");
            DropIndex("dbo.UserQuestionAnswer", new[] { "QuestionOption_Id" });
            DropIndex("dbo.QuestionOption", new[] { "QuestionId" });
            DropTable("dbo.UserQuestionAnswer");
            DropTable("dbo.Question");
            DropTable("dbo.QuestionOption");
        }
    }
}
