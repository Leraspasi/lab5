using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MethodInfo();
            Console.ReadKey();
        }
        public static void MethodInfo()
        {
            try
            {
                Console.WriteLine("Enter the value for the length of the matrix: ");
                int s1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the value for the width of the matrix: ");
                int s2 = Convert.ToInt32(Console.ReadLine());
                int[,] massive = new int[s1, s2];
                new IdentMatrix(s1, s2, massive).IdentityMatrix();
                new UpperMatrix(s1, s2, massive).UpperTrMatrix();
            }
            catch
            {
                Console.WriteLine("An exception was thrown");
            }
        }
    }
    public class Matrix
    {
        public int Size1 { get; set; }
        public int Size2 { get; set; }
        public int[,] MasMatrix { get; set; }

        public Matrix(int s1, int s2, int[,] matrix)
        {
            this.Size1 = s1;
            this.Size2 = s2;
            this.MasMatrix = matrix;
        }

        public virtual void IdentityMatrix()
        {

            for (int i = 0; i < MasMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < MasMatrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        MasMatrix[i, j] = 1;
                    }
                    else
                    {
                        MasMatrix[i, j] = 0;
                    }

                    Console.Write(MasMatrix[i, j] + "\t");
                }
                Console.Write("\n");
            }

        }

        public virtual void UpperTrMatrix()
        {
            for (int i = 0; i < MasMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < MasMatrix.GetLength(1); j++)
                {
                    MasMatrix[i, j] = 1;
                }
            }
            for (int i = 0; i < MasMatrix.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < MasMatrix.GetLength(1); j++)
                {

                    if (i <= j)
                        Console.Write(MasMatrix[i, j] + "\t");
                    else
                        Console.Write("0\t");
                }

            }
        }

    }
    public class IdentMatrix : Matrix
    {
        public readonly string Name;
        public IdentMatrix(int s1, int s2, int[,] massive)
            : base(s1, s2, massive)
        {
            Name = "Indentity Matrix";
        }
        public override void IdentityMatrix()
        {
            Console.WriteLine($"{Name}: ");
            base.IdentityMatrix();
        }

    }
    public class UpperMatrix : Matrix
    {
        public readonly string Name;
        public UpperMatrix(int s1, int s2, int[,] massive)
            : base(s1, s2, massive)
        {
            Name = "Upper Triangular Matrix";
        }

        public override void UpperTrMatrix()
        {
            Console.WriteLine($"{Name}: ");
            base.UpperTrMatrix();
        }
    }
}
