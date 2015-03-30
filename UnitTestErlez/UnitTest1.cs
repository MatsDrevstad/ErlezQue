using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErlezQue;

namespace UnitTestErlez
{
    [TestClass]
    public class UnitTest1
    {

        private Calculator calc;
            
        public UnitTest1 ()
	    {
            calc = new Calculator();
	    }

        [TestMethod]
        public void CanAdd()
        {
            Assert.AreEqual(calc.Add("3, 3,4"), 10);
        }

        [TestMethod]
        public void ReturnZero()
        {
            Assert.AreEqual(calc.Add(""), 0);
        }

        [TestMethod]
        public void HandleNewLine()
        {
            Assert.AreEqual(calc.Add("3, 3\n4"), 10);
        }

        [TestMethod]
        public void Definedelimiter()
        {
            Assert.AreEqual(calc.Add("//;\n1;2"), 3);
        }
    }
}
