using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

public class FunctionWithPointsFileManager : IFileManager<FunctionWithPoints>
{
    public void GeneratePDFReport(FunctionWithPoints F, FunctionWithPoints G, string pathToSave)
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

        string functionInfo = "Функція F(x):\n" + F.GetInfo() + "\n\nФункція G(x):\n" + G.GetInfo();
        formatter.DrawString(functionInfo, font, XBrushes.Black, rect, XStringFormats.TopLeft);
        rect.Y += 100;
        

        document.Save(pathToSave);
    }

    public void SerializeFunctionsToXML(FunctionWithPoints F, FunctionWithPoints G, string pathToSave)
    {
        List<FunctionWithPoints> functionContainer = new List<FunctionWithPoints> { F, G };

        XmlSerializer serializer = new XmlSerializer(typeof(List<FunctionWithPoints>));
        using (TextWriter writer = new StreamWriter(pathToSave))
        { serializer.Serialize(writer, functionContainer); }
    }

    public (FunctionWithPoints, FunctionWithPoints) DeserializeFunctionsFromXML(string pathToLoad)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<FunctionWithPoints>));

        using (TextReader reader = new StreamReader(pathToLoad))
        {
            List<FunctionWithPoints> funcList = (List<FunctionWithPoints>)serializer.Deserialize(reader);
            FunctionWithPoints F = funcList[0];
            FunctionWithPoints G = funcList[1];
            return (F, G);
        }
    }
}

