using System;

namespace Airplanes.View
{
    internal class SConsole
    {
        private Conntroller.RController records;

        public SConsole(string way)
        {
            try
            {
                records = new Conntroller.RController(way);
                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Start()
        {
            PrintM();
            while (true)
            {
                try
                {
                    switch (GetConsole("Введите нужную вам команду...").ToLower())
                    {
                        case "commands": PrintM(); break;
                        case "list": GetSomeContent(); break;
                        case "add": AddSomeContent(); break;
                        case "delete": DelSOmeContent(); break;
                        case "exit": return;
                        default:
                            Console.WriteLine("неверная команда"); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private void AddSomeContent()
        {
            string name = GetConsole("Введите название самолета");
            string type = GetConsole("Введите тип самолета(пассажирский, военный и т.д.)");
            string doc = GetConsole("Введите год создания самолета");
            string maxheight = GetConsole("Введите максимальную высоту(в км.)");
            string color = GetConsole("Введите Цвет раскарски");
            records.Add(name, type, doc, maxheight, color);
            Console.WriteLine("самолет добавлен");
            GetSomeContent();
        }
        private void GetSomeContent()
        {
            if (records.Airplanes.Count == 0)
            {
                Console.WriteLine("нет добавленных самолетов");
                return;
            }

            foreach (var item in records.Airplanes)
            {
                Console.WriteLine(item);
            }
        }

        private void DelSOmeContent()
        {

        }

        private void PrintM()
        {
            Console.WriteLine("commands - список команд");
            Console.WriteLine("exit - Выход");
            Console.WriteLine("list - просмотреть список самолетов");
            Console.WriteLine("add - добавить новый самолет");
        }
        private string GetConsole(string v)
        {
            Console.WriteLine(v);
            var s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s))
            {
                Console.WriteLine("некорректный ввод");
                return GetConsole(v);
            }
            return s.TrimStart().TrimEnd();
        }
    }
}
