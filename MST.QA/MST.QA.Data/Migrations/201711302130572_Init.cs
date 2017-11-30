namespace MST.QA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectComponent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ComponentName = c.String(nullable: false, maxLength: 50),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false, maxLength: 50),
                        ProjectDescription = c.String(),
                        ProjectTypeId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.ProjectType", t => t.ProjectTypeId)
                .Index(t => t.ProjectTypeId);
            
            CreateTable(
                "dbo.ProjectType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestSuite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestSuiteName = c.String(nullable: false, maxLength: 50),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.TestCase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestCaseName = c.String(nullable: false, maxLength: 50),
                        TestCaseDescription = c.String(),
                        TestSuite_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TestSuite", t => t.TestSuite_Id)
                .Index(t => t.TestSuite_Id);
            
            CreateTable(
                "dbo.TestStep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TestStepName = c.String(nullable: false, maxLength: 50),
                        TestStepDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestStepTestCase",
                c => new
                    {
                        TestStep_Id = c.Int(nullable: false),
                        TestCase_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TestStep_Id, t.TestCase_Id })
                .ForeignKey("dbo.TestStep", t => t.TestStep_Id, cascadeDelete: true)
                .ForeignKey("dbo.TestCase", t => t.TestCase_Id, cascadeDelete: true)
                .Index(t => t.TestStep_Id)
                .Index(t => t.TestCase_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestCase", "TestSuite_Id", "dbo.TestSuite");
            DropForeignKey("dbo.TestStepTestCase", "TestCase_Id", "dbo.TestCase");
            DropForeignKey("dbo.TestStepTestCase", "TestStep_Id", "dbo.TestStep");
            DropForeignKey("dbo.TestSuite", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "ProjectTypeId", "dbo.ProjectType");
            DropForeignKey("dbo.ProjectComponent", "ProjectId", "dbo.Project");
            DropIndex("dbo.TestStepTestCase", new[] { "TestCase_Id" });
            DropIndex("dbo.TestStepTestCase", new[] { "TestStep_Id" });
            DropIndex("dbo.TestCase", new[] { "TestSuite_Id" });
            DropIndex("dbo.TestSuite", new[] { "ProjectId" });
            DropIndex("dbo.Project", new[] { "ProjectTypeId" });
            DropIndex("dbo.ProjectComponent", new[] { "ProjectId" });
            DropTable("dbo.TestStepTestCase");
            DropTable("dbo.TestStep");
            DropTable("dbo.TestCase");
            DropTable("dbo.TestSuite");
            DropTable("dbo.ProjectType");
            DropTable("dbo.Project");
            DropTable("dbo.ProjectComponent");
        }
    }
}
