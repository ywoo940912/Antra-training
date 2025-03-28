using System;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    // Constructor with all parameters
    public Color(int red, int green, int blue, int alpha)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }

    // Constructor with default alpha (255)
    public Color(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = 255;
    }

    // Getters and Setters for red, green, blue, and alpha
    public int Red
    {
        get { return red; }
        set { red = value; }
    }

    public int Green
    {
        get { return green; }
        set { green = value; }
    }

    public int Blue
    {
        get { return blue; }
        set { blue = value; }
    }

    public int Alpha
    {
        get { return alpha; }
        set { alpha = value; }
    }

    // Method to get the grayscale value
    public int GetGrayscaleValue()
    {
        return (red + green + blue) / 3;
    }

    // Display color information
    public void DisplayColorInfo()
    {
        Console.WriteLine($"Color - Red: {red}, Green: {green}, Blue: {blue}, Alpha: {alpha}");
    }
}

public class Ball
{
    private int size;
    private Color color;
    private int throwCount;

    // Constructor with size and color
    public Ball(int size, Color color)
    {
        this.size = size;
        this.color = color;
        this.throwCount = 0;
    }

    // Method to pop the ball (size = 0)
    public void Pop()
    {
        size = 0;
    }

    // Method to throw the ball, increases throw count if the ball is not popped
    public void Throw()
    {
        if (size > 0)
        {
            throwCount++;
        }
        else
        {
            Console.WriteLine("Can't throw a popped ball!");
        }
    }

    // Method to get the throw count
    public int GetThrowCount()
    {
        return throwCount;
    }

    // Display ball information
    public void DisplayBallInfo()
    {
        Console.WriteLine($"Ball - Size: {size}, Throw Count: {throwCount}");
        color.DisplayColorInfo();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create Color instances
        Color redColor = new Color(255, 0, 0);
        Color greenColor = new Color(0, 255, 0);
        Color blueColor = new Color(0, 0, 255);

        // Create Ball instances
        Ball redBall = new Ball(10, redColor);
        Ball greenBall = new Ball(15, greenColor);
        Ball blueBall = new Ball(20, blueColor);

        // Throw balls
        redBall.Throw();
        greenBall.Throw();
        blueBall.Throw();
        blueBall.Throw(); // Throw blue ball twice

        // Pop one ball
        greenBall.Pop();

        // Try to throw the popped ball
        greenBall.Throw(); // This won't count

        // Display ball information
        redBall.DisplayBallInfo();
        greenBall.DisplayBallInfo();
        blueBall.DisplayBallInfo();

        // Display grayscale values for the colors
        Console.WriteLine($"Grayscale of Red Ball: {redColor.GetGrayscaleValue()}");
        Console.WriteLine($"Grayscale of Green Ball: {greenColor.GetGrayscaleValue()}");
        Console.WriteLine($"Grayscale of Blue Ball: {blueColor.GetGrayscaleValue()}");
    }
}
