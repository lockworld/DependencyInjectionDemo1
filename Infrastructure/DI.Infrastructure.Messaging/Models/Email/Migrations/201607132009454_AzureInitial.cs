namespace DI.Infrastructure.Messaging.Models.Email.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AzureInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DIMessaging.EmailMessages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        From = c.String(),
                        To = c.String(),
                        Cc = c.String(),
                        Bcc = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        ReplyTo = c.String(),
                        IsBodyHtml = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Sent = c.DateTime(),
                        Expires = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("DIMessaging.EmailMessages");
        }
    }
}
