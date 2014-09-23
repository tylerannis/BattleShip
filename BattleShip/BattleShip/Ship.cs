using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Ship
    {
        public enum ShipType
        {
            Carrier, BattleShip, Cruiser, Submarine, Minesweeper
        }
        public ShipType Type { get; set; }
        public List<Point> OccupiedPoints { get; set; }
        public int length { get; set; }
        public bool IsDestroyed { get { return OccupiedPoints.All(x => x.Status == Point.PointStatus.Hit); } }

        //Constructor
        public Ship(ShipType typeofShip)
        {
            this.OccupiedPoints = new List<Point>();
            this.Type = typeofShip;
            switch (this.Type)
            {
                case ShipType.Carrier:
                    this.length = 5;
                    break;
                case ShipType.BattleShip:
                    this.length = 4;
                    break;
                case ShipType.Cruiser:
                    this.length = 3;
                    break;
                case ShipType.Submarine:
                    this.length = 2;
                    break;
                case ShipType.Minesweeper:
                    this.length = 1;
                    break;
                default:
                    break;
            }
        }

    }
}
