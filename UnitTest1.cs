using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using ConsoleApp5;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Thread1 mutex1 = new Thread1("Thread1", 3);
            Thread.Sleep(1);
            Thread2 mutex2 = new Thread2("Thread2", 2);
            mutex1.Thrd.Join();
            mutex2.Thrd.Join();
            int expected = 1;
            int result = MutexClass.Count;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Thread1 mutex1 = new Thread1("Thread1", 5);
            Thread.Sleep(1);
            Thread2 mutex2 = new Thread2("Thread2", 5);
            mutex1.Thrd.Join();
            mutex2.Thrd.Join();
            int expected = 1;
            int result = MutexClass.Count;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Thread1 mutex1 = new Thread1("Thread1", 1);
            Thread.Sleep(1);
            Thread2 mutex2 = new Thread2("Thread2", 0);
            mutex1.Thrd.Join();
            mutex2.Thrd.Join();
            int expected = 1;
            int result = MutexClass.Count;
            Assert.AreEqual(expected, result);
        }
    }


}
