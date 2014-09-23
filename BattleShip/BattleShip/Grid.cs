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
        public bool AllShipsDestroyed { get { return this.ListofShips.All(x => x.IsDestroyed); } }
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
            this.ListofShips = new List<Ship>();
            
            ListofShips.Add(new Ship(Ship.ShipType.Carrier));
            ListofShips.Add(new Ship(Ship.ShipType.BattleShip));
            ListofShips.Add(new Ship(Ship.ShipType.Cruiser));
            ListofShips.Add(new Ship(Ship.ShipType.Minesweeper));
            ListofShips.Add(new Ship(Ship.ShipType.Submarine));
            
            
            //add each ship to the list using PlaceShip function
            PlaceShip(ListofShips[0], PlaceShipDirection.Horizontal, 3, 3);
            PlaceShip(ListofShips[1], PlaceShipDirection.Vertical, 8, 0);
            PlaceShip(ListofShips[2], PlaceShipDirection.Horizontal, 5, 7);
            PlaceShip(ListofShips[3], PlaceShipDirection.Vertical, 0, 5);
            PlaceShip(ListofShips[4], PlaceShipDirection.Vertical, 2, 2);
        }
        //Methods
        //Place Ship
        
        public void PlaceShip(Ship shipToPlace, PlaceShipDirection direction, int startX, int startY)
        {
           
            for (int i = 0; i <= shipToPlace.length; i++)
            {
                
                Ocean[startX, startY].Status = Point.PointStatus.Ship;
                shipToPlace.OccupiedPoints.Add(Ocean[startX,startY]);
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
           
            for (int y = 0; y < 10; y++)
            {
                Console.Write(y + "||");
                for (int x = 0; x < 10; x++)

                {
                    Point aPoint = this.Ocean[x, y];
                    if (aPoint.Status == Point.PointStatus.Miss)
                    {
                        Console.Write("[0]");
                    }
                    else if (aPoint.Status == Point.PointStatus.Hit)
                    {
                        Console.Write("[+]");
                    }
                    else if (aPoint.Status == Point.PointStatus.Empty)
                    {
                        Console.Write("[ ]");
                    }
                    else
                    {
                        Console.Write("[ ]");
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
                DisplayOcean();
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
