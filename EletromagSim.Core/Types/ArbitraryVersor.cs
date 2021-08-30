using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Types
{
    public class ArbitraryVersor : Versor
    {
        public ArbitraryVersor(Scalar x, Scalar y, Scalar z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Scalar X { get; set; }
        public Scalar Y { get; set; }
        public Scalar Z { get; set; }

        public override Scalar DotMultiply(XVersor versor) => X;

        public override Scalar DotMultiply(YVersor versor) => Y;

        public override Scalar DotMultiply(ZVersor versor) => Z;
    }
}
