public interface IOhmValueCalculator
{
   /// <summary>
   /// Calculates the Ohm value of a resistor based on the band colors.
   /// </summary>
   /// <param name="bandAColor">The color of the first figure of component value band.</param>
   /// <param name="bandBColor">The color of the second significant figure band.</param>
   /// <param name="bandCColor">The color of the decimal multiplier band.</param>
   /// <param name="bandDColor">The color of the tolerance value band.</param>
   double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor);
   double GetTolerance(string bandDColor);
}


public class OhmValueCalc : IOhmValueCalculator
{

    public double GetTolerance(string bandDColor)
    {
        switch (bandDColor)
        {
            case "0": return 20;
            // Pink has no tolerance percentage
            case "2": return 10;
            case "3": return 5;
            // Black has no tolerance percentage either
            case "5": return 1;
            case "6": return 2;
            case "7": return .05;
            case "8": return .02;
            case "9": return .5;
            case "10": return .25;
            case "11": return .1;
            case "12": return .01;
            // White has no tolerance percentage either
            default: return 0;
        }
    }
    public double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor)
     {
        var ohms = "0";

        switch (bandAColor)
        {
            case "5":
                ohms = "1";
                break;
            case "6":
                ohms = "2";
                break;
            case "7":
                ohms = "3";
                break;
            case "8":
                ohms = "4";
                break;
            case "9":
                ohms = "5";
                break;
            case "10":
                ohms = "6";
                break;
            case "11":
                ohms = "7";
                break;
            case "12":
                ohms = "8";
                break;
            case "13":
                ohms = "9";
                break;
            default:
                break;
        }

        switch (bandBColor)
        {
            case "5":
                ohms += "1";
                break;
            case "6":
                ohms += "2";
                break;
            case "7":
                ohms += "3";
                break;
            case "8":
                ohms += "4";
                break;
            case "9":
                ohms += "5";
                break;
            case "10":
                ohms += "6";
                break;
            case "11":
                ohms += "7";
                break;
            case "12":
                ohms += "8";
                break;
            case "13":
                ohms += "9";
                break;
            default:
                break;
        }

        switch (bandCColor)
        {
            case "1":
                return .001 * double.Parse(ohms);
            case "2":
                return .01 * double.Parse(ohms);
            case "3":
                return .1 * double.Parse(ohms);
            // case 4 would just multiply by 1x
            case "5":
                return 10 * double.Parse(ohms);
            case "6":
                return 100 * double.Parse(ohms);
            case "7":
                return 1000 * double.Parse(ohms);
            case "8":
                return 10000 * double.Parse(ohms);
            case "9":
                return 100000 * double.Parse(ohms);
            case "10":
                return 1000000 * double.Parse(ohms);
            case "11":
                return 10000000 * double.Parse(ohms);
            case "12":
                return 100000000 * double.Parse(ohms);
            case "13":
                return 1000000000 * double.Parse(ohms);
            default:
                break;
        }

        return double.Parse(ohms);
     }
}