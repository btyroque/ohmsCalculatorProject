using System;

namespace OhmCalculatorWeb
{
    public interface IOhmValueCalculator
    {
        /// <summary>
        /// Calculates the Ohm value of a resistor based on the band colors.
        /// </summary>
        /// <param name="bandAColor">The color of the first figure of component value band.</param>
        /// <param name="bandBColor">The color of the second significant figure band.</param>
        /// <param name="bandCColor">The color of the decimal multiplier band.</param>
        /// <param name="bandDColor">The color of the tolerance value band.</param>
        int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor);
    }

    public class OhmCalculatorClass : IOhmValueCalculator
    {
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            return new Resistor(bandAColor, bandBColor, bandCColor, bandDColor).CalculateOhm();
        }

        public string CalculateOhmAndTolerance(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            return new Resistor(bandAColor, bandBColor, bandCColor, bandDColor).CalculateOhmAndTolerance();
        }
    }

    public class Resistor
    {
        ColorCode firstBand;
        ColorCode secondBand;
        ColorCode multiplierBand;
        ColorCode toleranceBand;

        public Resistor(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            try
            {
                firstBand = new ColorCode((BandColor)Enum.Parse(typeof(BandColor), bandAColor));
                secondBand = new ColorCode((BandColor)Enum.Parse(typeof(BandColor), bandBColor));
                multiplierBand = new ColorCode((BandColor)Enum.Parse(typeof(BandColor), bandCColor));
                toleranceBand = new ColorCode((BandColor)Enum.Parse(typeof(BandColor), bandDColor));
            }
            catch (ArgumentException)
            {
                throw new ResistorBandColorException();
            }
        }

        public int CalculateOhm()
        {
            int result = 0;
            try
            {
                result = (firstBand.SignificantDigits.Value * 10 + secondBand.SignificantDigits.Value) * multiplierBand.Multiplier.Value;
            }
            catch (Exception)
            {
                throw new ResistorBandColorException();
            }
            return result;
        }

        public string CalculateOhmAndTolerance()
        {
            string result = "";
            try
            {
                result = CalculateOhm() + " ohms " + toleranceBand.Tolerance.getTolerance();
            }
            catch (Exception)
            {
                result = "Wrong color band configuration";
            }
            return result;
        }
    }

    public class ColorCode
    {
        public int? SignificantDigits { get; }
        public int? Multiplier { get; }
        public Tolerance Tolerance { get; }

        public ColorCode(BandColor bandColor)
        {
            SignificantDigits = null;
            Multiplier = null;
            Tolerance = new Tolerance(0);

            switch (bandColor)
            {
                case BandColor.Black:
                    {
                        SignificantDigits = 0;
                        Multiplier = 1;
                        return;
                    }
                case BandColor.Brown:
                    {
                        SignificantDigits = 1;
                        Multiplier = 10;
                        Tolerance = new Tolerance(1);
                        return;
                    }
                case BandColor.Red:
                    {
                        SignificantDigits = 2;
                        Multiplier = 100;
                        Tolerance = new Tolerance(2);
                        return;
                    }
                case BandColor.Orange:
                    {
                        SignificantDigits = 3;
                        Multiplier = 1000;
                        return;
                    }
                case BandColor.Yellow:
                    {
                        SignificantDigits = 4;
                        Multiplier = 10000;
                        return;
                    }
                case BandColor.Green:
                    {
                        SignificantDigits = 5;
                        Multiplier = 100000;
                        Tolerance = new Tolerance(0.5);
                        return;
                    }
                case BandColor.Blue:
                    {
                        SignificantDigits = 6;
                        Multiplier = 1000000;
                        return;
                    }
                case BandColor.Violet:
                    {
                        SignificantDigits = 7;
                        Multiplier = 10000000;
                        return;
                    }
                case BandColor.Grey:
                    {
                        SignificantDigits = 8;
                        return;
                    }
                case BandColor.Gray:
                    {
                        SignificantDigits = 8;
                        return;
                    }
                case BandColor.White:
                    {
                        SignificantDigits = 9;
                        return;
                    }
                case BandColor.Gold:
                    {
                        Tolerance = new Tolerance(5);
                        return;
                    }
                case BandColor.Silver:
                    {
                        Tolerance = new Tolerance(10);
                        return;
                    }
                case BandColor.None:
                    {
                        SignificantDigits = 0;
                        Multiplier = 0;
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }
    }

    public enum BandColor
    {
        Black,
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Grey,
        Gray,
        White,
        Gold,
        Silver,
        None
    }

    public class Tolerance
    {
        double tolerance;

        public Tolerance(double pTolerance)
        {
            tolerance = pTolerance;
        }

        public string getTolerance()
        {
            return tolerance == 0 ? "" : "±" + tolerance + "%";
        }
    }

    public class ResistorBandColorException : Exception
    {
        public ResistorBandColorException() : base("Wrong band color") { }
        public ResistorBandColorException(string bandColor) : base("Band color: " + bandColor + " is not an acceptable color") { }
        public ResistorBandColorException(string bandColor, Exception inner) : base("Band color: " + bandColor + " is not an acceptable color", inner) { }
    }
}