using System;

namespace readabilityTest.Algorithms
{
    internal class Fkr : IAlgorithm
    {
        private readonly TextProperties _textProperties;

        private int CountReadabilityAge() => (int)Math.Round(ReadabilityScore + 6);

        private double CountReadabilityScore() =>
            0.39 * ((double)_textProperties.WordCount / _textProperties.SentenceCount) +
            11.8 * ((double)_textProperties.SyllablesCount / _textProperties.WordCount) - 15.59;

        public Fkr(TextProperties textProperties)
        {
            _textProperties = textProperties;
            ReadabilityScore = CountReadabilityScore();
            ReadabilityAge = CountReadabilityAge();
        }

        public double ReadabilityScore { get; }
        public int ReadabilityAge { get; }
    }
}