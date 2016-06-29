using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GenericConsoleGame
{
    class Camera
    {
        public void ShowCamera()
        {
            // variables for testing/writing
            var monstros = new List<Monster>
            {
                new Monster(new Point(1, 1))
                , new Monster(new Point(2, 9))
            };

            var item = new List<GameItem>();


            int size = cameraSize/2;
            int topY = player.GetY() - size,
                bottomY = player.GetY() + size,
                topX = player.GetX() - size,
                bottomX = player.GetX() + size;
            int setX = 0, setY = 0;

            //Print Map
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int x = topX; x < bottomX; x++)
            {
                for (int y = topY; y < bottomY; y++)
                {
                    var currentLocation = new Point(x, y);
                    var cursorLocation = new Point(setX, setY);
                    
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(cursorLocation.X, cursorLocation.Y);
                    Console.Write(map[x, y]);

                    var monstersAtThisLocation = monstros.Where(x => x.Location == currentLocation);
                    if (monstersAtThisLocation.Any())
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(cursorLocation.X, cursorLocation.Y);
                        Console.Write(monstersAtThisLocation);
                    }

                    DrawSprite(monstros, currentLocation, cursorLocation);

                    DrawSprite(monstros, x, y, setX, setY);
                    DrawSprite(item, x, y, setX, setY);

                    setY++;
                }
                Console.Write("\n");
                setY = 0;
                setX++;
            }
        }

        public void DrawSprite(List<Monster> gamePieces, Point currentLocation, Point cursorLocation)
        {
            if (gamePieces.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;



                foreach (var piece in gamePieces)
                {
                    if (piece.Location == currentLocation)
                    {
                        Console.SetCursorPosition(cursorLocation.X, cursorLocation.Y);
                        Console.Write(piece);
                    }
                }
            }
        }

        public void DrawSprite(List<Monster> gamePieces, int x, int y, int newX, int newY)
        {
            if (gamePieces.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (var piece in gamePieces)
                {
                    if (piece.X == x && piece.Y == y)
                    {
                        Console.SetCursorPosition(newY, newX);
                        Console.Write(piece);
                    }
                }
            }
        }
        public void DrawSprite(List<GameItem> gamePieces, int x, int y, int newX, int newY)
        {
            if (gamePieces.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                foreach (var piece in gamePieces)
                {
                    if (piece.X == x && piece.Y == y)
                    {
                        Console.SetCursorPosition(newY, newX);
                        Console.Write(piece);
                    }
                }
            }
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    //public interface IGamePiece
    //{
    //    Point Location { get; }
    //    void ChangeLocation(int x, int y);
    //}
    public class GamePiece
    {
        public Point Location { get; }

        public GamePiece(Point startLocation)
        {
            Location = startLocation;
        }
        public void ChangeLocation(int x, int y)
        {
            Location.X = x;
            Location.Y = y;
        }


    }

    //public class GameItem : GamePiece
    //{
    //    public Point Location { get; }

    //    public GameItem(Point startLocation)
    //    {
    //        Location = startLocation;
    //    }

    //    public void ChangeLocation(int x, int y)
    //    {
    //        Location.X = x;
    //        Location.Y = y;
    //    } 
    //}

    public class GameItem : GamePiece
    {
        public GameItem(Point startLocation) : base(startLocation)
        {

        }
    }


    //public class PlayablePiece : GamePiece
    //{
    //    public Point Location { get; }

    //    public PlayablePiece(Point startLocation)
    //    {
    //        Location = startLocation;
    //    }
    //    public void ChangeLocation(int x, int y)
    //    {
    //        Location.X = x;
    //        Location.Y = y;
    //    }
    //}

    public class Monster : GamePiece
    {
        public Monster(Point startLocation) : base(startLocation)
        {
            
        }
    }


    abstract class Monstro
    {
        private int x, y, saude, ataque, defesa, experiencia;
        private char appearance;
        Random rng = new Random();

        protected Monstro(int x, int y, int argSaude, int argAtaque, int argDefesa, int argExperiencia, char argAppearance)
        {
            this.x = x;
            this.y = y;
            saude = argSaude;
            ataque = argAtaque;
            defesa = argDefesa;
            appearance = argAppearance;
            experiencia = argExperiencia;
        }

        public int ReX()
        {
            return x;
        }

        public int ReY()
        {
            return y;
        }

        public void SetX(int argX)
        {
            x = argX;
        }

        public void SetY(int argY)
        {
            y = argY;
        }

        public int ReSaude()
        {
            return saude;
        }

        public int ReAtaque()
        {
            return ataque;
        }

        public int ReDefesa()
        {
            return defesa;
        }

        public int ReExperiencia()
        {
            return experiencia;
        }

        public virtual void MoveMonster(Game argGame, Map argMap, Player argPlayer)
        {
            int movePos = rng.Next(0, 3);
            int moveSteps = rng.Next(0, 4);
            int currStep = 0;

            while (currStep < moveSteps)
            {
                switch (movePos)
                {
                    //Move Up 
                    case 0:
                        movePos = x - 1;
                        if (movePos >= 0)
                        {
                            if (!argMap.CheckTile(movePos, y)) x--;
                            else currStep = moveSteps;
                        }
                        break;
                    //Move Down 
                    case 1:
                        movePos = x + 1;
                        if (movePos < argMap.ReLengthX())
                        {
                            if (!argMap.CheckTile(movePos, y)) x++;
                            else currStep = moveSteps;
                        }
                        break;
                    //Move Left 
                    case 2:
                        movePos = y - 1;
                        if (movePos >= 0)
                        {
                            if (!argMap.CheckTile(x, movePos)) y--;
                            else currStep = moveSteps;
                        }
                        break;
                    //Move Right 
                    case 3:
                        movePos = y + 1;
                        if (movePos < argMap.ReLengthY())
                        {
                            if (!argMap.CheckTile(x, movePos)) y++;
                            else currStep = moveSteps;
                        }
                        break;
                }
                currStep++;
                if (x == argPlayer.GetX() && y == argPlayer.GetY()) argPlayer.EngageMonster(this);
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(appearance);
            return str.ToString();
        }
    }
    abstract class Item
    {
        protected int x, y, ataque, defesa, saude, raridade;
        protected char appearance;
        private bool pickedUp;
        private static readonly Random rng = new Random();

        protected Item(Map argMap, int argAtaque, int argDefesa, int argSaude, int argRaridade, char argAppearance)
        {
            bool empty = false;
            while (!empty)
            {
                x = rng.Next(1, argMap.ReLengthX() - 1);
                y = rng.Next(1, argMap.ReLengthY() - 1);
                if (!argMap.CheckTile(y, x)) empty = true;
            }
            pickedUp = false;
            ataque = argAtaque;
            defesa = argDefesa;
            saude = argSaude;
            raridade = argRaridade;
            appearance = argAppearance;
        }

        public void SetX(int argX)
        {
            x = argX;
        }

        public void SetY(int argY)
        {
            y = argY;
        }

        public int ReX()
        {
            return x;
        }

        public int ReY()
        {
            return y;
        }

        public int ReAtaque()
        {
            return ataque;
        }

        public int ReDefesa()
        {
            return defesa;
        }

        public int ReSaude()
        {
            return saude;
        }

        public int ReRaridade()
        {
            return raridade;
        }

        public char ReAppearance()
        {
            return appearance;
        }

        public void SetPicked(bool argPickedUp)
        {
            pickedUp = argPickedUp;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(this.GetType().Name);
            return str.ToString();
        }

        public static Random ReRNG()
        {
            return rng;
        }
    }

}
