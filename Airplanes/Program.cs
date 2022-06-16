using System;

namespace Airplanes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Список самолетов";

            Console.WriteLine(":::: Добро пожаловать в программу для учета самлолетов! ::::");
            Console.ResetColor();
            try
            {
                View.SConsole sConsole = new View.SConsole("content.bin");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("программа закончила свою работу, до скорых встреч)");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
