using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitOf;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public ConversionModel Conversion  { get; set; } = new ConversionModel();
    [BindProperty(SupportsGet = true)]
    public string Input
    {
        get => Conversion.Input;
        set => Conversion.Input = value;
    }
    [BindProperty(SupportsGet = true)]
    public string Output
    {
        get => Conversion.Output;
        set => Conversion.Output = value;
    }
    [BindProperty(SupportsGet = true)]
    public string ConversionType
    {
        get => Conversion.ConversionType;
        set => Conversion.ConversionType = value;
    }

    public void OnGet()
    {
        double inputInt = 0;
        double result = 0;
        if (Conversion.Input == null)
        {
            Conversion.Input = "3.1415";
            Conversion.ConversionType = "MilesToKilometers";
        }
        try
        {
            inputInt = Convert.ToDouble(Conversion.Input, CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            ViewData["ErrorMessage"] = "Input must be a valid number";
            return;
        }

        switch (Conversion.ConversionType)
        {
            case "MilesToKilometers":
                try
                {
                    result = new Length().FromMiles(inputInt).ToKilometers();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            case "KilometersToMiles":
                try
                {
                    result = new Length().FromKilometers(inputInt).ToMiles();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            case "FahrenheitToCelsius":
                try
                {
                    result = new Temperature().FromFahrenheit(inputInt).ToCelsius();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            case "CelsiusToFahrenheit":
                try
                {
                    result = new Temperature().FromCelsius(inputInt).ToFahrenheit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            case "PoundsToKilograms":
                try
                {
                    result = new Mass().FromPounds(inputInt).ToKilograms();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            case "KilogramsToPounds":
                try
                {
                    result = new Mass().FromKilograms(inputInt).ToPounds();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            case "MetersToFeet":
                try
                {
                    result = new Length().FromMeters(inputInt).ToFeet();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            case "FeetToMeters":
                try
                {
                    result = new Length().FromFeet(inputInt).ToMeters();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            default:
                ViewData["ErrorMessage"] = "Invalid conversion type";
                break;

        }
        Conversion.Output = Convert.ToString(result, CultureInfo.InvariantCulture);
        if(ViewData["ErrorMessage"] == null)
        {
            ViewData["ConversionType"] = ConversionTypes.All[Conversion.ConversionType];
        }
        ViewData["Title"] = "Conversions";

    }
}
