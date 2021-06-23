using System;

namespace LinksApp
{
    public class Navigate
    {
        public static void MainMenu()
        {
            while (true)
            {
                InOut.Print("----------\nГлавное меню\n----------\nВыберите операцию:\n1. Добавить ссылку\n2. Удалить ссылку\n----------\nНажмите Q для выхода");

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

                    case "Q" or "q":
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