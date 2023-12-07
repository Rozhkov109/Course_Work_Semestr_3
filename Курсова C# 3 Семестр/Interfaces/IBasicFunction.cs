/// <summary>
/// Інтерфейс для представлення базової фукнції
/// </summary>
interface IBasicFunction<T>
{
    /// <summary>
    /// Перевіряє фунцкцію на унімодальність                                             
    /// </summary>
    /// <returns>Повертає true, якщо функція унімодальна, інакше false.</returns>
    bool CheckUnimodal();

    /// <summary>
    /// Знаходить максимум функції на заданому інтервалі за заданим розробником алгоритмом                                        
    /// </summary>
    /// <returns>Повертає максимальне значення фукнції на інтервалі</returns>
    double FindMaximum(double start, double end, T function, double eps);

    /// <summary>
    /// Виведення інформації про функцію у консоль                                     
    /// </summary>
    /// <returns>Рядок з інформацією про фукнцію</returns>
    string GetInfo();
}

