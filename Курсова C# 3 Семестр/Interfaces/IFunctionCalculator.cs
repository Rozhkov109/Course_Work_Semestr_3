
interface IFunctionCalculator<T>
{
    /// <summary>
    /// Отримання проміжних значень функції за допомогою інтерполяції
    /// </summary>
    double Interpolation(T function, double X, double eps);

    /// <summary>
    /// Пошук максимального значення для F(x) - (Gx) на заданому інтервалі із заданою точністю                                         
    /// </summary>
    /// <returns>Повертає максимальне значення F(x) - (Gx) на заданому інтервалі </returns>
    double FindMaximum(double start, double end, T Fx, T Gx, double eps);


}
