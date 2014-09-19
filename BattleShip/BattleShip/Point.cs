using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
   
    class Point
    {
        //the enumeration belongs to the Point class so I will put it inside the class for ease of use
        public enum PointStatus
        {
            Empty, Ship, Hit, Miss
        }
        public int X { get; set; }
        public int Y { get; set; }
        //Initilize a way get and set your enumerations which is now it's own class like int or string
        public PointStatus Status {get; set;}

        //Constructor
        public Point(int x, int y, PointStatus s)
        {
            this.X = x;
            this.Y = y;
            this.Status = s;
        }

    }
}
