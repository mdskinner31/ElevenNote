namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Note_NoteId", "dbo.Note");
            DropIndex("dbo.Category", new[] { "Note_NoteId" });
            RenameColumn(table: "dbo.Category", name: "Note_NoteId", newName: "Noteid");
            AlterColumn("dbo.Category", "Noteid", c => c.Int(nullable: false));
            CreateIndex("dbo.Category", "Noteid");
            AddForeignKey("dbo.Category", "Noteid", "dbo.Note", "NoteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "Noteid", "dbo.Note");
            DropIndex("dbo.Category", new[] { "Noteid" });
            AlterColumn("dbo.Category", "Noteid", c => c.Int());
            RenameColumn(table: "dbo.Category", name: "Noteid", newName: "Note_NoteId");
            CreateIndex("dbo.Category", "Note_NoteId");
            AddForeignKey("dbo.Category", "Note_NoteId", "dbo.Note", "NoteId");
        }
    }
}
