using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;
using UnitConverter.Services;

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

    public decimal Output { get; set; }

    public bool HasOutput { get; set; }

    private readonly IConversionService _conversionService;

    public QuickConversionsModel(IConversionService conversionService)
    {
        _conversionService = conversionService;
    }
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

    public IActionResult OnGetMilesToKilometers(string input)
    {
        return PerformConversion(input,  ConversionTypes.MilesToKilometers);
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        return PerformConversion(input,  ConversionTypes.KilometersToMiles);
    }
    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return PerformConversion(input,  ConversionTypes.FahrenheitToCelsius);
    }
    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return PerformConversion(input,  ConversionTypes.CelsiusToFahrenheit);
    }
    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return PerformConversion(input,  ConversionTypes.PoundsToKilograms);
    }
    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return PerformConversion(input,  ConversionTypes.KilogramsToPounds);
    }
    public IActionResult OnGetMetersToFeet(string input)
    {
        return PerformConversion(input,  ConversionTypes.MetersToFeet);
    }
    public IActionResult OnGetFeetToMeters(string input)
    {
        return PerformConversion(input,  ConversionTypes.FeetToMeters);
    }

    private IActionResult PerformConversion(string input, string conversionType)
    {
        try
        {
            Output = _conversionService.Convert(Convert.ToDecimal(input),conversionType);
            HasOutput = true;
        }
        catch (Exception e)
        {
            ViewData["ErrorMessage"] = e.Message;
        }
        return Page();

    }

}
