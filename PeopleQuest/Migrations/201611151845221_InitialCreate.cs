namespace PeopleQuest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 35),
                        LastName = c.String(maxLength: 35),
                        BirthDate = c.DateTime(nullable: false),
                        Address1 = c.String(maxLength: 50),
                        Address2 = c.String(maxLength: 50),
                        Interests = c.String(maxLength: 100),
                        Image = c.Binary(storeType: "image"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
