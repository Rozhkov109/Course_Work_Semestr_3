using System;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class FunctionWithPoints : IBasicFunction<FunctionWithPoints>
{
    private List<Point> pointsList = new List<Point>();

    private bool isUnimodal;
    public bool IsUnimodal
    { 
        get { return isUnimodal; } 
    }

    public List<Point> PointsList
    { 
        get { return pointsList; } 
    }

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
       if(CheckUnimodal()) 
            result += "Унімодальна";
        else 
            result += "Не унімодальна";
        return result;
    }

    public bool CheckUnimodal()
    {
        if(PointsList.Count >= 2)
        {
            int counter = 0;

            for (int i = 0; i < PointsList.Count - 2; i++)
            {
                if (PointsList[i].Y == PointsList[i + 1].Y) continue; // Якщо Y однакові, пропускаємо цикл
                bool isDecreasing = PointsList[i].Y > PointsList[i + 1].Y;


                bool isCurrentDecreasing = PointsList[i + 1].Y > PointsList[i + 2].Y;
                if (isCurrentDecreasing != isDecreasing)
                {
                    counter++;
                    if (counter > 1)
                    {
                        // Якщо напрямок зміниться більше одного разу, то функція не унімодальна!
                        return isUnimodal = false;
                    }
                }
            }
            return isUnimodal = true;
        }
        else
        {
            ErrorManager.PrintError("Помилка! Недостатня кількість точок для перевірки на унімодальність");
            return isUnimodal = false;
        }
    }

    public double FindMaximum(double start, double end, FunctionWithPoints func, double eps)
    {
        if (!func.IsUnimodal)
        {
            ErrorManager.PrintError("Функція не унімодальна. Пошук максимуму не гарантований.");
            return double.NaN;
        }
        List<Point> funcList = func.PointsList;
        if (funcList.Count() >= 2) // Якщо список має хоча б дві точки
        {
            FunctionWithPointsCalculator calc = new FunctionWithPointsCalculator();
            double left = start;
            double right = end;

            while (right - left > eps)
            {
                double mid = (left + right) / 2;

                double fMid = calc.Interpolation(func, mid, eps);
                double fRight = calc.Interpolation(func, right, eps);

                if (fMid < fRight)
                { left = mid; }
                else
                { right = mid; }
            }

            double optimalX = (left + right) / 2;
            double fOptimal = calc.Interpolation(func, optimalX, eps);

            return fOptimal;
        }
        else
        {
            ErrorManager.PrintError("Помилка! Недостатня кількість точок для інтерполяції");
            return double.NaN;
        }
    }
}


