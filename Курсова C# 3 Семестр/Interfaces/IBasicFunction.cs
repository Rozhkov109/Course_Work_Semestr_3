/// <summary>
/// Інтерфейс для представлення базової фукнції
/// </summary>
interface IBasicFunction<T>
{

    /// <summary>
    /// Отримання проміжних значень функції за допомогою інтерполяції
    /// </summary>
    double Interpolation(double X, double eps);


    /// <summary>
    /// Виведення інформації про функцію у консоль                                     
    /// </summary>
    /// <returns>Рядок з інформацією про фукнцію</returns>
    string GetInfo();
}

