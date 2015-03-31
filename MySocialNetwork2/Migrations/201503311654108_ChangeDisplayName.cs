namespace MySocialNetwork2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDisplayName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagTasks", newName: "TaskTag");
            RenameColumn(table: "dbo.TaskTag", name: "Tag_ID", newName: "TagID");
            RenameColumn(table: "dbo.TaskTag", name: "Task_ID", newName: "TaskID");
            RenameIndex(table: "dbo.TaskTag", name: "IX_Task_ID", newName: "IX_TaskID");
            RenameIndex(table: "dbo.TaskTag", name: "IX_Tag_ID", newName: "IX_TagID");
            DropPrimaryKey("dbo.TaskTag");
            AddPrimaryKey("dbo.TaskTag", new[] { "TaskID", "TagID" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TaskTag");
            AddPrimaryKey("dbo.TaskTag", new[] { "Tag_ID", "Task_ID" });
            RenameIndex(table: "dbo.TaskTag", name: "IX_TagID", newName: "IX_Tag_ID");
            RenameIndex(table: "dbo.TaskTag", name: "IX_TaskID", newName: "IX_Task_ID");
            RenameColumn(table: "dbo.TaskTag", name: "TaskID", newName: "Task_ID");
            RenameColumn(table: "dbo.TaskTag", name: "TagID", newName: "Tag_ID");
            RenameTable(name: "dbo.TaskTag", newName: "TagTasks");
        }
    }
}
