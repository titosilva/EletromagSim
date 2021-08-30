using EletromagSim.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EletromagSim.Core.Tests.Types
{
    [TestClass]
    public class ScalarTests
    {
        [TestMethod]
        public void StringConstructor_ShouldParseStringCorrectly()
        {
            var scalar = new Scalar("203.543");

            Assert.AreEqual(203543, scalar.DecimalMantissa);
            Assert.AreEqual(-3, scalar.DecimalExponent);

            scalar = new Scalar("90833221.00001");

            Assert.AreEqual(9083322100001, scalar.DecimalMantissa);
            Assert.AreEqual(-5, scalar.DecimalExponent);

            scalar = new Scalar("1");
            Assert.AreEqual(1, scalar.DecimalMantissa);
            Assert.AreEqual(0, scalar.DecimalExponent);
        }

        [TestMethod]
        public void DoubleConstructor_ShouldParseDoubleCorrectly()
        {
            var scalar = new Scalar(203.543);

            Assert.AreEqual(203543, scalar.DecimalMantissa);
            Assert.AreEqual(-3, scalar.DecimalExponent);

            scalar = new Scalar(90833221.00001);

            Assert.AreEqual(9083322100001, scalar.DecimalMantissa);
            Assert.AreEqual(-5, scalar.DecimalExponent);

            scalar = new Scalar(1);
            Assert.AreEqual(1, scalar.DecimalMantissa);
            Assert.AreEqual(0, scalar.DecimalExponent);
        }

        [TestMethod]
        public void Sum_ShouldSumProperly()
        {
            var s1 = new Scalar(1.1);
            var s2 = new Scalar(2.3);

            var s3 = s1 + s2;

            Assert.AreEqual(s3, 3.4);
        }

        [TestMethod]
        public void Multiply_ShouldMultiplyProperly()
        {
            var s1 = new Scalar(1.6);
            var s2 = new Scalar(61);

            var s3 = s1 * s2;

            Assert.AreEqual(s3, 97.6);
        }

        [TestMethod]
        public void Power_ShouldComputePowProperly()
        {
            var s1 = new Scalar(0.5);
            var s2 = Scalar.Pow(s1, 3);

            Assert.AreEqual(s2, 0.125);

            s1 = new Scalar(10);
            s2 = Scalar.Pow(s1, 1);

            Assert.AreEqual(s2, 10);
        }
    }
}
