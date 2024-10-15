using System;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        XDocument autoDoc = new XDocument(
            new XElement("Autos",
                new XElement("Auto",
                    new XElement("Surname", "Іванов"),
                    new XElement("CarNumber", "AA7777BB"),
                    new XElement("Brand", "BMW"),
                    new XElement("Price", 20000),
                    new XElement("Address", "Київ, вул. Хрещатик, 1")
                ),
                new XElement("Auto",
                    new XElement("Surname", "Петров"),
                    new XElement("CarNumber", "AA1234CC"),
                    new XElement("Brand", "Toyota"),
                    new XElement("Price", 15000),
                    new XElement("Address", "Львів, вул. Шевченка, 5")
                ),
                new XElement("Auto",
                    new XElement("Surname", "Сидоров"),
                    new XElement("CarNumber", "AB7070CD"),
                    new XElement("Brand", "BMW"),
                    new XElement("Price", 25000),
                    new XElement("Address", "Одеса, вул. Дерибасівська, 10")
                )
            )
        );

        autoDoc.Save("Auto.xml");

        XDocument doc = XDocument.Load("Auto.xml");

        Console.WriteLine(doc);

        var ownersWith7 = doc.Root.Elements("Auto")
            .Where(auto => auto.Element("Brand").Value == "BMW" && 
            auto.Element("CarNumber").Value.Contains('7')).Count();

        Console.WriteLine($"Кількість власників машин марки BMW, номер яких містить 7: {ownersWith7}");

        var totalCost = doc.Root.Elements("Auto")
            .Where(auto => auto.Element("Brand").Value == "BMW").Sum(auto => (int)auto.Element("Price"));

        Console.WriteLine($"Загальна вартість машин марки BMW: {totalCost}");
    }
}