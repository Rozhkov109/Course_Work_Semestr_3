using System;

public class ErrorManager
{

    public delegate void ErrorHandlerDelegate(string errorMessage);


    public static event EventHandler<string> ErrorOccurredEvent;

    public static ErrorHandlerDelegate ErrorHandler { get; set; }


    protected virtual void OnErrorOccurred(string errorMessage)
    {
        ErrorOccurredEvent?.Invoke(this, errorMessage);
    }


    public static void PrintError(string errorMessage)
    {
        ErrorHandler?.Invoke(errorMessage);
        ErrorOccurredEvent?.Invoke(null, errorMessage);
    }

    // Метод для консольного застосунку
    public static void ConsoleError(string errorMessage)
    {
        Console.WriteLine(errorMessage);
    }

    // Метод для графічного застосунку
    public static string GetErrorMessage(string errorMessage)
    {
        return errorMessage;
    }
}
