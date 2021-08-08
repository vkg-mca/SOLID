using System;

namespace VKG.CodeFactory.DesignPrinciples.OCP
{

    #region Violation
    public class OpenClosePrinciple_Violation
    {
        public void DrawAllShapes(int[,] coordinate, string shapeName)
        {
            switch (shapeName)
            {
                case "Circle":
                    DrawCircle(coordinate);
                    break;
                case "Rectangle":
                    DrawRectangle(coordinate);
                    break;
                case "Triangle":
                    DrawTriangle(coordinate);
                    break;
            }
        }

        private static void DrawTriangle(int[,] coordinate)
        {
            Console.WriteLine($"Triangle drawn using cordinates{coordinate}");
        }

        private static void DrawRectangle(int[,] coordinate)
        {
            Console.WriteLine($"Rectangle drawn using cordinates{coordinate}");
        }

        private static void DrawCircle(int[,] coordinate)
        {
            Console.WriteLine($"Circle drawn using cordinates{coordinate}");
        }

    }
    #endregion Violation

    #region Adherance
    public class OpenClosePrinciple_Adherance
    {
        public void DrawAllShapes(IShape[] shapes)
        {
            foreach (IShape shape in shapes)
            {
                shape.Draw();
            }
        }
    }

    public interface IShape
    {
        int[,] Coordinate { get; set; }
        void Draw();
    }
    public class Circle : IShape
    {
        public int[,] Coordinate { get; set; }

        public void Draw()
        {
            Console.WriteLine($"Circle drawn using cordinates{Coordinate}");
        }
    }
    public class Rectangle : IShape
    {
        public int[,] Coordinate { get; set; }

        public void Draw()
        {
            Console.WriteLine($"Rectangle drawn using cordinates{Coordinate}");
        }
    }

    public class Triangle : IShape
    {
        public int[,] Coordinate { get; set; }

        public void Draw()
        {
            Console.WriteLine($"Triangle drawn using cordinates{Coordinate}");
        }
    }
    #endregion Adherance

}
