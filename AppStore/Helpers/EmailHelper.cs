using MimeKit;

namespace AppStore.Helpers
{
    public class EmailHelper
    {
        public static async Task<bool> SendMailAsync(string email, string text)
        {
            try
            {
                MimeMessage messege = new MimeMessage();
                messege.From.Add(MailboxAddress.Parse("noreply1069@gmail.com"));
                messege.To.Add(MailboxAddress.Parse(email));
                messege.Subject = "Messege from AppStore";
                messege.Body = new BodyBuilder() { HtmlBody = $"<h2 style\"color=red\">{text}</h2>" }.ToMessageBody();

                using MailKit.Net.Smtp.SmtpClient client = new();
                await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("noreply1069@gmail.com", "ncvmzytndquvxwyf");
                await client.SendAsync(messege);
                await client.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
