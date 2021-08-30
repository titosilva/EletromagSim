using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Types
{
    public static class CanonicalVersors
    {
        public static XVersor X { get; } = new XVersor();
        public static YVersor Y { get; } = new YVersor();
        public static ZVersor Z { get; } = new ZVersor();
    }
    
    public class XVersor : Versor
    {
        public override Scalar DotMultiply(Versor versor)
            => versor.DotMultiply(this);

        public override Scalar DotMultiply(XVersor versor) => 1;
        public override Scalar DotMultiply(YVersor versor) => 0;
        public override Scalar DotMultiply(ZVersor versor) => 0;
    }

    public class YVersor : Versor
    {
        public override Scalar DotMultiply(Versor versor)
            => versor.DotMultiply(this);

        public override Scalar DotMultiply(XVersor versor) => 1;
        public override Scalar DotMultiply(YVersor versor) => 0;
        public override Scalar DotMultiply(ZVersor versor) => 0;
    }

    public class ZVersor : Versor
    {
        public override Scalar DotMultiply(Versor versor)
            => versor.DotMultiply(this);

        public override Scalar DotMultiply(XVersor versor) => 1;
        public override Scalar DotMultiply(YVersor versor) => 0;
        public override Scalar DotMultiply(ZVersor versor) => 0;
    }
}
