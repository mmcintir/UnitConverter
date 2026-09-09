using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitOf;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Input { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;


    public void OnGet()
    {
        double inputInt = 0;
        double result = 0;
        if (Input == string.Empty)
        {
            Input = "3.1415";
            ConversionType = "MilesToKilometers";
        }
        try
        {
            inputInt = Convert.ToDouble(Input, CultureInfo.InvariantCulture);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            ViewData["ErrorMessage"] = "Input must be a valid number";
            return;
        }

        switch (ConversionType)
        {
            case "MilesToKilometers":
                try
                {
                    result = new Length().FromMiles(inputInt).ToKilometers();
                    ConversionType = "Miles to Kilometers";
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
                    ConversionType = "Kilometers to Miles";
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
                    ConversionType = "Fahrenheit to Celsius";
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
                    ConversionType = "Celsius to Fahrenheit";
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
                    ConversionType = "Pounds to Kilograms";
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
                    ConversionType = "Kilograms to Pounds";
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
                    ConversionType = "Meters to Feet";
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
                    ConversionType = "Feet to Meters";
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
        Output = Convert.ToString(result, CultureInfo.InvariantCulture);
        ViewData["ConversionType"] = ConversionType;
        ViewData["Title"] = "Conversions";

    }
}
