/*
                                                   Задача #2:

    Дан текст, в начале которого имеются пробелы и в котором имеются цифры. 
    Найти порядковый номер максимальной цифры, начиная счет с первого символа, не являющегося пробелом. 
    Если максимальных цифр несколько, то должен быть найден номер первой из них.

*/


namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintInitialMessage();

            while (true)
            {
                Console.Write("\nEnter text (\"exit\" to exit the loop): ");
                string? text = Console.ReadLine();

                if (text?.ToLower() == "exit")
                {
                    break;
                }

                int? ordinalNumberOfMaxDigit = GetOrdinalNumberOfMaxDigit(text);

                PrintDigitInfo(ordinalNumberOfMaxDigit);
            }

            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private static void PrintDigitInfo(int? ordinalNumberOfMaxDigit)
        {
            if (ordinalNumberOfMaxDigit.HasValue)
            {
                Console.WriteLine($"\n\tOrdinal number of the max digit: {ordinalNumberOfMaxDigit.Value}");
            }
            else
            {
                Console.WriteLine("\n\tThere are no digits in the provided text");
            }
        }

        private static int? GetOrdinalNumberOfMaxDigit(string? text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }

            int countWhitespaces = text.TakeWhile(char.IsWhiteSpace).Count();

            IEnumerable<char> charDigits = text.Where(char.IsDigit);

            if (charDigits.Any())
            {
                char maxDigitChar = charDigits.Max();
                int indexWithoutWhitespaces = text.IndexOf(maxDigitChar) - countWhitespaces;

                return indexWithoutWhitespaces + 1;
            }

            return null;
        }

        private static void PrintInitialMessage()
        {
            string titleText = "[Task_2] Find ordinal number of the max digit in the given text:";

            Console.Title = titleText[..^1];
            Console.CursorLeft = (Console.BufferWidth / 2) - (titleText.Length / 2);
            Console.WriteLine(titleText);
        }
    }
}