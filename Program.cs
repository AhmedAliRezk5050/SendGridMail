using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendGrid;
using SendGrid.Helpers.Mail;

using IHost host = Host.CreateDefaultBuilder(args).Build();
var config = host.Services.GetRequiredService<IConfiguration>();

var apiKey = config.GetValue<string>("SendGridApiKey");
var fromEmail = config.GetValue<string>("FromEmail");
var fromName = config.GetValue<string>("FromName");
if (string.IsNullOrEmpty(apiKey)) throw new Exception("SendGridApiKey should not be null or empty");
if (string.IsNullOrEmpty(fromEmail)) throw new Exception("FromEmail should not be null or empty");
if (string.IsNullOrEmpty(fromName)) throw new Exception("FromName should not be null or empty");

Console.Write("To: ");
var toEmail = Console.ReadLine();

Console.Write("Subject: ");
var subject = Console.ReadLine();

Console.Write("Body: ");
var body = Console.ReadLine();

var client = new SendGridClient(apiKey);
var msg = new SendGridMessage()
{
    From = new EmailAddress(fromEmail, fromName),
    Subject = subject,
    PlainTextContent = body
};


msg.AddTo(new EmailAddress(toEmail));
var response = await client.SendEmailAsync(msg);

Console.WriteLine(response.IsSuccessStatusCode ? "Email queued successfully!" : "Something went wrong!");
