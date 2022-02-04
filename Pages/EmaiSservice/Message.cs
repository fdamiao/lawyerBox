using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeblawyersBox.Pages.EmaiSservice
{
    public class Message
    {
        public MailboxAddress To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(string  to, string subject, string content)
        {
            //To = new MailboxAddress();

            //To.AddRange(to.Select(x => new MailboxAddress(to.ToString())));
            To= (new MailboxAddress("LawyerBox", to));
            Subject = subject;
            Content = content;
        }
    }
}
