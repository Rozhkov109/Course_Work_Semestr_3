using System;
using System.Text;

class Program
{
    static void Main()
    {
        ErrorManager.ErrorHandler = ErrorManager.ConsoleError; // Виведення помилки у консоль
        Console.OutputEncoding = Encoding.UTF8;
        // 1
        FunctionWithPoints f = new FunctionWithPoints();
        f.AddPointToEnd(1, 2);
        f.AddPointToEnd(2, 3);
        f.AddPointToEnd(3, 5);
        f.AddPointToEnd(4, 7);

        FunctionWithPoints g = new FunctionWithPoints();
        g.AddPointToEnd(1, 1);
        g.AddPointToEnd(2, 2);
        g.AddPointToEnd(3, 3);
        g.AddPointToEnd(4, 4);

        Console.WriteLine("Функція F: \n" + f.GetInfo());
        Console.WriteLine("\nФункція G: \n" + g.GetInfo());
    }
}

