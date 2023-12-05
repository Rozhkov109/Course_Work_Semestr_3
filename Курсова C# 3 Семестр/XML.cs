using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public static class XML
{
    public static void SerializeFunctionsToXML(Function F, Function G, string pathToSave)
    {    
        List<Function> functionContainer = new List<Function> { F, G };

        XmlSerializer serializer = new XmlSerializer(typeof(List<Function>));
        using (TextWriter writer = new StreamWriter(pathToSave)) 
        { serializer.Serialize(writer, functionContainer); }
    }

    public static (Function, Function) DeserializeFunctionsFromXML(string pathToLoad)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Function>));

        using (TextReader reader = new StreamReader(pathToLoad))
        {
            List<Function> funcList = (List<Function>)serializer.Deserialize(reader);
            Function F = funcList[0];
            Function G = funcList[1];
            return (F,G);
        }
    }

}

