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

            Console.Write("Enter text: ");
            string? text = Console.ReadLine();

            var digitAnalyzer = new DigitAnalyzer(text);

            PrintDigitsInfo(digitAnalyzer);

            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }

        private static void PrintInitialMessage()
        {
            string titleText = "Task_1:";

            Console.Title = titleText[..^1];
            Console.CursorLeft = (Console.BufferWidth / 2) - (titleText.Length / 2);
            Console.WriteLine(titleText);
        }

        private static void PrintDigitsInfo(DigitAnalyzer digitAnalyzer)
        {
            if (digitAnalyzer.HasAnyDigits)
            {
                Console.WriteLine($"\nSum of digits: {digitAnalyzer.Sum}");
                Console.WriteLine($"Max digit: {digitAnalyzer.MaxDigit}");
            }
            else
            {
                Console.WriteLine("\nThere are no digits in the provided text");
            }
        }
    }

    internal class DigitAnalyzer
    {
        private string? _text;

        public DigitAnalyzer() { }

        public DigitAnalyzer(string? text)
        {
            Text = text;
        }

        public string? Text
        {
            get => _text;
            set
            {
                _text = value;
                CalculateDigitsSumAndMaxValue();
            }
        }
        public int? MaxDigit { get; private set; }
        public int? Sum { get; private set; }
        public bool HasAnyDigits => Sum is not null;

        private void CalculateDigitsSumAndMaxValue()
        {
            Sum = null;
            MaxDigit = null;

            if (_text is not null)
            {
                IEnumerable<char> digits = _text.Where(char.IsDigit);

                if (digits.Any())
                {
                    Sum = digits.Sum(ch => (int)char.GetNumericValue(ch));
                    MaxDigit = digits.Max(ch => (int)char.GetNumericValue(ch));
                }
            }
        }

    }
}