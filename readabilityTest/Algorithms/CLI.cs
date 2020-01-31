using System;

namespace readabilityTest.Algorithms
{
    internal class Cli
    {
        private readonly TextProperties _textProperties;

        private int CountReadabilityAge() => (int)Math.Round(ReadabilityScore + 5);

        private double CountReadabilityScore()
        {
            int letterCount = 0;
            int spaceCount = 0;
            int sentenceCount = 0;
            int length = _textProperties.Text.Length;
            for (int i = 0; i < length; i++)
            {
                char c = _textProperties.Text[i];
                if (char.IsLetterOrDigit(c))
                {
                    letterCount++;
                }
                else if (c == ' ')
                {
                    spaceCount++;
                }
                else if (c == '.')
                {
                    if (i != length - 1 && _textProperties.Text[i+1] == ' ')
                    {
                        sentenceCount++;
                    }
                }

            }
            int wordCount = spaceCount + 1;

            double l = (double)letterCount / wordCount * 100;
            double s = (double)sentenceCount / wordCount * 100;

            return 0.0588 * l - 0.296 * s - 15.8;
        }

        public Cli(TextProperties textProperties)
        {
            _textProperties = textProperties;
            ReadabilityScore = CountReadabilityScore();
            ReadabilityAge = CountReadabilityAge();
        }

        public double ReadabilityScore { get; }
        public int ReadabilityAge { get; }
    }
}