using System;
using System.Linq;
using System.Numerics;
namespace EletromagSim.Core.Types
{
    public class Scalar
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

        public Scalar(Scalar s)
        {
            DecimalMantissa = s.DecimalMantissa;
            DecimalExponent = s.DecimalExponent;
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

        #region Comparisons
        public static bool operator ==(Scalar s1, Scalar s2)
        {
            return s1.DecimalMantissa == s2.DecimalMantissa && s1.DecimalExponent == s2.DecimalExponent;
        }

        public static bool operator !=(Scalar s1, Scalar s2) => !(s1 == s2);

        public override bool Equals(object obj)
        {
            var objType = obj.GetType();
            if (!objType.Equals(this.GetType()))
            {
                return false;
            }
            return (Scalar)obj == this;
        }

        public override int GetHashCode() => base.GetHashCode();
        #endregion

        #region Operators and functions
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
        #endregion

        #region String Manipulations
        public override string ToString()
        {
            var mantissaString = DecimalMantissa.ToString();
            var exponent = DecimalExponent;
            while (exponent != 0)
            {
                if (exponent > 0)
                {
                    mantissaString += "0";
                    exponent--;
                }
                else
                {
                    mantissaString.Insert(mantissaString.Length - 1 + exponent, ".");
                    break;
                }
            }
            return mantissaString;
        }

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
