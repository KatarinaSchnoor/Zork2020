using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zork2020;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork2020.Tests
{
    [TestClass()]
    public class AreaTests
    {
        [TestMethod()]
        public void ConnectTest()
        {
            Area area1 = new Area("Test" , "This is the description");
            Area area2 = new Area("Another test" , "This is the description");

            //connect area1 to area2

            area1.Connect(area2 , Directions.North);

            //checking if the areas are connected as expected
            Assert.AreSame(area1.connectedArea[Directions.North], area2);
        }

        [TestMethod()]
        public void ConnectBidirectionalTest()
        {
            Area area1 = new Area("Test" , "This is the description");
            Area area2 = new Area("Another test" , "This is the description");

            //connect area1 to area2, and other way around

            area1.ConnectBidirectional(area2 , Directions.North);

            //checking if the areas are connected as expected
            Assert.AreSame(area1.connectedArea[Directions.North] , area2);
            Assert.AreSame(area2.connectedArea[Directions.South] , area1);
        }
    }
}