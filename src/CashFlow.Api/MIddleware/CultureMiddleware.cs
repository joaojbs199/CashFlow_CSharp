using System.Globalization;

namespace CashFlow.Api.MIddleware;

public class CultureMiddleware
{

    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestedCulture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureInfo = new CultureInfo("pt-BR");

        if (
            string.IsNullOrWhiteSpace(requestedCulture) == false
            && supportedCultures.Exists(lang => lang.Name.Equals(requestedCulture))
           )
        {
            cultureInfo = new CultureInfo(requestedCulture);
        }

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
