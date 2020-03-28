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
    public class WorldTests
    {
        //two cases - one that brings into the true, and one into the false
        /*1-true : currentArea has been connected to that direction
         * 1-false : currentArea has not been connected in that direction
         */

        //Data test method - because we want to use it multiple times
        [DataTestMethod()]
        [DataRow(Directions.West, true)]
        [DataRow(Directions.East, false)]

        //only test the direction, because we can make areas that are connected or not 
        //- choosing directions that is gonne return true or false
        
        public void GoTest(Directions direction, bool succes)
        {
            World world = new World();

            //Making area, and checking if there are a new area in the direction
            Area nextArea = null;
            Area prevArea = world.currentArea;
            if ( world.currentArea.connectedArea.ContainsKey(direction) )
            {
                nextArea = world.currentArea.connectedArea[direction];
            }

            bool succesfulMove = world.Go(direction);

            //checking if what we expect succes to turn out (true/false) is the same as the output on succesfulMove
            Assert.AreEqual(succes,succesfulMove);

            //Checking if Go is doing what it is supposed to do - checking if the nextArea is the currentArea, or if the currentArea is the same, if not able to move
            if ( succesfulMove )
            {
                Assert.AreSame(world.currentArea , nextArea);
            }
            else
            {
                Assert.AreSame(world.currentArea , prevArea);
            }

        }
    }
}