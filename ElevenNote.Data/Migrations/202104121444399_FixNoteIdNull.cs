namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNoteIdNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Noteid", "dbo.Note");
            DropIndex("dbo.Category", new[] { "Noteid" });
            DropColumn("dbo.Category", "Noteid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Noteid", c => c.Int(nullable: false));
            CreateIndex("dbo.Category", "Noteid");
            AddForeignKey("dbo.Category", "Noteid", "dbo.Note", "NoteId", cascadeDelete: true);
        }
    }
}
