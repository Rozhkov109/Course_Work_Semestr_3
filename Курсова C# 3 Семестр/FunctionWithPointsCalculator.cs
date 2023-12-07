using System;
using System.Collections.Generic;
using System.Linq;

public class FunctionWithPointsCalculator : IFunctionCalculator<FunctionWithPoints>
{

    /// <summary>
    /// Отримання проміжних значень з набору точок за допомогою інтерполяції
    /// методу поліномів Лагранжа
    /// </summary>
    public double Interpolation(FunctionWithPoints function,double X,double eps)
    {
        List<Point> PointsList = function.PointsList;
        if (PointsList.Any())
        {
            double result = 0;
            foreach (Point point in PointsList)
            {
                double interpolationTerm = point.Y; // Вираз для обчислення поліному (Y * basicPolinom)
                foreach (Point otherPoint in PointsList)
                {
                    if (point != otherPoint) // Не можна проводити обчислення для коренів з однаковими індексами!!!
                    { interpolationTerm *= (X - otherPoint.X) / (point.X - otherPoint.X); }
                }
                result += interpolationTerm;
            }
            return Math.Round(result, (int)Math.Log10(1 / eps)); // Округлення до заданої точності
        }

        else
        {
            // Вікно з помилкою у графічному застосунку
            return double.NaN;
        }
    }


    /// <summary>
    /// Пошук максимального значення для F(x) - (Gx) на заданому інтервалі із заданою точністю                                         
    /// </summary>
    /// <returns>Повертає максимальне значення F(x) - (Gx) на заданому інтервалі </returns>
    public double FindMaximum(double start, double end, FunctionWithPoints Fx, FunctionWithPoints Gx, double eps)
    {  
        if(Fx.CheckUnimodal() && Gx.CheckUnimodal()) 
        {
            return Fx.FindMaximum(start, end, Fx, eps) - Gx.FindMaximum(start, end, Gx, eps);
        }
        else 
        {
            Console.WriteLine("Одна з функцій не унімодальна. Пошук максимуму не гарантований.");
            return double.NaN;
        }
    }


}

