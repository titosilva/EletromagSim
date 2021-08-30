using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Types
{
    public struct VectorComponent
    {
        public Versor Versor { get; set; }
        public Scalar Value { get; set; }
    }

    public class Vector
    {
        public Vector(params Scalar[] components)
        {
            var count = 0;
            Components = new List<VectorComponent>();
            foreach (var c in components)
            {
                Components.Add(new VectorComponent
                {
                    Value = c,
                    Versor = count switch
                    {
                        0 => CanonicalVersors.X,
                        1 => CanonicalVersors.Y,
                        2 => CanonicalVersors.Z,
                        _ => CanonicalVersors.X,
                    }
                });

                count++;
                if (count == 3)
                {
                    break;
                }
            }
        }

        public List<VectorComponent> Components { get; set; }

        public VectorComponent this[int idx]
        {
            get => Components[idx];
            set => Components[idx] = value;
        }

        #region Operators and functions
        public static Vector operator +(Vector v1, Vector v2)
        {
            var vector = new Vector();
            for (int i = 0; i < 3; i++)
            {
                vector.Components.Add(new VectorComponent
                {
                    Value = v1.Components[i].Value + v2.Components[i].Value,
                    Versor = v1.Components[i].Versor,
                });
            }

            return vector;
        }

        public static Vector operator *(Vector v, Scalar s)
        {
            var vector = new Vector();
            for (int i = 0; i < 3; i++)
            {
                vector.Components.Add(new VectorComponent
                {
                    Value = v.Components[i].Value * s,
                    Versor = v.Components[i].Versor,
                });
            }

            return vector;
        }

        public static Scalar Abs(Vector v)
            => Scalar.Pow(v.Components[0].Value, 2)
                + Scalar.Pow(v.Components[1].Value, 2)
                + Scalar.Pow(v.Components[2].Value, 2);
        #endregion
    }
}
