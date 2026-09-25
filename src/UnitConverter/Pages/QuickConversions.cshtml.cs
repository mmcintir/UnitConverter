using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UnitConverter.Pages;

public class QuickConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public double Miles { get; set; }

    [BindProperty(SupportsGet = true)]
    public double Kilometers { get; set; }

    [BindProperty(SupportsGet = true)]
    public double Fahrenheit { get; set; }

    [BindProperty(SupportsGet = true)]
    public double Celsius { get; set; }

    [BindProperty(SupportsGet = true)]
    public double Pounds { get; set; }

    [BindProperty(SupportsGet = true)]
    public double Kilograms { get; set; }

    [BindProperty(SupportsGet = true)]
    public double Meters { get; set; }

    [BindProperty(SupportsGet = true)]
    public double Feet { get; set; }

    public IEnumerable<SelectListItem> PoundOptions =>
    [
        new("1 pound", "1"),
        new("5 pounds", "5"),
        new("10 pounds", "10"),
        new("25 pounds", "25"),
        new("50 pounds", "50")
    ];

    public void OnGet()
    {
    }

    public IActionResult OnGetMilesToKilometers(string? input)
    {
        return RedirectToConversion(ConversionTypes.MilesToKilometers, input);
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        return RedirectToConversion(ConversionTypes.KilometersToMiles, input);
    }
    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return RedirectToConversion(ConversionTypes.FahrenheitToCelsius, input);
    }
    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return RedirectToConversion(ConversionTypes.CelsiusToFahrenheit, input);
    }
    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return RedirectToConversion(ConversionTypes.PoundsToKilograms, input);
    }
    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return RedirectToConversion(ConversionTypes.KilogramsToPounds, input);
    }
    public IActionResult OnGetMetersToFeet(string input)
    {
        return RedirectToConversion(ConversionTypes.MetersToFeet, input);
    }
    public IActionResult OnGetFeetToMeters(string input)
    {
        return RedirectToConversion(ConversionTypes.FeetToMeters, input);
    }
    private IActionResult RedirectToConversion(string conversionType, string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return Page();
        }

        return RedirectToPage("/Conversions", new { ConversionType = conversionType, Input = input.Trim() });
    }
}
