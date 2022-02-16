using System;

namespace SquareFrom_3_Dots
{
    // Gets the coordinates of three points 
    // If they are square tops, prints the fourth top.
    // Else print "This three dots aren't top of the square."

    internal class Vector2D
    {
        public const double Epsilon = 0.00001;

        public readonly double v1;
        public readonly double v2;
        public double Length { get => Math.Sqrt(v1 * v1 + v2 * v2); }

        public Vector2D(double v1, double v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Vector2D(double x1, double y1, double x2, double y2)
        {
            v1 = x2 - x1;
            v2 = y2 - y1;
        }

        public static double ScalarTriple(Vector2D a, Vector2D b)
        {
            return a.v1 * b.v1 + a.v2 * b.v2;
        }

        public static bool IsSquareSide(Vector2D a, Vector2D b)
        {
            return (a.Length == b.Length) && (Math.Abs(Vector2D.ScalarTriple(a, b)) < Epsilon);
        }

        public static Vector2D Inverse(Vector2D a)
        {
            return new Vector2D(-a.v1, -a.v2);
        }
    }

    internal class Program
    {
        
        private static void InputDot(char dotName, ref double x, ref double y)
        {
            Console.WriteLine("Input Dot {0}, x y:", dotName);
            string[] input = Console.ReadLine().Split(' ');
            x = Convert.ToDouble(input[0]);
            y = Convert.ToDouble(input[1]);
        }

        private static void OutputDotD(Vector2D a, double x, double y)
        {
            double Dx;
            double Dy;
            Dx = x + a.v1;
            Dy = y + a.v2;
            Console.WriteLine("Dot D: x = {0}, y = {1}", Dx, Dy);
        }

        static void Main(string[] args)
        {
            double Ax = 0;
            double Ay = 0;
            InputDot('A', ref Ax, ref Ay);
            double Bx = 0;
            double By = 0;
            InputDot('B', ref Bx, ref By);
            double Cx = 0;
            double Cy = 0;
            InputDot('C', ref Cx, ref Cy);
            Vector2D AB = new Vector2D(Ax, Ay, Bx, By);
            Vector2D AC = new Vector2D(Ax, Ay, Cx, Cy);
            Vector2D BC = new Vector2D(Bx, By, Cx, Cy);
            if (Vector2D.IsSquareSide(AB, AC))
                OutputDotD(AB, Cx, Cy);
            else if (Vector2D.IsSquareSide(AB, BC))
                OutputDotD(BC, Ax, Ay);
            else if (Vector2D.IsSquareSide(AC, BC))
                OutputDotD(Vector2D.Inverse(AC), Bx, By);
            else
                Console.WriteLine("This three dots aren't top of the square.");

        }
    }
}
