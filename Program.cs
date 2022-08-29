using SendGrid;
using SendGrid.Helpers.Mail;

var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
var client = new SendGridClient(apiKey);
var msg = new SendGridMessage()
{
    From = new EmailAddress("ahmedalirezk5050@gmail.com", "ahmed ali"),
    Subject = "Sending with Twilio SendGrid is Fun",
    PlainTextContent = "and easy to do anywhere, especially with C#"
};
msg.AddTo(new EmailAddress("practisedev5050@gmail.com", "practise dev"));
var response = await client.SendEmailAsync(msg);

// A success status code means SendGrid received the email request and will process it.
// Errors can still occur when SendGrid tries to send the email. 
// If email is not received, use this URL to debug: https://app.sendgrid.com/email_activity 
Console.WriteLine(response.IsSuccessStatusCode ? "Email queued successfully!" : "Something went wrong!");
