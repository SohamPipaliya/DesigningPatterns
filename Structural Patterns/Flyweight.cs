using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesigningPatterns.Structural_Patterns
{
    class Flyweight
    {
        static void Main(string[] args)
        {
            Circle circle = (Circle)ShapeFactory.GetShape("circle");
            circle.SetColor("Red");
            circle.Draw();
            Console.WriteLine();
            circle.SetColor("Orange");
            circle.Draw();
            Console.WriteLine();
            circle.SetColor("Green");
            circle.Draw();
            Console.WriteLine();
            circle.SetColor("Pink");
            circle.Draw();
            Console.Read();
        }
    }

    public interface Shape
    {
        void Draw();
    }

    public class Circle : Shape
    {
        public string Color { get; set; }

        private int XCor = 10;
        private int YCor = 20;
        private int Radius = 30;

        public void SetColor(string Color)
        {
            this.Color = Color;
        }

        public void Draw()
        {
            Console.WriteLine(" Circle: Draw() [Color : " + Color + ", X Cor : " + XCor + ", YCor :" + YCor + ", Radius :"
                    + Radius);
        }
    }

    public class ShapeFactory
    {
        private static Dictionary<string, Shape> shapeMap = new Dictionary<string, Shape>();
        public static Shape GetShape(string shapeType)
        {
            Shape shape = null;
            if (shapeType.Equals("circle", StringComparison.InvariantCultureIgnoreCase))
            {
                if (shapeMap.TryGetValue("circle", out shape))
                {
                }
                else
                {
                    shape = new Circle();
                    shapeMap.Add("circle", shape);
                    Console.WriteLine(" Creating circle object with out any color in shapefactory \n");
                }
            }
            return shape;
        }
    }
}
