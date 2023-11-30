using System;
using System.Collections.Generic;
using System.Linq;

public class MathOperationsWithFunc
{

    /// <summary>
    /// Отримання проміжних значень з набору точок за допомогою інтерполяції
    /// методу поліномів Лагранжа
    /// 
    /// </summary>
    public double InterpolationLagrange(List<Point> PointsList,double X,double eps)
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
            result = Math.Round(result, (int)Math.Log10(1 / eps)); // Округлення до заданої точності
            return result;
        }

        else
        {
            // Вікно з помилкою у графічному застосунку
            return double.NaN;
        }
    }

    public double FindMaximumWithDichtomy(double start, double end, List<Point> Fx, List<Point> Gx,  double eps) 
    {
        if (Fx.Any() && Gx.Any())
        {
            double left = start;
            double right = end;

            while (right - left > eps)
            {
                double mid1 = left + (right - left) / 3;
                double mid2 = right - (right - left) / 3;

                double fMid1 = InterpolationLagrange(Fx, mid1, eps);
                double gMid1 = InterpolationLagrange(Gx, mid1, eps);
                double funcMid1 = fMid1 - gMid1;

                double fMid2 = InterpolationLagrange(Fx, mid2, eps);
                double gMid2 = InterpolationLagrange(Gx, mid2, eps);
                double funcMid2 = fMid2 - gMid2;

                if (funcMid1 < funcMid2)
                { left = mid1; }
                else
                { right = mid2; }
            }

            double optimalX = (left + right) / 2;
            double fOptimal = InterpolationLagrange(Fx, optimalX, eps);
            double gOptimal = InterpolationLagrange(Gx, optimalX, eps);

            return fOptimal - gOptimal;
        }
        else
        {
            // Вікно з помилкою у графічному застосунку
            return double.NaN;
        }
    }
}

