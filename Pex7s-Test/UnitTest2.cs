using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pex7s_Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestAddContains(int x, int y)
        {
            var s = new Pex7s.MyHashSet();
            s.Add(x);
            s.Add(y);
            Assert.IsTrue(s.Contains(x));
            Assert.IsTrue(s.Contains(y));
        }
    }
}
