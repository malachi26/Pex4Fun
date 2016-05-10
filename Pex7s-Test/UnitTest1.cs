using Pex7s;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pex7s.Tests
{
    [TestClass()]
    public class UnitTest1
    {

        [TestMethod()]
        public void FunctionFTest001()
        {
            var input = 1;
            var output = 7;
            Assert.AreEqual(output, Pex7s.Program.FunctionF(input));          
        }

        [TestMethod]
        public void FunctionFTest030()
        {
            var input = 30;
            var output = -1073741831;
            Assert.AreEqual(output, Pex7s.Program.FunctionF(input));
        }

        [TestMethod]
        public void FunctionNathanTest030()
        {
            var input = 30;
            var output = -1073741831;
            Assert.AreEqual(output, Pex7s.Program.FunctionNathan(input));
        }

        [TestMethod()]
        public void FunctionNathanTest001()
        {
            Func<int, int> function = Pex7s.Program.FunctionNathan;
            var input = 1;
            var output = 7;
            Assert.AreEqual(output, function(input));
        }

        [TestMethod()]
        public void FunctionKovachTest001()
        {
            Func<int, int> function = Pex7s.Program.FunctionKovach;
            var input = 1;
            var output = 7;
            Assert.AreEqual(output, function(input));
        }

        [TestMethod()]
        public void FunctionKovachTest030()
        {
            Func<int, int> function = Pex7s.Program.FunctionKovach;
            var input = 30;
            var output = -1073741831;
            Assert.AreEqual(output, function(input));
        }

        [TestMethod]
        public void AnagramTest001()
        {
            Func<string, string, bool> function = Pex7s.Program.AreStringsAnagrams;
            var input1 = "momdad";
            var input2 = "dadmom";
            Assert.IsTrue(function(input1, input2));
        }
        [TestMethod]
        public void AnagramTest002()
        {
            Func<string, string, bool> function = Pex7s.Program.AreStringsAnagrams;
            var input1 = "Joker";
            var input2 = "JReko";
            Assert.IsTrue(function(input1, input2));
        }
        [TestMethod]
        public void AnagramTest003()
        {
            Func<string, string, bool> function = Pex7s.Program.AreStringsAnagrams;
            var input1 = "hi";
            var input2 = "hiaaaaa";
            Assert.IsFalse(function(input1, input2));
        }

        [TestMethod]
        public void AnagramLinqTest001()
        {
            Func<string, string, bool> function = Pex7s.Program.LinqAreStringsAnagrams;
            var input1 = "momdad";
            var input2 = "dadmom";
            Assert.IsTrue(function(input1, input2));
        }

        [TestMethod]
        public void AnagramLinqTest002()
        {
            Func<string, string, bool> function = Pex7s.Program.LinqAreStringsAnagrams;
            var input1 = "Joker";
            var input2 = "JReko";
            Assert.IsTrue(function(input1, input2));
        }

        [TestMethod]
        public void AnagramLinqTest003()
        {
            Func<string, string, bool> function = Pex7s.Program.LinqAreStringsAnagrams;
            var input1 = "hia";
            var input2 = "hiaaaaa";
            Assert.IsFalse(function(input1, input2));
        }
        [TestMethod]
        public void AnagramLinqTest004()
        {
            Func<string, string, bool> function = Pex7s.Program.LinqAreStringsAnagrams;
            var input1 = "hi";
            var input2 = "hiaaaaa";
            Assert.IsFalse(function(input1, input2));
        }

    }
}

