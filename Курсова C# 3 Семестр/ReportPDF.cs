using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using System.Collections.Generic;
using System.Linq;

public class ReportPDF
{
    private List<Function> functions;

    public ReportPDF()
    { functions = new List<Function>(); }

    public void AddFunctions(Function F,Function G)
    { 
        functions.Add(F); 
        functions.Add(G);
    }

    private string GetFunctionInfo()
    {
        if (functions.Count >= 2)
            return "Функція F(x):\n" + functions[0] + "\n\nФункція G(x):\n" + functions[1];
        else 
            return "";
    }

    public void GenerateReport(string pathToSave)
    {
        // Создаем новый документ PDF
        PdfDocument document = new PdfDocument();

        // Добавляем страницу
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);

        // Определяем шрифт и форматирование текста
        XFont font = new XFont("Times New Roman", 14, XFontStyle.Bold);
        XTextFormatter formatter = new XTextFormatter(gfx);

        // Рисуем информацию о двух функциях на странице
        XRect rect = new XRect(40, 100, 400, 400);
        gfx.DrawRectangle(XBrushes.White, rect);


        formatter.DrawString("Звіт роботи у форматі PDF", font, XBrushes.Black, rect, XStringFormats.TopLeft);
        rect.Y += 100;

        string functionInfo = GetFunctionInfo();
        formatter.DrawString(functionInfo, font, XBrushes.Black, rect, XStringFormats.TopLeft);
        rect.Y += 100;
        

        document.Save(pathToSave);
    }

}

