using System;

class Program
{
    static void Main()
    {
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

       MathOperationsWithFunc calc = new MathOperationsWithFunc();
       Console.WriteLine(calc.FindMaximumWithDichtomy(1, 4, f.GetPointsList(), g.GetPointsList(), 0.1));

        Console.WriteLine(f.ToString());

    }
}

