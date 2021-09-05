using EletromagSim.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Types
{
    public class VectorField
    {
        public VectorField(Func<Vector, Vector> definition)
        {
            Definition = definition;
        }

        public Func<Vector, Vector> Definition { get; set; }

        public Vector At(Vector vector) => Definition(vector);
    }
}
