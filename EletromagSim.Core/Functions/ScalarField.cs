using EletromagSim.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Functions
{
    public class ScalarField
    {
        public ScalarField(Func<Vector, Scalar> definition)
        {
            Definition = definition;
        }

        public Func<Vector, Scalar> Definition { get; set; }

        public Scalar At(Vector vector) => Definition(vector);
    }
}
