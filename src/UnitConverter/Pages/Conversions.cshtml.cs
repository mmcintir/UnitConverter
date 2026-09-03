using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = "3.1415";
    public string Output { get; set; } = string.Empty;

    public void OnGet()
    {
        Input = "3.1415";
        ViewData["ConversionType"] = "Miles to Kilometers";
        ViewData["Title"] = "Conversions";
        double miles = Convert.ToDouble(Input);
        UnitOf.Length conversion = new UnitOf.Length().FromMiles(miles);
        Output = Convert.ToString(conversion.ToKilometers(), CultureInfo.InvariantCulture);
    }
}
