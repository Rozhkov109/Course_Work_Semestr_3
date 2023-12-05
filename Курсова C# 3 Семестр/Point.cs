using System.Xml.Serialization;

public class Point
{
    [XmlElement("X")]
    public double X { get; set; }

    [XmlElement("Y")]
    public double Y { get; set; }

    public Point() { }

    public Point(double X, double Y)
    {
        this.X = X;
        this.Y = Y;
    }

    public override string ToString()
    { return "X = " + X + "  Y = " + Y; }
}

