using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Theme8._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XElement xePerson = new XElement($"Person");
            XAttribute xaName = new XAttribute("name", ParseForAttribute("ФИО"));

            XElement xeAdress = new XElement("Adress");

            XElement xeStreet = new XElement("Street", ParseForAttribute("названиае улицы"));
            XElement xeHouseNumber = new XElement("HouseNumber", ParseForAttribute("номер дома"));
            XElement xeFlatNumber = new XElement("FlatNumber", ParseForAttribute("номер квартиры"));
            xeAdress.Add(xeStreet); 
            xeAdress.Add(xeHouseNumber);
            xeAdress.Add(xeFlatNumber);

            XElement xePhones = new XElement("Phones");
            XElement xeMobilePhone = new XElement("MobilePhone", ParseForAttribute("номер мобильного телефона"));
            XElement xeFlatPhone = new XElement("FlatPhone", ParseForAttribute("номер домашнего телефона"));
            xePhones.Add(xeMobilePhone);
            xePhones.Add(xeFlatPhone);

            xePerson.Add(xeAdress, xaName);
            xePerson.Add(xePhones);

            xePerson.Save("Person.xml");
        }
        static string ParseForAttribute(string stringOfRequest)
        {
            Console.WriteLine($"Введите {stringOfRequest}");
            string result = Console.ReadLine();
            return result;
        }
    }
}
