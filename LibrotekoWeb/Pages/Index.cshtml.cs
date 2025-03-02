using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Http;
using LibrotekoWeb;

public class IndexModel : PageModel
{  

      
    private readonly IStringLocalizer<SharedResources> _localizer;

    public string WelcomeMessage { get; set; }

    public IndexModel(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }

    public void OnGet()
    {
        WelcomeMessage = _localizer["WelcomeMessage"];
    }

    public IActionResult OnPostSetLanguage(string culture)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

        return RedirectToPage(); // Odświeżenie strony, aby nowy język się załadował
    }
  
}


