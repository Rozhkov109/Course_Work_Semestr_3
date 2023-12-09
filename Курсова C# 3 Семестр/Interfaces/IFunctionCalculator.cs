
interface IFunctionCalculator<T>
{

    /// <summary>
    /// Перевірка на унімодальність функції F(x) - (Gx)                                      
    /// </summary>
    /// <returns>true, якщо функція F(x) - (Gx) унімодальна, інакше - false</returns>
    bool CheckUnimodal(FunctionWithPoints Fx, FunctionWithPoints Gx);

    /// <summary>
    /// Пошук максимального значення для F(x) - (Gx) на заданому інтервалі із заданою точністю                                         
    /// </summary>
    /// <returns>Повертає максимальне значення F(x) - (Gx) на заданому інтервалі </returns>
    double FindMaximum(double start, double end, T Fx, T Gx, double eps);


}
