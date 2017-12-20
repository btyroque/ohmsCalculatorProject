using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OhmCalculatorWeb.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCorrectBandColorResistors()
        {
            // Tests that we expect to return true.
            //Array format: bandAColor, bandBColor, bandCColor, bandDColor, correctResult
            string[][] bands = new string[4][];
            bands[0] = new string[] { "Red", "Red", "Orange", "Gold", "22000" };
            bands[1] = new string[] { "Yellow", "Violet", "Brown", "Gold", "470" };
            bands[2] = new string[] { "Blue", "Gray", "Black", "Gold", "68" };
            bands[3] = new string[] { "Black", "Orange", "Brown", "Red", "30" };

            foreach (var band in bands)
            {
                int ohms = new OhmCalculatorClass().CalculateOhmValue(band[0], band[1], band[2], band[3]);
                bool result = ohms.ToString().Equals(band[4]);
                string colorBand = band[0] + ", " + band[1] + ", " + band[2] + ", " + band[3];
                Assert.IsTrue(result,
                       String.Format("Expected for ({0}): {1}; Actual: {2}",
                                     colorBand, band[4], ohms));
            }
        }

        [TestMethod]
        public void TestWrongBandColorResistors()
        {
            // Tests that we expect to return false.
            //Array format: bandAColor, bandBColor, bandCColor, bandDColor, correctResult
            string[][] bands = new string[3][];
            bands[0] = new string[] { "Red", "Red", "Orange", "Gold", "220" };
            bands[1] = new string[] { "Yellow", "Violet", "Brown", "Gold", "47" };
            bands[2] = new string[] { "Blue", "Gray", "Black", "Gold", "680" };

            foreach (var band in bands)
            {
                int ohms = new OhmCalculatorClass().CalculateOhmValue(band[0], band[1], band[2], band[3]);
                bool result = ohms.ToString().Equals(band[4]);
                string colorBand = band[0] + ", " + band[1] + ", " + band[2] + ", " + band[3];
                Assert.IsFalse(result,
                       String.Format("Expected for ({0}): {1}; Actual: {2}",
                                     colorBand, band[4], ohms));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ResistorBandColorException))]
        public void TestNonExistenceColor()
        {
            // Tests that we expect to throw ResistorBandColorException.
            int ohms = new OhmCalculatorClass().CalculateOhmValue("Red", "Red", "Orange", "Purple");
        }

        [TestMethod]
        [ExpectedException(typeof(ResistorBandColorException))]
        public void TestFirstBandWithoutSignificantDigit()
        {
            // Tests that we expect to throw ResistorBandColorException.
            int ohms = new OhmCalculatorClass().CalculateOhmValue("Gold", "Red", "Orange", "Gold");
        }

        [TestMethod]
        [ExpectedException(typeof(ResistorBandColorException))]
        public void TestColorWithoutMultiplier()
        {
            // Tests that we expect to throw ResistorBandColorException.
            int ohms = new OhmCalculatorClass().CalculateOhmValue("Red", "Red", "Gray", "Gold");
        }
    }
}
