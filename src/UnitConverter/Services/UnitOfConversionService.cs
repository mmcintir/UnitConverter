using System.Runtime.InteropServices.JavaScript;
using System.Text;
using UnitConverter.Models;
using UnitOf;

namespace UnitConverter.Services;

public class UnitOfConversionService : IConversionService
{
    public decimal Convert(decimal value, string conversionType)
    {
        double inputInt;
        double result = 0.0;
        try
        {
            inputInt = System.Convert.ToDouble(value);
        }
        catch (Exception e)
        {

            throw new Exception("Error Converting Input", e);
        }
        switch (conversionType)
        {
            case ConversionTypes.MilesToKilometers:
                try
                {
                    result = new Length().FromMiles(inputInt).ToKilometers();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error converting {ConversionTypes.MilesToKilometers}", e);
                }
                break;
            case ConversionTypes.KilometersToMiles:
                try
                {
                    result = new Length().FromKilometers(inputInt).ToMiles();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error converting {ConversionTypes.KilometersToMiles}", e);
                }

                break;
            case ConversionTypes.FahrenheitToCelsius:
                try
                {
                    result = new Temperature().FromFahrenheit(inputInt).ToCelsius();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error converting {ConversionTypes.FahrenheitToCelsius}", e);
                }

                break;
            case ConversionTypes.CelsiusToFahrenheit:
                try
                {
                    result = new Temperature().FromCelsius(inputInt).ToFahrenheit();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error converting {ConversionTypes.CelsiusToFahrenheit}", e);
                }

                break;
            case ConversionTypes.PoundsToKilograms:
                try
                {
                    result = new Mass().FromPounds(inputInt).ToKilograms();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error converting {ConversionTypes.PoundsToKilograms}", e);

                }

                break;
            case ConversionTypes.KilogramsToPounds:
                try
                {
                    result = new Mass().FromKilograms(inputInt).ToPounds();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error converting {ConversionTypes.KilogramsToPounds}", e);
                }

                break;
            case ConversionTypes.MetersToFeet:
                try
                {
                    result = new Length().FromMeters(inputInt).ToFeet();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error converting {ConversionTypes.MetersToFeet}", e);
                }

                break;
            case ConversionTypes.FeetToMeters:
                try
                {
                    result = new Length().FromFeet(inputInt).ToMeters();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error converting {ConversionTypes.FeetToMeters}", e);
                }

                break;
            default:
                throw new Exception("Invalid conversion type");
        }

        return System.Convert.ToDecimal(result);
    }
}
