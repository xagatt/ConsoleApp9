using ConsoleApp9;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace lab_9
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            DialClock clock = new DialClock(10, 30);
            //Act
            DialClock d = new DialClock(10,30);
            //Assert
            Assert.AreEqual(clock, d);            
        }
        [TestMethod]
        public void TestMethodNullTime()
        {
            DialClock expected = new DialClock(0, 0);

            DialClock m = new DialClock();

            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodMinutesMinus()
        {
            DialClock expected = new DialClock(5, 0);
            DialClock m = new DialClock(5, 1);
            m--;
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodMinutesMinus2()
        {
            DialClock expected = new DialClock(4, 59);
            DialClock m = new DialClock(5, 0);
            m--;
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodCalculateAngleStatic()
        {
            DialClock expected = new DialClock(0, 0);
            double m = 0;
            double angle;
            angle = DialClock.CalculateAngleStatic(expected.Hours, expected.Minutes);
            Assert.AreEqual(m, angle);
        }

        [TestMethod]
        public void TestMethodCalculateAngle()
        {
            DialClock expected = new DialClock(0, 0);
            double m = 0;
            double angle;
            angle = expected.CalculateAngle();
            Assert.AreEqual(m, angle);
        }

        [TestMethod]
        public void TestMethodGetObjectCount()
        {
            int count = 0;
            int m = 0;
            DialClock.GetObjectCount();
            Assert.AreEqual(m, count);
        }

        [TestMethod]
        public void TestMethodIsTwoHalf()
        {
            bool expected = true;
            bool m = DialClock.IsTwoHalf(0, 0);
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodAddMin1()
        {
            DialClock expected = new DialClock(5, 50);
            DialClock m = new DialClock(5, 49);
            m++;
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodAddMin2()
        {
            DialClock expected = new DialClock(5, 0);
            DialClock m = new DialClock(4, 59);
            m++;
            Assert.AreEqual(expected, m);
        }

        [TestMethod]
        public void TestMethodPlusOperator()
        {
            DialClock dc = new DialClock(10, 30);
            int minutes = 15;
            int result = dc + minutes;
            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void TestMethodMinusOperator()
        {
            DialClock dc = new DialClock(10, 30);
            int minutes = 5;
            int result = dc - minutes;
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void TestMethodPlusOperator1()
        {
            DialClock dc = new DialClock(10, 30);
            int minutes = 15;
            int result = minutes + dc;
            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void TestMethodMinusOperator1()
        {
            DialClock dc = new DialClock(10, 30);
            int minutes = 5;
            int result = minutes - dc;
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void TestMethodArrayLength()
        {
            int expected = 5;
            int Length = 0;
            DialClockArray arr = new DialClockArray(5);
            Length = arr.Length;
            Assert.AreEqual(expected, Length);
        }

        [TestMethod]
        public void TestMethodNullArray()
        {
            int expected = 0;
            int actual;
            DialClock arr = new DialClock();
            actual = arr.length;
            Assert.AreEqual(expected, actual);
        }
                
        [TestMethod]
        public void TestMethodCopyConstructor()
        {

            DialClockArray originalArray = new DialClockArray(3);
            originalArray[0] = new DialClock(1, 30);

            DialClockArray copiedArray = new DialClockArray(originalArray);

            Assert.AreEqual(originalArray.Length, copiedArray.Length);
            for (int i = 0; i < originalArray.Length; i++)
            {
                Assert.AreEqual(originalArray[i].Hours, copiedArray[i].Hours);
                Assert.AreEqual(originalArray[i].Minutes, copiedArray[i].Minutes);
            }
        }

        [TestMethod]
        public void TestMethodPrintInfo()
        {
            DialClock clock = new DialClock(10, 30);
            string expectedOutput = "Часы: 10, Минуты: 30";
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);
            clock.PrintInfo();
            string actualOutput = sw.ToString().Trim();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestMethodCounter()
        {
            DialClock clock = new DialClock(9, 15);
            int count = clock.Counter();
            Assert.AreEqual(610, count);
        }

        [TestMethod]
        public void TestMethodToString()
        {
            DialClock clock = new DialClock(9, 5);
            string result = clock.ToString();
            Assert.AreEqual("09:05", result);
        }

        [TestMethod]
        public void TestMethodIndexer()
        {
            DialClockArray array = new DialClockArray(3);
            DialClock expectedClock = new DialClock(10, 15);
            array[1] = expectedClock;
            DialClock resultClock = array[1];
            Assert.AreEqual(expectedClock, resultClock);
        }

        // Новый метод тестирования через перенаправление потока
        [TestMethod]
        public void TestMethodCorrectOutput()
        {
            DialClockArray arr = new DialClockArray(1);
            arr[0] = new DialClock(10, 30);
            StringWriter sw = new StringWriter(); // захват вывода
            Console.SetOut(sw); // перенаправление вывода сюда, таким образом все что выводится записывается 
            string expected = "10:30\r\n";

            arr.Show();

            Assert.AreEqual(expected, sw.ToString());
        }
    }
}