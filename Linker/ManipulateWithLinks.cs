using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LinksApp
{
    public class ManipulateWithLinks
    {
        private const string Path = "Links.xml";

        // Добавление новой ссылки.
        public static void AddNewLink()
        {
            var xDoc = new XmlDocument();
            xDoc.Load(Path);
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
            xDoc.Save(Path);

            InOut.Print($"Ссылка {nameInput} успешно добавлена.");
            
            EndOfMethod();
            
            Navigate.MainMenu();
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
            xdoc.Save(Path);
        }
        
        // Удаление первого элемента. (Для элемента, созданного по умолчанию).
        public static void DeleteDefaultElement(string varForPath)
        {
            // Удаляем элемент, созданный по умолчанию.
            var xDoc = new XmlDocument();
            xDoc.Load(Path);
            var xRoot = xDoc.DocumentElement;

            if (xRoot != null)
            {
                var firstNode = xRoot.FirstChild;
                xRoot.RemoveChild(firstNode ?? throw new InvalidOperationException());
            }

            xDoc.Save(Path);
        }
        
        // Удаление ссылки по имени.
        public static void DeleteElementByName(string nameOfLink)
        {
            var xDoc = new XmlDocument();
            xDoc.Load(Path);
            var xRoot = xDoc.DocumentElement;

            if (xRoot != null)
            {
                var deleteNode = xRoot.SelectSingleNode($"link[name = \"{nameOfLink}\"]");
            
                if (deleteNode != null)
                {
                    xRoot.RemoveChild(deleteNode);
                    xDoc.Save(Path);
            
                    InOut.Print("Удаление элемента прошло успешно.");
                }
                else
                {
                    InOut.Print("Введено некорректное имя ссылки.");
                }
            }

            EndOfMethod();
            
            Navigate.MainMenu();
        }
        
        // Проверка наличия файла.
        public static void FileExistence()
        {
            if (!(File.Exists(Path)))
            {
                FileCreate(Path);
                DeleteDefaultElement(Path);
            }
        }
        
        // Вывод списка всех ссылок.
        public static void DisplayAllLinks()
        {
            var weblinks = new List<Weblinks>();
 
            var xDoc = new XmlDocument();
            xDoc.Load(Path);
            var xRoot = xDoc.DocumentElement;

            if (xRoot != null)
                foreach (XmlElement xnode in xRoot)
                {
                    var link = new Weblinks();
                    var attr = xnode.Attributes.GetNamedItem("url");
                    if (attr != null)
                        link.Url = attr.Value;

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "name")
                            link.Name = childnode.InnerText;

                        if (childnode.Name == "description")
                            link.Description = childnode.InnerText;
                    }

                    weblinks.Add(link);
                }

            foreach (var l in weblinks)
            {
                Console.WriteLine($"{l.Name}");
            }
            
            EndOfMethod();
            
            Navigate.MainMenu();
        }
        
        // Завершение метода.
        public static void EndOfMethod()
        {
            InOut.Print("Нажмите \"Enter\" чтобы продолжить.");

            var programRepeat = Console.ReadLine();

            switch (programRepeat)
            {
                default:
                    InOut.Print("");
                    break;
            }
        }
        
        // Редактирование ссылок.
        public static void ChangeLink(string linkNameForChange, string changeOptionForChange)
        {
            var xdoc = XDocument.Load(Path);
            var root = xdoc.Element("links");

            if (root != null)
                foreach (var xe in root.Elements("link").ToList())
                {
                    switch (changeOptionForChange)
                    {
                        case "1":
                            // Изменение имяни.
                            if (xe.Element("name")?.Value == linkNameForChange)
                            {
                                InOut.Print("Введите новое имя: ");
                                var temp = Console.ReadLine();

                                xe.Element("name").Value = temp;
                            }

                            break;

                        case "2":
                            // Изменение адреса.
                            if (xe.Element("name")?.Value == linkNameForChange)
                            {
                                InOut.Print("Введите новый адрес: ");
                                var temp = Console.ReadLine();

                                xe.Attribute("url").Value = temp;
                            }

                            break;

                        case "3":
                            // Изменение описания.
                            if (xe.Element("name")?.Value == linkNameForChange)
                            {
                                InOut.Print("Введите новое описание: ");
                                var temp = Console.ReadLine();

                                xe.Element("description").Value = temp;
                            }

                            break;
                    }
                }

            xdoc.Save(Path);
            
            EndOfMethod();
            
            Navigate.MainMenu();
        }
    }
}