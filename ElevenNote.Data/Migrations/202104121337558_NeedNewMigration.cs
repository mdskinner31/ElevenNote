namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NeedNewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Noteid", "dbo.Note");
            DropIndex("dbo.Category", new[] { "Noteid" });
            RenameColumn(table: "dbo.Category", name: "Noteid", newName: "Note_NoteId");
            AlterColumn("dbo.Category", "Note_NoteId", c => c.Int());
            CreateIndex("dbo.Category", "Note_NoteId");
            AddForeignKey("dbo.Category", "Note_NoteId", "dbo.Note", "NoteId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "Note_NoteId", "dbo.Note");
            DropIndex("dbo.Category", new[] { "Note_NoteId" });
            AlterColumn("dbo.Category", "Note_NoteId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Category", name: "Note_NoteId", newName: "Noteid");
            CreateIndex("dbo.Category", "Noteid");
            AddForeignKey("dbo.Category", "Noteid", "dbo.Note", "NoteId", cascadeDelete: true);
        }
    }
}
