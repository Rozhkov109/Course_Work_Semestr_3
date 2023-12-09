using System.ComponentModel;
using System.Xml.Serialization;

public class Point : IFunctionComponent, INotifyPropertyChanged
{

    private double x;

    [XmlElement("X")]
    public double X
    { 
        get { return x; }
        set
        {
            if (x != value)
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        }
    }


    private double y;

    [XmlElement("Y")]
    public double Y
    { 
        get { return y; }
        set
        {
            if (y != value)
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
    }

    public Point() { }

    public Point(double X, double Y)
    {
        x = X;
        y = Y;
    }

    public string GetInfo()
    { return "X = " + X + "  Y = " + Y; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

