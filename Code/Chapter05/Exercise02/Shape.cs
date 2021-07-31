namespace Shape
{
    public class Shape
    {
        public float height;
        public float width;
        public float area;

        public virtual void CalculateArea()
        {
            area = height * width;
        }
    }
    public class Square : Shape
    {

        public Square(float newHeight)
        {
            height = newHeight;
            width = newHeight;
            CalculateArea(); 
        }
    }
    public class Rectangle : Shape
    {

        public Rectangle(float newHeight, float newWidth)
        {
            height = newHeight;
            width = newWidth;
            CalculateArea(); 
        }
    }

    public class Circle : Shape
    {
        public override void CalculateArea()
        {
            float radius = height/2;
            area = 3.141f * (radius * radius);
        }

        public Circle(float radius)
        {
            height = radius * 2;
            width = radius * 2;
            CalculateArea(); 
        }
    }
}



