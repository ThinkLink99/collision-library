using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarKrash.Collision.Graphics;
using System;

namespace CarKrash.CollisionTests
{
    [TestClass]
    public class ColorTest
    {
        [TestMethod]
        public void TestWhiteColor()
        {
            // assemble
            Color white = new Color(255, 255, 255);

            // act
            bool isSame = Color.White.Equals(white);

            // asset
            Assert.IsTrue(isSame);
        }

        [TestMethod]
        public void TestGoodColor ()
        {
            // assemble
            Color white = new Color(255, 255, 255);

            // act

            // asset
            Assert.IsNotNull(white);
        }

        [TestMethod]
        public void TestBadColor ()
        {
            try
            {
                // assemble
                Color white = new Color(255, 255, 300);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
        }
    }
}
