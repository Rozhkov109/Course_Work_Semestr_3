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
       (f,g) = fFileManager.DeserializeFunctionsFromXML("..\\..\\..\\TestFiles\\AllUnimodal_AllDecreasing.xml");

        Console.WriteLine("Fx:" + f.GetInfo());
        Console.WriteLine("\n\nGx:" + g.GetInfo());

        FunctionWithPointsCalculator fCalculator = new FunctionWithPointsCalculator();
        Console.WriteLine(fCalculator.FindMaximum(0, 4, f, g, 0.01));
        FunctionWithPointsFileManager functionWithPointsFileManager = new FunctionWithPointsFileManager();
       functionWithPointsFileManager.GeneratePDFReport(f, g, 0, 4, 0.01, "..\\..\\..\\TestFiles\\testapp.pdf");


    }
}

