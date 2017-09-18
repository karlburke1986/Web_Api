namespace Task3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Texts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumberSender = c.Int(nullable: false),
                        NumberReceiver = c.Int(nullable: false),
                        Message = c.String(maxLength: 140),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Texts");
        }
    }
}
