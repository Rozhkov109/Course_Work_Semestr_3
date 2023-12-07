using System;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class FunctionWithPoints : IBasicFunction<FunctionWithPoints>
{
    private List<Point> pointsList = new List<Point>();
    private bool isUnimodal;
    public bool IsUnimodal
    { get { return isUnimodal; } }

    public List<Point> PointsList
    { get { return pointsList; } }

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
        bool isDecreasing = pointsList[0].Y > pointsList[1].Y;
        for (int i = 1; i < pointsList.Count - 1; i++)
        {
            bool isCurrentDecreasing = pointsList[i].Y > pointsList[i + 1].Y;
            if (isCurrentDecreasing != isDecreasing)
            {
                // Якщо напрямок зміниться хоча б один раз, то функція не унімодальна!
                return isUnimodal = false;
            }
        }
        return isUnimodal = true;
    }

    public double FindMaximum(double start, double end, FunctionWithPoints func, double eps)
    {
        List<Point> funcList = func.PointsList;
        if (funcList.Any()) // Якщо список не порожній
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
            // Вікно з помилкою у графічному застосунку
            return double.NaN;
        }
    }
}


