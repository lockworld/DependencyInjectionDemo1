using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Infrastructure.Messaging.Models.Email
{
    public class EmailDbContext : DbContext
    {
        public EmailDbContext() :
            base("MailQueue")
        {
            //Debug.Write(Database.Connection.ConnectionString);
        }

        public DbSet<EmailMessage> Email { get; set; }
    }

    public class MyDbInitializer : CreateDatabaseIfNotExists<DbContext>
    {
        
    }
}
