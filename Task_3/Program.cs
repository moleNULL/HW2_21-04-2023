/*
                                                   Задача #3:

    Дан массив, в котором хранится информация о количестве страниц в каждой из 100 книг. 
    Все страницы имеют одинаковую толщину. Определить количество страниц в самой толстой книге.

*/


namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintInitialMessage();

            const int booksNumber = 100;
            var rand = new Random();

            int minBookPagesPossible, maxBookPagesPossible;
            bool needExit;

            while (true)
            {
                GetMinMaxPagesFromInput(out minBookPagesPossible, out maxBookPagesPossible, out needExit);

                if (needExit)
                {
                    break;
                }

                var booksPages = Enumerable.Repeat(0, booksNumber)
                                           .Select(_ => rand.Next(minBookPagesPossible, maxBookPagesPossible));

                int thickestBookPages = booksPages.Max();

                Console.WriteLine($"\tThe thickest book contains {thickestBookPages} pages\n");
            }

            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }
        private static void PrintInitialMessage()
        {
            string titleText = "[Task_3] Find pages of the thickest book among 100 books:";

            Console.Title = titleText[..^1];
            Console.CursorLeft = (Console.BufferWidth / 2) - (titleText.Length / 2);
            Console.WriteLine(titleText);
        }

        private static void GetMinMaxPagesFromInput(
            out int minBookPagesPossible, out int maxBookPagesPossible, out bool needExit)
        {
            minBookPagesPossible = 1;
            maxBookPagesPossible = 1;
            needExit = false;

            while (true)
            {
                Console.Write("\nEnter book minimum pages possible for randomizing (\"exit\" to exit the loop): ");              
                string? minPagesInput = GetInput();

                if (minPagesInput is null)
                {
                    needExit = true;
                    return;
                }

                if (!TryParsePageInput(minPagesInput, out minBookPagesPossible))
                {
                    Console.WriteLine("Wrong page number for minimum pages");
                    continue;
                }

                Console.Write("Enter book maximum pages possible for randomizing (\"exit\" to exit the loop): ");             
                string? maxPagesInput = GetInput();

                if (maxPagesInput is null)
                {
                    needExit = true;
                    return;
                }

                if (!TryParsePageInput(maxPagesInput, out maxBookPagesPossible))
                {
                    Console.WriteLine("Wrong page number for maximum pages");
                    continue;
                }

                if (maxBookPagesPossible < minBookPagesPossible)
                {
                    Console.WriteLine("Maximum pages should be greater than or equal to minimum pages");
                    continue;
                }

                break;
            }
        }

        private static string? GetInput()
        {
            string? input = Console.ReadLine();
            return input?.ToLower() == "exit" ? null : input;
        }

        private static bool TryParsePageInput(string input, out int pages)
        {
            return int.TryParse(input, out pages) && pages > 0; 
        }
    }
}