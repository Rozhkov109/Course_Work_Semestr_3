using System;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class FunctionWithPoints : IBasicFunction<FunctionWithPoints>
{
    private List<Point> pointsList = new List<Point>();

    public List<Point> PointsList { get { return pointsList; } }

    public FunctionWithPoints() { }

    /// <summary>
    /// Додавання нової точки у кінець списку
    /// </summary>
    public void AddPointToEnd(double X, double Y)
    { pointsList.Add(new Point(X, Y)); }

    /// <summary>
    /// Видалення останнього елемента списку
    /// </summary>
    public void RemoveLastPoint()
    {
        if (pointsList.Any())
            pointsList.RemoveAt(pointsList.Count - 1);
    }

    /// <summary>
    /// Очищує список точок
    /// </summary>
    public void ClearList()
    { pointsList.Clear(); }

    public string GetInfo()
    {
       string result = "";
       foreach (Point point in pointsList)
       {
          result += point.GetInfo();
          result += "\n";
       }
        return result;
    }



    /// <summary>
    /// Отримання проміжних значень з набору точок за допомогою інтерполяції
    /// методу поліномів Лагранжа
    /// </summary>
    public double Interpolation(double X, double eps)
    {
        if (PointsList.Count() >= 2)
        {
            double result = 0;
            foreach (Point point in PointsList)
            {
                double interpolationTerm = point.Y; // Вираз для обчислення поліному (Y * basicPolinom)
                foreach (Point otherPoint in PointsList)
                {
                    if (point.X != otherPoint.X) // Не можна проводити обчислення для коренів з однаковими значеннями!!!
                    { interpolationTerm *= (X - otherPoint.X) / (point.X - otherPoint.X); }
                }
                result += interpolationTerm;
            }
            return Math.Round(result, (int)Math.Log10(1 / eps)); // Округлення до заданої точності
        }
        else
        {
            ErrorManager.PrintError("Помиуцулка! Недостатня кількість точок для інтерполяції");
            return double.NaN;
        }
    }

}


