interface IFileManager<T>
{
    /// <summary>
    /// Серіалізація функцій в файл .xml
    /// </summary>
    void SerializeFunctionsToXML(T F, T G, string pathToSave);

    /// <summary>
    /// Десеріалізація функцій з файлу .xml
    /// </summary>
    (T, T) DeserializeFunctionsFromXML(string pathToLoad);

    /// <summary>
    /// Генерація звіту у форматі PDF
    /// </summary>
    void GeneratePDFReport(T F, T G, string pathToSave);
}
