using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace LinksApp
{
    public class ManipulateWithLinks
    {
        private static string path = "C:/Links.xml";

        // Добавление новой ссылки.
        public static void AddNewLink()
        {
            var xDoc = new XmlDocument();
            xDoc.Load(path);
            var xRoot = xDoc.DocumentElement;
                        
            // Создаём новый элемент Link:
            var linkElement = xDoc.CreateElement("link");
                        
            // Создаём атрибут url - (адрес ссылки):
            var urlAttr = xDoc.CreateAttribute("url");
                        
            // Создаём элементы "имя ссылки" и "описание ссылки":
            var nameElem = xDoc.CreateElement("name");
            var descriptionElem = xDoc.CreateElement("description");
                        
            // Создаём текстовые значения для элементов и атрибута:
            InOut.Print("Введите адрес ссылки: ");
            var urlInput = Console.ReadLine();
            var urlText = xDoc.CreateTextNode($"{urlInput}");
            
            InOut.Print("Введите имя ресурса: ");
            var nameInput = Console.ReadLine();
            var nameText = xDoc.CreateTextNode($"{nameInput}");
            
            InOut.Print("Добавьте описание: ");
            var descriptionInput = Console.ReadLine();
            var descriptionText = xDoc.CreateTextNode($"{descriptionInput}");
             
            // Добавляем узлы:
            urlAttr.AppendChild(urlText);
            nameElem.AppendChild(nameText);
            descriptionElem.AppendChild(descriptionText);
            linkElement.Attributes.Append(urlAttr);
            linkElement.AppendChild(nameElem);
            linkElement.AppendChild(descriptionElem);
            xRoot?.AppendChild(linkElement); //Проверяем, введена ли ссылка.
            xDoc.Save(path);
        }
        
        // Создание файла.
        public static void FileCreate(string varForPath)
        {
            var xdoc = new XDocument();
            
            // Создаём первый элемент:
            var firstLink = new XElement("link");
            
            // Создаём атрибут:
            var urlAttr = new XAttribute("url", "www.default.com");
            var nameElem = new XElement("name", "Link name");
            var descriptionElem = new XElement("description", "Description for link.");
            
            // Добавляем атрибут и элементы в первый элемент:
            firstLink.Add(urlAttr);
            firstLink.Add(nameElem);
            firstLink.Add(descriptionElem);
                        
            // Создаём корневой элемент:
            var links = new XElement("links");
            
            // Добавляем в корневой элемент:
            links.Add(firstLink);
            
            // Добавляем корневой элемент в документ:
            xdoc.Add(links);
            
            // Сохраняем документ:
            xdoc.Save(path);
        }
        
        // Удаление первого элемента. (Для элемента, созданного по умолчанию).
        public static void DeleteDefaultElement(string varForPath)
        {
            // Удаляем элемент, созданный по умолчанию.
            var xDoc = new XmlDocument();
            xDoc.Load(path);
            var xRoot = xDoc.DocumentElement;
            
            var firstNode = xRoot.FirstChild;
            xRoot.RemoveChild(firstNode);
            xDoc.Save(path);
        }
        
        // Удаление ссылки по имени.
        public static void DeleteElementByName(string nameOfLink)
        {
            var xDoc = new XmlDocument();
            xDoc.Load(path);
            var xRoot = xDoc.DocumentElement;
            
            var deleteNode = xRoot.SelectSingleNode($"link[name = \"{nameOfLink}\"]");
            xRoot.RemoveChild(deleteNode);
            xDoc.Save(path);
            
            InOut.Print("Удаление элемента прошло успешно.");
        }
        
        // Проверка наличия файла.
        public static void FileExistence()
        {
            if (!(File.Exists(path)))
            {
                FileCreate(path);
                DeleteDefaultElement(path);
            }
        }
    }
}