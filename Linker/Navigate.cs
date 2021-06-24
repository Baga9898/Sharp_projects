using System;

namespace LinksApp
{
    public class Navigate
    {
        public static void MainMenu()
        {
            while (true)
            {
                InOut.Print("Главное меню\n----------\nВыберите операцию:\n1. Добавить ссылку\n2. Удалить ссылку\n3. Вывести список ссылок.\n----------\nНажмите Q для выхода");

                var chooseMenuItem = Console.ReadLine();

                switch (chooseMenuItem)
                {
                    case "1":
                        ManipulateWithLinks.AddNewLink();
                        break;

                    case "2":
                        InOut.Print("Введите имя ссылки, которую хотите подвергнуть удалению: ");

                        var nameOfLink = Console.ReadLine();

                        ManipulateWithLinks.DeleteElementByName($"{nameOfLink}");
                        break;
                    
                    case "3":
                        ManipulateWithLinks.DisplayAllLinks();
                        break;

                    case "Q":
                    case "q":
                        break;

                    default:
                        InOut.Print("Выбранный вами пункт отсутствует.");
                        continue;
                }

                break;
            }
        }
    }
}