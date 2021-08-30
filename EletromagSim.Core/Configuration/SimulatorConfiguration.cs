using EletromagSim.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Configuration
{
    public static class SimulatorConfiguration
    {
        public static Scalar Infinite { get; set; } = new Scalar(1, 100);
        public static Scalar VacuumPermittivity { get; set; } = new Scalar(8.8541878128, -12);
    }
}
