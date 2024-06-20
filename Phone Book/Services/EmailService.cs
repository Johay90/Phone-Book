﻿using MailKit.Net.Smtp;
using MimeKit;

public class EmailService : IMessagingService
{
    public void Send(Contact to, string title, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Jonathan M", "Test@email.com"));
        message.To.Add(new MailboxAddress(to.Name, to.EmailAddresses.First().EmailAddress));
        message.Subject = title;

        message.Body = new TextPart("plain")
        { Text = body };

        using (var client = new SmtpClient())
        {
            client.Connect("127.0.0.1", 25, false);

            // Note: only needed if the SMTP server requires authentication
            // client.Authenticate("username", "password");

            client.Send(message);
            client.Disconnect(true);
        }
    }
}
