using System;

namespace readabilityTest.Algorithms
{
    internal class Smog
    {
        private readonly TextProperties _textProperties;

        private int CountReadabilityAge() => (int)Math.Round(ReadabilityScore + 6);

        private double CountReadabilityScore() =>
            1.043 * Math.Sqrt(_textProperties.PolysyllablesCount * ((double)30 / _textProperties.SentenceCount)) + 3.1291;

        public Smog(TextProperties textProperties)
        {
            _textProperties = textProperties;
            ReadabilityScore = CountReadabilityScore();
            ReadabilityAge = CountReadabilityAge();
        }

        public double ReadabilityScore { get; }
        public int ReadabilityAge { get; }
    }
}