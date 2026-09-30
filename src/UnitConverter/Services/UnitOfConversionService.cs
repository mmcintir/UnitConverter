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
            case "MilesToKilometers":
                try
                {
                     result = new Length().FromMiles(inputInt).ToKilometers();
                }
                catch (Exception e)
                {
                    throw new Exception("Invalid input", e);
                }

                break;
            case "KilometersToMiles":
                try
                {
                    result = new Length().FromKilometers(inputInt).ToMiles();
                }
                catch (Exception e)
                {
                    throw new Exception("Invalid input", e);
                }

                break;
            case "FahrenheitToCelsius":
                try
                {
                    result = new Temperature().FromFahrenheit(inputInt).ToCelsius();
                }
                catch (Exception e)
                {
                    throw new Exception("Invalid input", e);
                }

                break;
            case "CelsiusToFahrenheit":
                try
                {
                    result = new Temperature().FromCelsius(inputInt).ToFahrenheit();
                }
                catch (Exception e)
                {
                    throw new Exception("Invalid input", e);
                }

                break;
            case "PoundsToKilograms":
                try
                {
                    result = new Mass().FromPounds(inputInt).ToKilograms();
                }
                catch (Exception e)
                {
                    throw new Exception("Invalid input", e);
                }

                break;
            case "KilogramsToPounds":
                try
                {
                    result = new Mass().FromKilograms(inputInt).ToPounds();
                }
                catch (Exception e)
                {
                    throw new Exception("Invalid input", e);
                }

                break;
            case "MetersToFeet":
                try
                {
                    result = new Length().FromMeters(inputInt).ToFeet();
                }
                catch (Exception e)
                {
                    throw new Exception("Invalid input", e);
                }

                break;
            case "FeetToMeters":
                try
                {
                    result = new Length().FromFeet(inputInt).ToMeters();
                }
                catch (Exception e)
                {
                    throw new Exception("Invalid input", e);
                }

                break;
            default:
                throw new Exception("Invalid conversion type");
        }

        return System.Convert.ToDecimal(result);
    }
}
