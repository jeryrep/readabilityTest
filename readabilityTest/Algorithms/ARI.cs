namespace readabilityTest.Algorithms
{
    internal class Ari
    {
        private readonly TextProperties _textProperties;

        private int CountReadabilityAge()
        {
            if (ReadabilityScore < 3)
            {
                return (int)ReadabilityScore + 5;
            }
            else if (ReadabilityScore >= 3 && ReadabilityScore <= 12)
            {
                return (int)ReadabilityScore + 6;
            }
            return 24;
        }

        private double CountReadabilityScore() =>
            4.71 * ((double)_textProperties.CharacterCount / _textProperties.WordCount) +
            0.5 * ((double)_textProperties.WordCount / _textProperties.SentenceCount) - 21.43;

        public Ari(TextProperties textProperties)
        {
            _textProperties = textProperties;
            ReadabilityScore = CountReadabilityScore();
            ReadabilityAge = CountReadabilityAge();
        }

        public double ReadabilityScore { get; }
        public int ReadabilityAge { get; }
    }
}