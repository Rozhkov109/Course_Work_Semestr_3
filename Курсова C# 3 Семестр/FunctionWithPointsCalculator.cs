using System;
using System.Collections.Generic;
using System.Linq;

public class FunctionWithPointsCalculator : IFunctionCalculator<FunctionWithPoints>
{

    /// <summary>
    /// Пошук максимального значення для F(x) - (Gx) на заданому інтервалі із заданою точністю                                         
    /// </summary>
    /// <returns>Повертає максимальне значення F(x) - (Gx) на заданому інтервалі </returns>
    public double FindMaximum(double start, double end, FunctionWithPoints Fx, FunctionWithPoints Gx, double eps)
    {
        if (!CheckUnimodal(Fx, Gx))
        {
            ErrorManager.PrintError("Помилка! Функція F(x) - G(x) не унімодальна. Точний пошук максимуму неможливий.");
            return double.NaN;
        }

        if (Fx.PointsList.Count >= 2 && Gx.PointsList.Count >= 2) // Якщо функції мають хоча б дві точки
        {
            double left = start;
            double right = end;

            while (right - left > eps)
            {
                double mid = (left + right) / 2;

                double fMid = Fx.Interpolation(mid, eps) - Gx.Interpolation(mid,eps);
                double fRight = Fx.Interpolation(right, eps) - Gx.Interpolation(right,eps);

                if (fMid < fRight) // Якщо права частина більше, ліва стає серединою проміжку
                { left = mid; }
                else
                { right = mid; }
            }

            double optimalX = (left + right) / 2;
            double fOptimal = Fx.Interpolation(optimalX, eps) - Gx.Interpolation(optimalX, eps);

            return fOptimal;
        }

        else
        {
            ErrorManager.PrintError("Помилка! Принаймні одна функція містить менше 2 точок!");
            return double.NaN;
        }
    }



    /// <summary>
    /// Перевірка на унімодальність функції F(x) - (Gx)                                      
    /// </summary>
    /// <returns>true, якщо функція F(x) - (Gx) унімодальна, інакше - false</returns>
    public bool CheckUnimodal(FunctionWithPoints Fx, FunctionWithPoints Gx)
    {       
        int counter = 0;
        int minPointsCount = Math.Min(Fx.PointsList.Count, Gx.PointsList.Count);

        for (int i = 0; i < minPointsCount - 2; i++)
        {                       
            if (Fx.PointsList[i].Y - Gx.PointsList[i].Y == Fx.PointsList[i + 1].Y - Gx.PointsList[i + 1].Y)
                continue; // Якщо Y однакові для обох функцій, пропускаємо цикл

            bool isCurrentPointIncreasing = Fx.PointsList[i].Y - Gx.PointsList[i].Y <
                Fx.PointsList[i + 1].Y - Gx.PointsList[i + 1].Y;


            bool isNextPointIncreasing = Fx.PointsList[i + 1].Y - Gx.PointsList[i + 1].Y <
                Fx.PointsList[i + 2].Y - Gx.PointsList[i + 2].Y; ;

            if (isNextPointIncreasing != isCurrentPointIncreasing)
            {
                counter++;
                if (counter > 1)
                {
                    // Якщо напрямок зміниться більше одного разу, то функція не унімодальна!
                    return false;
                }
            }
        }
        return true;
    }

}


