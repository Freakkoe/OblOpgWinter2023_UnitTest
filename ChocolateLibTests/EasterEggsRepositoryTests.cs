using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChocolateLib;
using CharlottesChocolate;
using System;
using System.Collections.Generic;

namespace ChocolateLib.Tests
{
    [TestClass]
    public class EasterEggsRepositoryTests
    {
        private EasterEggsRepository repository;

        private EasterEgg easterEgg;
        private EasterEgg easterEggChocolateTypeNull;
        private EasterEgg easterEggPriceNegative;
        private EasterEgg easterEggInStockNegative;

        [TestInitialize]
        public void TestInitialize()
        {
            repository = new EasterEggsRepository();

            easterEgg = new EasterEgg
            {
                ProductNo = 1,
                ChocolateType = "Mørk",
                Price = 28,
                InStock = 5012
            };

            easterEggChocolateTypeNull = new EasterEgg
            {
                ProductNo = 2,
                ChocolateType = null,
                Price = 32,
                InStock = 3420
            };

            easterEggPriceNegative = new EasterEgg
            {
                ProductNo = 3,
                ChocolateType = "Lys",
                Price = -1,
                InStock = 1180
            };

            easterEggInStockNegative = new EasterEgg
            {
                ProductNo = 4,
                ChocolateType = "Hvid",
                Price = 34,
                InStock = -1
            };
        }

        [TestMethod]
        public void ToStringTest()
        {
            string str = easterEgg.ToString();
            Assert.AreEqual("1 Mørk 28 5012", str);
        }

        [TestMethod]
        public void ValidateChocolateTypeTest()
        {
            Assert.ThrowsException<ArgumentException>(() => easterEggChocolateTypeNull.ValidateChocolateType());
        }

        [TestMethod]
        public void ValidatePriceTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => easterEggPriceNegative.ValidatePrice());
        }

        [TestMethod]
        public void ValidateInStockTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => easterEggInStockNegative.ValidateInStock());
        }

        [TestMethod]
        public void ValidateTest()
        {
            Assert.ThrowsException<ArgumentException>(() => easterEggChocolateTypeNull.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => easterEggPriceNegative.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => easterEggInStockNegative.Validate());
        }


    }
}
