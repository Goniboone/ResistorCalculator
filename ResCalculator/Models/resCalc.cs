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
            case "None": return 20;
            // Pink has no tolerance percentage
            case "Silver": return 10;
            case "Gold": return 5;
            // Black has no tolerance percentage either
            case "Brown": return 1;
            case "Red": return 2;
            case "Orange": return .05;
            case "Yellow": return .02;
            case "Green": return .5;
            case "Blue": return .25;
            case "Violet": return .1;
            case "Grey": return .01;
            // White has no tolerance percentage either
            default: return 0;
        }
    }
    public double CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor)
     {
        var ohms = "0";

        switch (bandAColor)
        {
            case "Brown":
                ohms = "1";
                break;
            case "Red":
                ohms = "2";
                break;
            case "Orange":
                ohms = "3";
                break;
            case "Yellow":
                ohms = "4";
                break;
            case "Green":
                ohms = "5";
                break;
            case "Blue":
                ohms = "6";
                break;
            case "Violet":
                ohms = "7";
                break;
            case "Grey":
                ohms = "8";
                break;
            case "White":
                ohms = "9";
                break;
            default:
                break;
        }

        switch (bandBColor)
        {
            case "Brown":
                ohms += "1";
                break;
            case "Red":
                ohms += "2";
                break;
            case "Orange":
                ohms += "3";
                break;
            case "Yellow":
                ohms += "4";
                break;
            case "Green":
                ohms += "5";
                break;
            case "Blue":
                ohms += "6";
                break;
            case "Violet":
                ohms += "7";
                break;
            case "Grey":
                ohms += "8";
                break;
            case "White":
                ohms += "9";
                break;
            default:
                break;
        }

        switch (bandCColor)
        {
            case "Pink":
                return .001 * double.Parse(ohms);
            case "Silver":
                return .01 * double.Parse(ohms);
            case "Gold":
                return .1 * double.Parse(ohms);
            // case 4 would just multiply by 1x
            case "Brown":
                return 10 * double.Parse(ohms);
            case "Red":
                return 100 * double.Parse(ohms);
            case "Orange":
                return 1000 * double.Parse(ohms);
            case "Yellow":
                return 10000 * double.Parse(ohms);
            case "Green":
                return 100000 * double.Parse(ohms);
            case "Blue":
                return 1000000 * double.Parse(ohms);
            case "Violet":
                return 10000000 * double.Parse(ohms);
            case "Grey":
                return 100000000 * double.Parse(ohms);
            case "White":
                return 1000000000 * double.Parse(ohms);
            default:
                break;
        }

        return double.Parse(ohms);
     }
}