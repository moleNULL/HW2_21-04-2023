namespace Task_1
{
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
        public bool HasAnyDigits => MaxDigit.HasValue && Sum.HasValue;

        private void CalculateDigitsSumAndMaxValue()
        {
            Sum = null;
            MaxDigit = null;

            if (_text is not null)
            {
                IEnumerable<char> charDigits = _text.Where(char.IsDigit);

                if (charDigits.Any())
                {
                    Sum = charDigits.Sum(ch => (int)char.GetNumericValue(ch));
                    MaxDigit = charDigits.Max(ch => (int)char.GetNumericValue(ch));
                }
            }
        }

    }
}
