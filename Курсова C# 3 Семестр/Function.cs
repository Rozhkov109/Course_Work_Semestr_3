using System;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class Function
{
    private List<Point> PointsList = new List<Point>();
    private bool isUnimodal;
    public bool IsUnimodal
    { get { return isUnimodal; } }

    public List<Point> Points
    { get { return PointsList; } }

    public Function() { }

    /// <summary>
    /// Додавання нової точки у кінець списку
    /// </summary>
    public void AddPointToEnd(double X, double Y)
    { PointsList.Add(new Point(X, Y)); }

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
       if(CheckUnimodal()) 
            result += "Унімодальна";
        else 
            result += "Не унімодальна";
        return result;
    }

    /// <summary>
    /// Перевіряє фунцкцію на унімодальність                                             
    /// </summary>
    /// <returns>Повертає true, якщо функція унімодальна, інакше false.</returns>
    public bool CheckUnimodal()
    {
        bool isDecreasing = PointsList[0].Y > PointsList[1].Y;
        for (int i = 1; i < PointsList.Count - 1; i++)
        {
            bool isCurrentDecreasing = PointsList[i].Y > PointsList[i + 1].Y;
            if (isCurrentDecreasing != isDecreasing)
            {
                // Якщо напрямок зміниться хоча б один раз, то функція не унімодальна!
                return isUnimodal = false;
            }
        }
        return isUnimodal = true;
    }
}


