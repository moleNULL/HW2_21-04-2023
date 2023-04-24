/*
                                                   Задача #1:

    Дан текст, в котором присутствуют цифры. Требуется:
        а) Найти их сумму.
        б) Определить максимальную цифру.

 */

namespace Task_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintInitialMessage();

            var digitAnalyzer = new DigitAnalyzer();

            while (true)
            {
                Console.Write("\nEnter text (\"exit\" to exit the loop): ");
                string? text = Console.ReadLine();

                if (text?.ToLower() == "exit")
                {
                    break;
                }

                digitAnalyzer.Text = text;

                PrintDigitsInfo(digitAnalyzer);
            }

            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private static void PrintInitialMessage()
        {
            string titleText = "[Task_1] Count digit sum and max digit in the given text:";

            Console.Title = titleText[..^1];
            Console.CursorLeft = (Console.BufferWidth / 2) - (titleText.Length / 2);
            Console.WriteLine(titleText);
        }

        private static void PrintDigitsInfo(DigitAnalyzer digitAnalyzer)
        {
            if (digitAnalyzer.HasAnyDigits)
            {
                Console.WriteLine($"\n\tSum of digits: {digitAnalyzer.Sum}");
                Console.WriteLine($"\tMax digit: {digitAnalyzer.MaxDigit}");
            }
            else
            {
                Console.WriteLine("\n\tThere are no digits in the provided text");
            }
        }
    }
}