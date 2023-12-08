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

        FunctionWithPointsFileManager fileManager = new FunctionWithPointsFileManager();
        fileManager.SerializeFunctionsToXML(f, g, "..\\..\\..\\TestFiles\\AllUnimodal_AllIncreasing.xml");
        
        f.ClearList();
        g.ClearList();
        // 2
        f.AddPointToEnd(1, -3.2);
        f.AddPointToEnd(2, -7);
        f.AddPointToEnd(3, -10);
        f.AddPointToEnd(4, -12.5);
        f.AddPointToEnd(5, -13);
        f.AddPointToEnd(6, -15.2);
        f.AddPointToEnd(7, -16);

        g.AddPointToEnd(1, 4);
        g.AddPointToEnd(2, -2.58);
        g.AddPointToEnd(3, -4);
        g.AddPointToEnd(4, -6.3);
        g.AddPointToEnd(5, -8);
        g.AddPointToEnd(6, -10.25);
        g.AddPointToEnd(7, -12);

        fileManager.SerializeFunctionsToXML(f, g, "..\\..\\..\\TestFiles\\AllUnimodal_AllDecreasing.xml");

        f.ClearList();
        g.ClearList();
        // 3
        f.AddPointToEnd(1, 5);
        f.AddPointToEnd(2, 5);
        f.AddPointToEnd(3, 5);
        f.AddPointToEnd(4, 5);
        f.AddPointToEnd(5, 8);
        f.AddPointToEnd(6, 12.1);

        g.AddPointToEnd(1, 2);
        g.AddPointToEnd(2, 2);
        g.AddPointToEnd(3, 2);
        g.AddPointToEnd(4, 6);
        g.AddPointToEnd(3, 7.3);
        g.AddPointToEnd(4, 10);

        fileManager.SerializeFunctionsToXML(f, g, "..\\..\\..\\TestFiles\\AllUnimodal_FirstEqualThanIncreasing.xml");
        f.ClearList();
        g.ClearList();

        // 4
        f.AddPointToEnd(1, -7);
        f.AddPointToEnd(2, 14);
        f.AddPointToEnd(3, 2);
        f.AddPointToEnd(4, -15);
        f.AddPointToEnd(5, 3);
        f.AddPointToEnd(6, 7);

        g.AddPointToEnd(1, 2);
        g.AddPointToEnd(2, 3);
        g.AddPointToEnd(3, 4);
        g.AddPointToEnd(4, 10);
        g.AddPointToEnd(3, 12);
        g.AddPointToEnd(4, 15);

        fileManager.SerializeFunctionsToXML(f, g, "..\\..\\..\\TestFiles\\FirstNotUnimodal_SecondUnimodal.xml");
        f.ClearList();
        g.ClearList();

        // 5
        f.AddPointToEnd(1, -7);
        f.AddPointToEnd(2, 14);
        f.AddPointToEnd(3, 2);
        f.AddPointToEnd(4, -15);
        f.AddPointToEnd(5, 3);

        g.AddPointToEnd(1, 20);
        g.AddPointToEnd(2, 4.3);
        g.AddPointToEnd(3, 14);
        g.AddPointToEnd(4, 15);
        g.AddPointToEnd(3, -2.5);

        fileManager.SerializeFunctionsToXML(f, g, "..\\..\\..\\TestFiles\\TwoFuncsAreNotUnimodal.xml");
        f.ClearList();
        g.ClearList();

        // 5
        f.AddPointToEnd(1, 20);

        g.AddPointToEnd(1, 6);


        fileManager.SerializeFunctionsToXML(f, g, "..\\..\\..\\TestFiles\\TwoFuncsHaveOnlyOnePoint.xml");
        f.ClearList();
        g.ClearList();

    }
}

