using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = listOM();
            var y = listOL();
            Assert.AreNotEqual(x.Count, y.Count);
        }


        //Create OM Array 
        public List<double> listOM()
        {

            List<double> OM = new List<double>();
            for (double i = 0.0; i < 0.7; )
            {
                i += 0.005;
              var e= Math.Round(i, 4);
                OM.Add(e);
            }
            return OM;
        }
        //Create OL Array 
        public List<double> listOL()
        {
            List<double> OL = new List<double>();
            for (double i = 0.0; i < 1; )
            {
                i += 0.005;
             var e=   Math.Round(i, 4);
                OL.Add(e);
            }
            return OL;
        }
    }
}
