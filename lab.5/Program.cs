using System;
using System.Drawing;

namespace FirstTasl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var x = 5;
                var y = 6;
                var sidesSize = 4;

                var rectangleTMovement = new RectangleMovement(x, y, sidesSize);
                rectangleTMovement.Move();
                Console.Clear();
                var rectangleTurning = new RectangleTurning(x, y, sidesSize);
                rectangleTurning.Move();
            }
            catch 
            {
                Console.WriteLine("An exception was thrown...");
            }
            
            Console.ReadKey();
        }
    }
    public class RectangleMovement
    {
        private protected int X;
        private protected int Y;
        private protected int SidesSize;

        public RectangleMovement(int x, int y, int sidesSize)
        {
            X = x;
            Y = y;
            SidesSize = sidesSize;
        }

        public virtual void Move()
        {
            var rectangle = GetRectangle();
            Console.WriteLine(
                "Press arrow left or right and position will be shown. Press \"Enter\" if you want to exit");
            ConsoleKeyInfo pressedKey;
            do
            {
                pressedKey = Console.ReadKey(true);
                switch (pressedKey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine($"X position is {--rectangle.X}");
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine($"X position is {++rectangle.X}");
                        break;
                }
            } while (pressedKey.Key != ConsoleKey.Enter);

            X = rectangle.X;
            PrintInfo();
        }


        private protected Rectangle GetRectangle()
        {
            return new Rectangle(X, Y, SidesSize, SidesSize);
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Location of left angle: x - {X}, y - {Y}");
            Console.WriteLine($"Size of sides: {SidesSize}");
        }
    }
    public class RectangleTurning : RectangleMovement
    {
        public RectangleTurning(int x, int y, int sidesSize) : base(x, y, sidesSize)
        {
        }

        public override void Move()
        {
            var rectangle = GetRectangle();

            Console.WriteLine(
                "Press arrow left or right and rotation position will be shown. Press \"Enter\" if you want to exit");

            X = rectangle.X;
            Y = rectangle.Y;
            PrintInfo();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Location of left angle: x - {X}, y - {Y}");
            Console.WriteLine($"{GetRectangle()}");
            Console.WriteLine($"Size of sides: {SidesSize}");
        }
    }
}
