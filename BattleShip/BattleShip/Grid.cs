using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public enum PlaceShipDirection
    {
        Horizontal, Vertical
    }
    class Grid
    {
        //defining a multidemenstional array
        //it's the grid and you use Point[,,] the number of ,'s + 1 is the number of dimensions, after commas name that shit....
        public Point[,] Ocean { get; set; }
        public List<Ship> ListofShips = new List<Ship>();
        public bool AllShipsDestroyed { get; }
        public int CombatRounds { get; set; }
        public Grid()
        {
            this.Ocean = new Point[10, 10];
            for (int x = 0; x <= 9; x++)
            {
                for (int y = 0; y <= 9; y++)
                {
                    this.Ocean[x, y] = new Point(x, y, Point.PointStatus.Empty);
                }
            }
            //syntax for adding points to the grid/ ocean
            //this.Ocean[x, y] = new Point(x, y, Point.PointStatus.Empty);
            this.ListofShips = ListofShips.Add(Ship.ShipType.Submarine, Ship.ShipType.Minesweeper,Ship.ShipType.Cruiser, Ship.ShipType.Carrier, Ship.ShipType.BattleShip);
            
            //add each ship to the list using PlaceShip function
            PlaceShip(ListofShips[0], PlaceShipDirection.Horizontal, 3, 3);
            PlaceShip(ListofShips[1], PlaceShipDirection.Vertical, 0, 8);
            PlaceShip(ListofShips[2], PlaceShipDirection.Horizontal, 5, 7);
            PlaceShip(ListofShips[3], PlaceShipDirection.Vertical, 9, 0);
            PlaceShip(ListofShips[4], PlaceShipDirection.Vertical, 2, 2);
        }
        //Methods
        //Place Ship
        
        public void PlaceShip(Ship shipToPlace, PlaceShipDirection direction, int startX, int startY)
        {
           
            for (int i = 0; i <= shipToPlace.length; i++)
            {
                var startPoint = Ocean[startX, startY];
                startPoint.Status = Point.PointStatus.Ship;
                shipToPlace.OccupiedPoints.Add(startPoint);
                if (direction == PlaceShipDirection.Horizontal)
                {
                    startX++;
                }
                else
                {
                    startY++;
                }
            }
        }


        //Display Ocean
        public void DisplayOcean()
        {
            Console.WriteLine(" 0  1  2  3  4  5  6  7  8  9  X");
            Console.WriteLine("0||");
            Console.WriteLine("1||");
            Console.WriteLine("2||");
            Console.WriteLine("3||");
            Console.WriteLine("4||");
            Console.WriteLine("5||");
            Console.WriteLine("6||");
            Console.WriteLine("7||");
            Console.WriteLine("8||");
            Console.WriteLine("9||");
            Console.WriteLine("Y||");
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)

                {
                    if (this.Ocean[x, y].Status == Point.PointStatus.Miss)
                    {
                        Console.WriteLine("[0]");
                    }
                    else if (this.Ocean[x, y].Status == Point.PointStatus.Hit)
                    {
                        Console.WriteLine("[+]");
                    }
                    else if (this.Ocean[x, y].Status == Point.PointStatus.Empty)
                    {
                        Console.WriteLine("[ ]");
                    }
                    else
                    {
                        Console.WriteLine("[ ]");
                    }

                }
            }
        }

        //Target
        public void Target(int x, int y)
        {
            if (this.Ocean[x, y].Status == Point.PointStatus.Ship)
            {
                this.Ocean[x, y].Status = Point.PointStatus.Hit;
            }
            else if (this.Ocean[x, y].Status == Point.PointStatus.Empty)
            {
                this.Ocean[x, y].Status = Point.PointStatus.Miss;
            }
        }

        //PlayGame
        public void PlayGame()
        {
            while (!this.AllShipsDestroyed)
            {
                int inputx = 10;
                int inputys = 10;
                bool validX = false;
                bool validY = false;
                Console.WriteLine("Please enter a number for the X axis");
                string input = Console.ReadLine();
                while (!validX)
                {
                    if (!input.Contains("qwertyuiopasdfghjklzxcvbnm"))
                    {
                        Console.WriteLine("Please input a number");

                    }
                    else
                    {
                        inputx = int.Parse(input);
                        validX = true;
                    }
                }
                
                Console.WriteLine("Please enter a number for the Y axis");
                
                string inputy = Console.ReadLine();
                while (!validY)
                {
                    
                    if (!inputy.Contains("qwertyuiopasdfghjklzxcvbnm"))
                    {
                        Console.WriteLine("Please input a number");


                    }
                    else
                    {
                       inputys = int.Parse(inputy);
                        validY = true;
                    }
                    
                }
                Target(inputx, inputys);

                CombatRounds++;
            }

            Console.WriteLine("YOU WON and it took you, " + CombatRounds + " rounds to do it");
        }

    }
}
