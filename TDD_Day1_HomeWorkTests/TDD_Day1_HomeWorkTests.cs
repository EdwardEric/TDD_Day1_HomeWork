using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Day1_HomeWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;

namespace TDD_Day1_HomeWork.Tests
{
    public class Product
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Revenue { get; set; }
        public int SellPrice { get; set; }

    }
        [TestClass()]
    public class TDD_Day1_HomeWorkTests
    {
        private static List<Product> products = new List<Product>
            {
                new Product { Id=1, Cost=1,Revenue=11,SellPrice=21},
                new Product { Id=2, Cost=2,Revenue=12,SellPrice=22},
                new Product { Id=3, Cost=3,Revenue=13,SellPrice=23},
                new Product { Id=4, Cost=4,Revenue=14,SellPrice=24},
                new Product { Id=5, Cost=5,Revenue=15,SellPrice=25},
                new Product { Id=6, Cost=6,Revenue=16,SellPrice=26},
                new Product { Id=7, Cost=7,Revenue=17,SellPrice=27},
                new Product { Id=8, Cost=8,Revenue=18,SellPrice=28},
                new Product { Id=9, Cost=9,Revenue=19,SellPrice=29},
                new Product { Id=10, Cost=10,Revenue=20,SellPrice=30},
                new Product { Id=11, Cost=11,Revenue=21,SellPrice=31}
            };
        [TestMethod()]
        public void Cost_Sum_Group_By_3()
        {
            //arrange
            var target = new TDD_Day1_HomeWork();
            target.InitialData(products);
            var expected = new List<int> { 6, 15, 24, 21 };

            //act
            var actual = target.GetProductGroup<Product>(3, x => x.Cost);

            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
        [TestMethod]
        public void Revenue_Sum_Group_By_4()
        {
            //arrange
            var target = new TDD_Day1_HomeWork();
            target.InitialData(products);
            var expected = new List<int> { 50, 66, 60 };

            //act
            var actual = target.GetProductGroup<Product>(4, x => x.Revenue);
            
            //Assert
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}