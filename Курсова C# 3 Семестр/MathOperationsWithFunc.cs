using System;
using System.Collections.Generic;
using System.Linq;

public class MathOperationsWithFunc
{

    /// <summary>
    /// Отримання проміжних значень з набору точок за допомогою інтерполяції
    /// методу поліномів Лагранжа
    /// </summary>
    private double InterpolationLagrange(List<Point> PointsList,double X,double eps)
    {
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
    /// Перевіряє фунцкцію F(x) - (Gx) на унімодальність                                             
    /// </summary>
    /// <returns>Повертає true, якщо функція унімодальна, інакше false.</returns>
    private bool IsFunctionUnimodal (Function Fx, Function Gx) 
    { return Fx.CheckUnimodal() && Gx.CheckUnimodal(); }

    private double FindMaximumWithDichtomy(double start, double end, Function Fx, Function Gx, double eps)
    {
        List<Point> F_list = Fx.Points;
        List<Point> G_list = Gx.Points;
        if (F_list.Any() && G_list.Any()) // Якщо списки не порожні
        {
            double left = start;
            double right = end;

            while (right - left > eps)
            {
                double mid = (left + right) / 2;

                double fMid = InterpolationLagrange(F_list, mid, eps);
                double gMid = InterpolationLagrange(G_list, mid, eps);
                double funcMid = fMid - gMid;

                double fRight = InterpolationLagrange(F_list, right, eps);
                double gRight = InterpolationLagrange(G_list, right, eps);
                double funcRight = fRight - gRight;

                if (funcMid < funcRight)
                { left = mid; }
                else
                { right = mid; }
            }

            double optimalX = (left + right) / 2;
            double fOptimal = InterpolationLagrange(F_list, optimalX, eps);
            double gOptimal = InterpolationLagrange(G_list, optimalX, eps);

            return fOptimal - gOptimal;
        }
        else
        {
            // Вікно з помилкою у графічному застосунку
            return double.NaN;
        }
    }

    public double FindMaximum(double start, double end, Function Fx, Function Gx, double eps)
    {
       bool isUnimodal = IsFunctionUnimodal(Fx, Gx);
        if (isUnimodal) 
        {
           return FindMaximumWithDichtomy(start,end,Fx,Gx,eps);
        }

        else
        {
            // Інший метод (в розробці)
            return double.NaN;
        }

    }


}

