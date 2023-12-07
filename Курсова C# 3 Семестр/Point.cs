using System.Xml.Serialization;

public class Point : IFunctionComponent
{
    [XmlElement("X")]
    private double x;

    public double X
    { 
        get { return x; }
        set { x = value; }
    }

    [XmlElement("Y")]
    private double y;

    public double Y
    { 
        get { return y; }
        set { y = value; }
    }

    public Point() { }

    public Point(double X, double Y)
    {
        x = X;
        y = Y;
    }

    public string GetInfo()
    { return "X = " + X + "  Y = " + Y; }
}

