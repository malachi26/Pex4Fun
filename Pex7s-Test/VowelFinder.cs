using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pex7s;


namespace Pex7s_Test
{
    /// <summary>
    /// Summary description for VowelFinder
    /// </summary>
    [TestClass]
    public class VowelFinder
    {
        [TestMethod]
        public void TestMethod1()
        {
            string testString = "blueberry";
            Assert.IsTrue(RandomCodeReviewMethods.ContainsVowels(testString));   
        }
        [TestMethod]
        public void TestMethod2()
        {
            string testString = "BLUEBERRY";
            Assert.IsTrue(RandomCodeReviewMethods.ContainsVowels(testString));
        }
    }
}
