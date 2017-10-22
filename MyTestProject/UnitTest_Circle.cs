using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication2;

namespace MyTestProject
{
  
    [TestClass]
    public class UnitTest_Circle
    {
        CircleToBeTested ActualCircle;
        double ActualRadius;
        Point ActualPoint;

        
        [TestMethod]
        public void Test_Circumference()
        {
            ActualCircle = new CircleToBeTested(ActualRadius);
            double c = ActualCircle.getCircumference();
            double circum = Math.Round(Math.PI * 2 * ActualRadius, 2);
            Assert.AreEqual(circum, c, "Circumferences Differ");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            ActualRadius = 1;
            Point point = new Point(3, 4);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            ActualCircle = null;
            ActualRadius = 0;
            ActualPoint = new Point();

        }
    }
}
