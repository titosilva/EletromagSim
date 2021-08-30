using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Types
{
    public abstract class Versor
    {
        public virtual Scalar DotMultiply(Versor versor)
        {
            var thisCartesianForm = DotMultiply(CanonicalVersors.X);
            thisCartesianForm = thisCartesianForm == 0 ? DotMultiply(CanonicalVersors.Y) : thisCartesianForm;
            thisCartesianForm = thisCartesianForm == 0 ? DotMultiply(CanonicalVersors.Z) : thisCartesianForm;

            if (thisCartesianForm == 0) { return 0; }

            var versorCartesianForm = versor.DotMultiply(CanonicalVersors.X);
            versorCartesianForm = versorCartesianForm == 0 ? versor.DotMultiply(CanonicalVersors.Y) : versorCartesianForm;
            versorCartesianForm = versorCartesianForm == 0 ? versor.DotMultiply(CanonicalVersors.Z) : versorCartesianForm;

            return thisCartesianForm * versorCartesianForm;
        }

        public abstract Scalar DotMultiply(XVersor versor);
        public abstract Scalar DotMultiply(YVersor versor);
        public abstract Scalar DotMultiply(ZVersor versor);

        #region Comparisons
        public static bool operator ==(Versor versor1, Versor versor2)
        {
            return versor1.DotMultiply(versor2) == 1;
        }

        public static bool operator !=(Versor versor1, Versor versor2)
        {
            return !(versor1 == versor2);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
