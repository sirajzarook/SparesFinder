using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparesFinder.Web.DAL;

namespace SparesFinder.Web.Tests.DAL
{
    [TestClass]
    public class DALTest
    {
        [TestMethod]
        public void Test_getSalesByYear()
        {
            //Arrange
            DataManager dm = new DataManager();

            //Action
            var result=  dm.getSalesByYear();

            //Assert
            Assert.IsTrue(result.Count == 5);

        }

        [TestMethod]
        public void Test_getSalesSummaryOfYear()
        {
            //Arrange
            DataManager dm = new DataManager();
            var salesYear = 2002;
            //Action
            var result = dm.getSalesSummaryOfYear(salesYear);

            //Assert
            Assert.IsTrue(result.Count == 1770);

        }
    }
}
