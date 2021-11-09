using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MassiveCon();
            Console.ReadKey();
        }
        public static void MassiveCon()
        {
            Cone[] allkon = new Cone[2];
            Console.WriteLine("Enter the radius and height of the cone: ");
            try
            {
                double rK = Convert.ToDouble(Console.ReadLine());
                double hK = Convert.ToDouble(Console.ReadLine());
                allkon[0] = new Cone(rK, hK);
                allkon[1] = new Frustum(rK, hK, 1.3);
                Console.Write("\n");
                foreach (Cone konuses in allkon)
                {
                    Console.WriteLine(konuses.ToString());
                    Console.Write("\n");
                }
            }
            catch
            {
                Console.WriteLine("Возникло исключение..");
            }
        }
    }
    class Cone
    {
        public double Height { get; set; }
        public double Radius { get; set; }
        public readonly string CName;

        public Cone(double h, double r)
        {
            this.Height = h;
            this.Radius = r;
            CName = "Conus";
        }
        public virtual double ConVolume()
        {
            double vol = (Math.PI * Math.Pow(Radius, 2) * Height) / 3;
            return vol;
        }
        public double ConArea()
        {
            double area = Math.PI * Math.Pow(Radius, 2);
            return area;
        }

        public override string ToString()
        {
            Console.WriteLine($"{CName}: ");
            Console.WriteLine($"Radius = {Radius}, Height = {Height}");
            return $"Volume = {ConVolume()}, Area = {ConArea()}";
        }
    }
    class Frustum : Cone
    {
        public double Radius2 { get; set; }
        public readonly string FName;
        public Frustum(double r, double h, double r2)
            : base(r, h)
        {
            this.Radius2 = r2;
            FName = "Frustum";
        }

        public override double ConVolume()
        {
            double vol1 = Math.PI * Height * (Math.Pow(Radius, 2) + (Radius * Radius2) + Math.Pow(Radius2, 2));
            return vol1;
        }

        public override string ToString()
        {
            Console.WriteLine($"{FName}: ");
            return $"Second Radius = {Radius2}, Volume {ConVolume()}";
        }
    }
}
