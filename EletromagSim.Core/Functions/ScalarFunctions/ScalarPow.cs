using EletromagSim.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Functions.ScalarFunctions
{
    public static partial class ScalarMath
    {
        public static Scalar Pow(Scalar s1, int exp)
        {
            var count = 1;
            var result = new Scalar(s1);
            while (count < exp)
            {
                result *= s1;
                count++;
            }

            return result;
        }
    }
}
