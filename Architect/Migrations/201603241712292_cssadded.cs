namespace Architect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cssadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        ContentId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContentId);
            
            CreateTable(
                "dbo.PageContent",
                c => new
                    {
                        PageContentId = c.Int(nullable: false, identity: true),
                        PageId = c.Int(nullable: false),
                        ContentId = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PageContentId)
                .ForeignKey("dbo.Pages", t => t.PageId)
                .ForeignKey("dbo.Content", t => t.ContentId)
                .Index(t => t.PageId)
                .Index(t => t.ContentId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        TemplateId = c.Int(),
                        PageName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.Templates", t => t.TemplateId)
                .Index(t => t.TemplateId);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        TemplateId = c.Int(nullable: false, identity: true),
                        CssFileId = c.Int(),
                        TemplateName = c.String(nullable: false, maxLength: 50),
                        Template = c.String(),
                    })
                .PrimaryKey(t => t.TemplateId);
            
            CreateTable(
                "dbo.CssFiles",
                c => new
                    {
                        CssFileId = c.Int(nullable: false, identity: true),
                        CssStyles = c.String(),
                    })
                .PrimaryKey(t => t.CssFileId);
            
            CreateTable(
                "dbo.CssFileTemplates",
                c => new
                    {
                        CssFile_CssFileId = c.Int(nullable: false),
                        Template_TemplateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CssFile_CssFileId, t.Template_TemplateId })
                .ForeignKey("dbo.CssFiles", t => t.CssFile_CssFileId, cascadeDelete: true)
                .ForeignKey("dbo.Templates", t => t.Template_TemplateId, cascadeDelete: true)
                .Index(t => t.CssFile_CssFileId)
                .Index(t => t.Template_TemplateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageContent", "ContentId", "dbo.Content");
            DropForeignKey("dbo.Pages", "TemplateId", "dbo.Templates");
            DropForeignKey("dbo.CssFileTemplates", "Template_TemplateId", "dbo.Templates");
            DropForeignKey("dbo.CssFileTemplates", "CssFile_CssFileId", "dbo.CssFiles");
            DropForeignKey("dbo.PageContent", "PageId", "dbo.Pages");
            DropIndex("dbo.CssFileTemplates", new[] { "Template_TemplateId" });
            DropIndex("dbo.CssFileTemplates", new[] { "CssFile_CssFileId" });
            DropIndex("dbo.Pages", new[] { "TemplateId" });
            DropIndex("dbo.PageContent", new[] { "ContentId" });
            DropIndex("dbo.PageContent", new[] { "PageId" });
            DropTable("dbo.CssFileTemplates");
            DropTable("dbo.CssFiles");
            DropTable("dbo.Templates");
            DropTable("dbo.Pages");
            DropTable("dbo.PageContent");
            DropTable("dbo.Content");
        }
    }
}
