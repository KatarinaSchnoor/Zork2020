using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork2020
{
    class World
    {
        //storing the available areas
        List<Area> allAreas = new List<Area>();
        //starting area, ending area, and current area the player are in
        Area startingArea;
        Area endingArea;
        Area currentArea;

        public World()
        {
            Area a1 = new Area("The Teapot" , "this is were your amazing story starts, and your are sourrounded by tea");
            Area a2 = new Area("Silver Moon" , "it's pretty damn huge, and hard to see whats in front of you");
            Area a3 = new Area("The Mushroom Forest" , "everything here is mushrrom");
            Area a4 = new Area("Golden Cliff" , "here you can get free gold, or is it?");
            Area a5 = new Area("Falling Stars","you are doomed at this place, and you have nowhere to go");


            //connecting the different areas
            a4.Connect(a5 , Directions.South);
            a1.ConnectBidirectional(a3 , Directions.West);
            a3.ConnectBidirectional(a4 , Directions.South);
            a4.ConnectBidirectional(a2 , Directions.East);
            a2.Connect(a1 , Directions.North);
            a3.Connect(a2 , Directions.West);

            //setting the starting area, current area and ending area
            startingArea = a1;
            currentArea = a1;
            endingArea = a5;

        }

        //put in all the areas in the dictionary in areas
    }
}
