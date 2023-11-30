public class Point
{
    public double X { get; private set; }
    public double Y { get; private set; }

    public Point(double X, double Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public override string ToString()
    { return "X = " + X + "  Y = " + Y; }
}

