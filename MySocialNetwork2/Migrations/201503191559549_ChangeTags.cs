namespace MySocialNetwork2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTags : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagTasks", "Tag_ID", "dbo.Tags");
            DropIndex("dbo.TagTasks", new[] { "Tag_ID" });
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.TagTasks");
            AlterColumn("dbo.Tags", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TagTasks", "Tag_ID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Tags", "ID");
            AddPrimaryKey("dbo.TagTasks", new[] { "Tag_ID", "Task_ID" });
            CreateIndex("dbo.TagTasks", "Tag_ID");
            AddForeignKey("dbo.TagTasks", "Tag_ID", "dbo.Tags", "ID", cascadeDelete: true);
            DropColumn("dbo.Tags", "ContentOfTag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "ContentOfTag", c => c.String());
            DropForeignKey("dbo.TagTasks", "Tag_ID", "dbo.Tags");
            DropIndex("dbo.TagTasks", new[] { "Tag_ID" });
            DropPrimaryKey("dbo.TagTasks");
            DropPrimaryKey("dbo.Tags");
            AlterColumn("dbo.TagTasks", "Tag_ID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TagTasks", new[] { "Tag_ID", "Task_ID" });
            AddPrimaryKey("dbo.Tags", "ID");
            CreateIndex("dbo.TagTasks", "Tag_ID");
            AddForeignKey("dbo.TagTasks", "Tag_ID", "dbo.Tags", "ID", cascadeDelete: true);
        }
    }
}
