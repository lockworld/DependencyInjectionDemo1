using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DI.Infrastructure.Messaging.Models.Email
{
    [Table("EmailMessages",Schema="DIMessaging")]
    public class EmailMessage
    {
        public Guid Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Cc { get; set; }

        public string Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string ReplyTo { get; set; }

        public bool IsBodyHtml { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime? Sent { get; set; }

        [Required]
        public DateTime Expires { get; set; }
    }
}
