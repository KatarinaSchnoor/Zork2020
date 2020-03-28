using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork2020
{
    class Area
    {
        
        //storing the name and description for the area
        public string name;
        public string description;

        //storing the areas close to the area the player are in
        //World puts in the areas in the dictionary
        public Dictionary<Directions, Area> connectedArea = new Dictionary<Directions, Area>();

        //what items there are
        List<Item> items = new List<Item>();

        public Area(string name, string description )
        {
            this.name = name;
            this.description = description;
        }

        public void Connect(Area other, Directions dir)
        {
            //Adding the areas to the dictionary - at the specific direction there are the specific area
            connectedArea.Add(dir , other);
            //only possible to go one way
        }

        public void ConnectBidirectional(Area other, Directions dir)
        {
            //asked current object to connect to the other, and asked the other to connect to this area, with the opposite direction
            Connect(other , dir);
            other.Connect(this , Opposite(dir));

        }

        Directions Opposite(Directions dir )
        {
            switch ( dir )
            {
                case Directions.North:
                    return Directions.South;
                case Directions.South:
                    return Directions.North;
                case Directions.East:
                    return Directions.West;
                case Directions.West:
                    return Directions.East;
                default:
                    return Directions.North;
            }
        }

        /*void Test()
        {
            connectedArea[Directions.North] = new Area();
            //connectedArea.Add(Directions.North , new Area());, same as the next code
        }*/

    }

    
    public enum Directions
    {
        //defining labels - forcing to use one of the labelled
        North, West, East, South
    }
}
