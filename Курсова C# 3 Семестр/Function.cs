using System.Collections.Generic;
using System.Linq;

public class Function
{
    private List<Point> PointsList;

    public Function()
    { PointsList = new List<Point>(); }

    public List<Point> GetPointsList()
    { return PointsList; }

    /// <summary>
    /// Додавання нової точки у кінець списку
    /// </summary>
    public void AddPointToEnd(double X, double Y)
    {
        if (PointsList == null) PointsList = new List<Point>();
        PointsList.Add(new Point(X, Y));
    }

    /// <summary>
    /// Видалення останнього елемента списку
    /// </summary>
    public void RemoveLastPoint()
    {
        if (PointsList.Any())
            PointsList.RemoveAt(PointsList.Count - 1);
    }

    /// <summary>
    /// Очищує список точок
    /// </summary>
    public void ClearList()
    { PointsList.Clear(); }

    public override string ToString()
    {
       string result = "";
       foreach (Point point in PointsList)
       {
          result += point.ToString();
          result += "\n";
       }
       return result;
    }
}


