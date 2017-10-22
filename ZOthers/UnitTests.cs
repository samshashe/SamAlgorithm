using System;
using NUnit.Framework;
using System.Collections;
namespace UnitTestApplication.UnitTests
{
    [TestFixture()]
    public class CharacterCounter_UnitTest
    {
        private UnitTestApplication.CharacterCounter counter = new CharacterCounter();

        [SetUp()]
        public void Init()
        {
            // some code here, that need to be run at the start of every test case.
        }
        [TearDown()]
        public void Clean()
        {
            // code that will be called after each Test case
        }
        [Test]
        public void Test()
        {
            Hashtable ht = counter.CountOfEachCharacter("AABACB");
            Assert.AreEqual(3, (int)ht["A"], "A's count is Wrong!");
            Assert.AreEqual(2, (int)ht["B"], "B's count is Wrong!");
            Assert.AreEqual(1, (int)ht["C"], "C's count is Wrong!");

            //Similarly I will test with different input values 
            //"null","","a","abc","aa","aab","abb","a23b45ccD","5" etc
        }

    }

}