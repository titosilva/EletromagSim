using System;
using System.Linq;
using System.Numerics;
namespace EletromagSim.Core.Types
{
    public record Scalar
    {
        #region Constructors
        public Scalar() { }
        public Scalar(string value)
        {
            processAndSetValueFromString(value);
        }

        public Scalar(int value, int auxiliaryExponent)
        {
            DecimalMantissa = value;
            DecimalExponent = auxiliaryExponent;
        }

        public Scalar(double value, int auxiliaryExponent)
        {
            processAndSetValueFromString(value.ToString());
            DecimalExponent += auxiliaryExponent;
        }

        public Scalar(BigInteger mantissa, int exponent)
        {
            DecimalMantissa = mantissa;
            DecimalExponent = exponent;
        }

        public Scalar(double value)
        {
            processAndSetValueFromString(value.ToString());
        }
        #endregion

        private BigInteger decimalMantissa { get; set; }

        public BigInteger DecimalMantissa
        {
            get => decimalMantissa;
            set { decimalMantissa = value; removeLeadingZeroes(); }
        }
        public int DecimalExponent { get; set; }

        #region Conversions
        public static implicit operator Scalar(double d) => new Scalar(d);
        #endregion

        #region Operations and functions
        public static Scalar operator *(Scalar s1, Scalar s2)
            => new Scalar
            {
                DecimalExponent = s1.DecimalExponent + s2.DecimalExponent,
                DecimalMantissa = s1.DecimalMantissa * s2.DecimalMantissa,
            };

        public static Scalar operator +(Scalar s1, Scalar s2)
        {
            var lowerExponent = s1.DecimalExponent > s2.DecimalExponent ? s2.DecimalExponent : s1.DecimalExponent;
            var greaterExponent = s1.DecimalExponent > s2.DecimalExponent ? s1.DecimalExponent : s2.DecimalExponent;
            var lowerExponentMantissa = s1.DecimalExponent > s2.DecimalExponent ? s2.DecimalMantissa : s1.DecimalMantissa;
            var greaterExponentMantissa = s1.DecimalExponent > s2.DecimalExponent ? s1.DecimalMantissa : s2.DecimalMantissa;

            while (greaterExponent != lowerExponent)
            {
                greaterExponentMantissa *= 10;
                greaterExponent--;
            }

            return new Scalar(lowerExponentMantissa + greaterExponentMantissa, lowerExponent);
        }

        public static Scalar Pow(Scalar s1, int exp)
        {
            var count = 1;
            var result = (Scalar) s1.MemberwiseClone();
            while(count < exp)
            {
                result *= s1;
                count++;
            }

            return result;
        }
        #endregion

        #region String Manipulations
        private void processAndSetValueFromString(string value)
        {
            var clean = value.Where(c => char.IsDigit(c) || c == '.' || c == ',');
            if (clean.Count(c => c == '.' || c == ',') > 1)
            {
                throw new ArgumentException($"The value {value} has more than one '.' or ',' and can't be consistently understood");
            }

            var splitted = clean.Contains('.') ? value.Split('.') : value.Split(',');
            DecimalExponent = splitted.Count() > 1 ? -1 * splitted.Last().Length : 0;
            DecimalMantissa = BigInteger.Parse(string.Join("", splitted));
        }
        #endregion

        private void removeLeadingZeroes()
        {
            while (DecimalMantissa % 10 == 0 && DecimalMantissa != 0)
            {
                DecimalMantissa /= 10;
                DecimalExponent += 1;
            }
        }
    }
}
