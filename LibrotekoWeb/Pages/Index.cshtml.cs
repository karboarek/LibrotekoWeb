using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using LibrotekoWeb;

public class IndexModel : PageModel
{
    private readonly IStringLocalizer<SharedResources> _localizer;

    public IndexModel(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }

    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Message { get; set; }

    public void OnGet()
    {
    }

    /*public async Task<IActionResult> OnPostSendEmail()
    {
        if (ModelState.IsValid)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Libroteko Contact", "kontakt@libroteko.com"));
            emailMessage.To.Add(new MailboxAddress("Libroteko Support", "kontakt@libroteko.com"));
            emailMessage.Subject = "Nowa wiadomość z formularza kontaktowego";
            emailMessage.Body = new TextPart("plain")
            {
                Text = $"Od: {Name} ({Email})\n\nWiadomość:\n{Message}"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("kontakt@libroteko.com", "Gdanska1/21");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

            TempData["MessageSent"] = "Twoja wiadomość została wysłana!";
        }
        return Page();*/
    public async Task<IActionResult> OnPostSendEmail()
    {
        Console.WriteLine("Formularz został wysłany.");
        foreach (var key in Request.Form.Keys)
        {
            Console.WriteLine($"Klucz: {key}, Wartość: {Request.Form[key]}");
        }

        if (ModelState.IsValid)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Libroteko Contact", "kontakt@libroteko.com"));
            emailMessage.To.Add(new MailboxAddress("Libroteko Support", "kontakt@libroteko.com"));
            emailMessage.Subject = "Nowa wiadomość z formularza kontaktowego";
            emailMessage.Body = new TextPart("plain")
            {
                Text = $"Od: {Name} ({Email})\n\nWiadomość:\n{Message}"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("kontakt@libroteko.com", "Gdanska1/21");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }

            TempData["MessageSent"] = "Twoja wiadomość została wysłana!";
        }
        else
        {
            Console.WriteLine("Niepoprawne dane z formularza.");
        }

        return Page();
    }

}












