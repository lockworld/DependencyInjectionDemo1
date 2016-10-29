using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Infrastructure.Messaging.Models.Email.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EmailDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Models\Email\Migrations";
        }

        protected override void Seed(EmailDbContext context)
        {
            context.Email.Add(new EmailMessage
            {
                To = "dlockwood@mcrel.org",
                From = "dlockwood@mcrel.org",
                Subject = "Sample Email",
                Body = "This is just a test",
                IsBodyHtml = false,
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(1)
            });
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
