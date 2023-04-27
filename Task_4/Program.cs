/*
                                                   Задача #4:

    В массиве хранится информация о максимальной скорости каждой из 40 марок легковых автомобилей.
    Определить порядковый номер самого быстрого автомобиля.
    Если таких автомобилей несколько, то должен быть найден номер:
        а) первого из них;
        б) последнего из них.

*/

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintInitialMessage();

            const int carsNumber = 40;
            var rand = new Random();

            int minSpeedPossible, maxSpeedPossible;
            bool needExit;

            while (true)
            {
                GetMinMaxSpeedFromInput(out minSpeedPossible, out maxSpeedPossible, out needExit);

                if (needExit)
                {
                    break;
                }

                var carsSpeed = Enumerable.Repeat(0, carsNumber)
                      .Select(_ => rand.Next(minSpeedPossible, maxSpeedPossible))
                      .ToArray();

                int fastestSpeed = carsSpeed.Max();
                int minOrdinalNumber = Array.IndexOf(carsSpeed, fastestSpeed) + 1;
                int maxOrdinalNumber = Array.LastIndexOf(carsSpeed, fastestSpeed) + 1;

                PrintSpeedOrdinalNumberInfo(minOrdinalNumber, maxOrdinalNumber);
            }

            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private static void PrintInitialMessage()
        {
            string titleText = "[Task_4] Find an ordinal number of the fastest car among 40 cars:";

            Console.Title = titleText[..^1];
            Console.CursorLeft = (Console.BufferWidth / 2) - (titleText.Length / 2);
            Console.WriteLine(titleText);
        }

        private static void GetMinMaxSpeedFromInput(
            out int minSpeedPossible, out int maxSpeedPossible, out bool needExit)
        {
            minSpeedPossible = 1;
            maxSpeedPossible = 1;
            needExit = false;

            while (true)
            {
                Console.Write("\nEnter minimum car speed possible for randomizing (\"exit\" to exit the loop): ");
                string? minSpeedInput = GetInput();

                if (minSpeedInput is null)
                {
                    needExit = true;
                    return;
                }

                if (!TryParsePageInput(minSpeedInput, out minSpeedPossible))
                {
                    Console.WriteLine("Wrong speed for minimum speed");
                    continue;
                }

                Console.Write("Enter maximum car speed possible for randomizing (\"exit\" to exit the loop): ");
                string? maxSpeedInput = GetInput();

                if (maxSpeedInput is null)
                {
                    needExit = true;
                    return;
                }

                if (!TryParsePageInput(maxSpeedInput, out maxSpeedPossible))
                {
                    Console.WriteLine("Wrong speed for maximum speed");
                    continue;
                }

                if (maxSpeedPossible < minSpeedPossible)
                {
                    Console.WriteLine("Maximum speed should be greater than or equal to minimum");
                    continue;
                }

                break;
            }
        }

        private static void PrintSpeedOrdinalNumberInfo(int minOrdinalNumber, int maxOrdinalNumber)
        {
            if (minOrdinalNumber == maxOrdinalNumber)
            {
                Console.WriteLine($"\n\tThe ordinal number of the faster car is {minOrdinalNumber}");
            }
            else
            {
                Console.WriteLine($"\n\tThe minimum ordinal number of the faster car is {minOrdinalNumber}");
                Console.WriteLine($"\tThe maximum ordinal number of the faster car is {maxOrdinalNumber}");
            }
        }

        private static bool TryParsePageInput(string input, out int speed)
        {
            return int.TryParse(input, out speed) && speed > 0;
        }

        private static string? GetInput()
        {
            string? input = Console.ReadLine();
            return input?.ToLower() == "exit" ? null : input;
        }
    }
}