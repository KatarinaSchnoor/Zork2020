using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork2020
{
    public class World
    {
        //storing the available areas
        List<Area> allAreas = new List<Area>();
        //starting area, ending area, and current area the player are in
        public Area startingArea;
        public Area endingArea;
        public Area currentArea;
        public Area newArea;

        public World()
        {
            Area a1 = new Area("The Teapot" , "this is were your amazing story starts, and your are sourrounded by tea");
            Area a2 = new Area("Silver Moon" , "it's pretty damn huge, and hard to see whats in front of you");
            Area a3 = new Area("The Mushroom Forest" , "everything here is mushroom, mushrooms and more mushrooms!");
            Area a4 = new Area("Golden Cliff" , "here you can get free gold, or is it?");
            Area a5 = new Area("Falling Stars","you are doomed at this place, and you have nowhere to go");


            //connecting the different areas = graph
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

        //input: the direction in which we want to move (we are in currentArea)
        //output: successful or unsucessful move?
        
        //checking if it is possible to move
        public bool Go(Directions direction )
        {
            //accessing the dictionary in Areas, to see if the directions is stored and if it is possible to go that way
            if ( currentArea.connectedArea.ContainsKey(direction) ) /* 1 */
            {
                //change currentArea - give me the connectedArea attached to the direction
                currentArea = currentArea.connectedArea[direction];
                
                return true;
            }
            else
            {
               return false;
            }
            
            
            
        }

        //put in all the areas in the dictionary in areas
    }
}
