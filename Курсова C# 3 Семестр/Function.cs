﻿using System;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class Function
{
    private List<Point> PointsList = new List<Point>();

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
       return result;
    }
}


