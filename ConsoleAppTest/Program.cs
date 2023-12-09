using System;
using System.Text;

class Program
{
    static void Main()
    {
        ErrorManager.ErrorHandler = ErrorManager.ConsoleError; // Виведення помилки у консоль
        Console.OutputEncoding = Encoding.UTF8;

        FunctionWithPoints f = new FunctionWithPoints();
        FunctionWithPoints g = new FunctionWithPoints();

        FunctionWithPointsFileManager fFileManager = new FunctionWithPointsFileManager();
        FunctionWithPointsCalculator fCalculator = new FunctionWithPointsCalculator();

        Console.WriteLine("------------------------Тест1: Ідеальний випадок 1 (Унімодальна функція)-----------------------------\n");
        (f,g) = fFileManager.DeserializeFunctionsFromXML("..\\..\\..\\TestFiles\\IdealCase1.xml");

        Console.WriteLine("Fx:\n" + f.GetInfo());
        Console.WriteLine("\nGx:\n" + g.GetInfo());
        Console.WriteLine("Максимум функції F(x) - G(x): " + fCalculator.FindMaximum(0, 4, f, g, 0.001));

        Console.WriteLine("\n------------------------Тест2: Ідеальний випадок 2 (Унімодальна функція)-----------------------------\n");
        (f, g) = fFileManager.DeserializeFunctionsFromXML("..\\..\\..\\TestFiles\\IdealCase2.xml");

        Console.WriteLine("Fx:\n" + f.GetInfo());
        Console.WriteLine("\nGx:\n" + g.GetInfo());
        Console.WriteLine("Максимум функції F(x) - G(x): " + fCalculator.FindMaximum(0, 4, f, g, 0.001));

        Console.WriteLine("Генерація звіту для тесту 2...");
        fFileManager.GeneratePDFReport(f, g, 0, 4, 0.001, "..\\..\\..\\TestFiles\\CosnoleAppReportForTest2.pdf");
        Console.WriteLine("Звіт згенеровано успішно.");



        Console.WriteLine("\n------------------------Тест3: Не унімодальна функція-----------------------------\n");
        (f, g) = fFileManager.DeserializeFunctionsFromXML("..\\..\\..\\TestFiles\\NotUnimodal.xml");

        Console.WriteLine("Fx:\n" + f.GetInfo());
        Console.WriteLine("\nGx:\n" + g.GetInfo());
        Console.WriteLine("Максимум функції F(x) - G(x): " + fCalculator.FindMaximum(0, 4, f, g, 0.001));

        Console.WriteLine("\n------------------------Тест4: Недостатня кількість точок у функції-----------------------------\n\n");
        (f, g) = fFileManager.DeserializeFunctionsFromXML("..\\..\\..\\TestFiles\\NotEnoughPoints.xml");

        Console.WriteLine("Fx:\n" + f.GetInfo());
        Console.WriteLine("\nGx:\n" + g.GetInfo());
        Console.WriteLine("Максимум функції F(x) - G(x): " + fCalculator.FindMaximum(0, 4, f, g, 0.001));


    }
}

