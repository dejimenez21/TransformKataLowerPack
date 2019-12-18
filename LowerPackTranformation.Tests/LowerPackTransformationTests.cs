using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace LowerPackTranformation.Tests
{
    [TestFixture]
    public class LowerPackTransformationTests
    {
        /*
         "h h" -> "hh"
         " h " -> " h "
         "H H" -> "hh"
         ""
         */
        [Test]
        public void WhenStringNullThrowArgumentNullException() {
            //Arrange
            TransformKata transformation = new TransformKata();
            string input = null;
            //Act
            //Assert
            Assert.That(()=> transformation.LowerPack(input),Throws.ArgumentNullException);
        }

        [Test]
        public void WhenStringEmptyReturnStringEmpty()
        {
            TransformKata transformation = new TransformKata();
            string input = "";
            Assert.That(transformation.LowerPack(input), Is.Empty);
        }

        [Test]
        public void WhenStringItsLowerHReturnsLowerH()
        {
            TransformKata transformation = new TransformKata();
            string input = "h";
            Assert.That(transformation.LowerPack(input), Is.EqualTo("h"));
        }
        [Test]
        public void WhenStringItsUpperHReturnLowerH()
        {
            TransformKata transformation = new TransformKata();
            string input = "H";
            Assert.That(transformation.LowerPack(input), Is.EqualTo("h"));
        }
        [Test]
        public void WhenStringItsSpaceReturnSpace()
        {
            TransformKata transformation = new TransformKata();
            string input = " ";
            Assert.That(transformation.LowerPack(input), Is.EqualTo(" "));
        }
        [Test]
        public void WhenStringItsSpaceAndHReturnSpaceAndH()
        {
            TransformKata transformation = new TransformKata();
            string input = " h";
            Assert.That(transformation.LowerPack(input), Is.EqualTo(" h"));
        }
        /*
  "H H" -> "hh"
  ""
  */
        [Test]
        public void WhenStringItsLowerHSpaceLowerH()
        {
            TransformKata transformation = new TransformKata();
            string input = "h h";
            Assert.That(transformation.LowerPack(input), Is.EqualTo("hh"));
        }
        [Test]
        public void WhenStringItsSpaceLowerHSpace()
        {
            TransformKata transformation = new TransformKata();
            string input = " h ";
            Assert.That(transformation.LowerPack(input), Is.EqualTo(" h "));
        }
        [Test]
        public void WhenStringItsUpperHSpaceUpperH()
        {
            TransformKata transformation = new TransformKata();
            string input = "H H";
            Assert.That(transformation.LowerPack(input), Is.EqualTo("hh"));
        }



        //Prueba para confirmar complejidad
        [Test]
        public void WhenRunningMethod22TimesDoublingStringLength()
        {
            double averageIntervalTime=AverageIntervals();

            Assert.That(averageIntervalTime, Is.InRange(1.825, 2.175));
        }

        double AverageIntervals()
        {
            List<double> MeasuredTimes = MeasureTimes();
            double intervalsSum=0;

            for (int i = 1; i < MeasuredTimes.Count; i++)
            {
                intervalsSum += (MeasuredTimes[i] / MeasuredTimes[i - 1]);
            }

            return intervalsSum / (double)MeasuredTimes.Count;
        }

        List<double> MeasureTimes()
        {
            TransformKata transformation = new TransformKata();
            List<double> MeasuredTimes = new List<double>();
            Stopwatch sw = new Stopwatch();

            string lastInput = "HH hh OO oo LL ll AA aaHH hh OO oo LL ll AA aa";

            for (int i = 0; i < 22; i++)
            {
                lastInput += lastInput;
                sw = Stopwatch.StartNew();
                transformation.LowerPack(lastInput);
                sw.Stop();
                MeasuredTimes.Add(sw.Elapsed.TotalMilliseconds);
            }

            return MeasuredTimes;
        }
         
    }

}
