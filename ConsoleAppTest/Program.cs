using System;
using System.Text;

class Program
{
    static void Main()
    {   
        Console.OutputEncoding = Encoding.UTF8;

        Function f = new Function();
        f.AddPointToEnd(1, 2);
        f.AddPointToEnd(2, 3);
        f.AddPointToEnd(3, 5);
        f.AddPointToEnd(4, 7);

        Function g = new Function();
        g.AddPointToEnd(1, 1);
        g.AddPointToEnd(2, 2);
        g.AddPointToEnd(3, 3);
        g.AddPointToEnd(4, 4);

        Console.WriteLine("Функція F: \n" + f.ToString());
        Console.WriteLine("\nФункція G: \n" + g.ToString());

        MathOperationsWithFunc calc = new MathOperationsWithFunc();
        Console.WriteLine("Максимальне значення F(X) - G(X) = " +
            calc.FindMaximum(1, 4, f, g, 0.1));

        Console.WriteLine("--------------------------------------\nСеріалізація у файл test.xml");
        XML.SerializeFunctionsToXML(f, g, "..\\..\\..\\TestFiles\\test.xml");
        
        f.ClearList();
        g.ClearList();
        Console.WriteLine("\nФункції f та g очищенні від значень");

        Console.WriteLine("--------------------------------------\nДесеріалізація з файлу test.xml");
        (f, g) = XML.DeserializeFunctionsFromXML("..\\..\\..\\TestFiles\\test.xml");
       
        Console.WriteLine("\nФункція F: \n" + f.ToString());
        Console.WriteLine("\nФункція G: \n" + g.ToString());

        Console.WriteLine("Генерація звіту");
        ReportPDF reportPDF = new ReportPDF();
        reportPDF.AddFunctions(f,g);

        reportPDF.GenerateReport("..\\..\\..\\TestFiles\\testPDF.pdf");
        
    }
}

