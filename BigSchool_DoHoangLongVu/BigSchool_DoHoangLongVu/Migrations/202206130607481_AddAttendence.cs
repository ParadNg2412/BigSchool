namespace BigSchool_DoHoangLongVu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        AttendeeId = c.Int(nullable: false),
                        Attendee_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.Attendee_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.Attendee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "Attendee_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Attendences", new[] { "Attendee_Id" });
            DropIndex("dbo.Attendences", new[] { "CourseId" });
            DropTable("dbo.Attendences");
        }
    }
}
