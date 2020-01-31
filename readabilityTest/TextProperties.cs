using System.Linq;

namespace readabilityTest
{
    internal class TextProperties
    {
        private int CountWords()
        {
            string[] words = Text.Split(" ");
            return words.Length;
        }

        private int CountSentences()
        {
            const string delimiters = "?!.";
            int sentenceCount = (from char delimiter in Text
                                 where delimiters.IndexOf(delimiter) != -1
                                 select delimiter).Count();
            return (Text.EndsWith('?') || Text.EndsWith('!') || Text.EndsWith('.')) ? sentenceCount : ++sentenceCount;
        }

        private int CountCharacters() => Text.Count(character => !char.IsWhiteSpace(character));

        private int CountSyllables()
        {
            const string vowels = "aeiouy";
            string[] words = Text.Split(" ");
            int wordVowelCount = 0;
            int totalVowels = 0;
            foreach (string word in words)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (vowels.IndexOf(word[j]) == -1 || j == word.Length - 1 && word[j] != 'e') 
                        continue;
                    wordVowelCount++;
                    if (j != word.Length - 1 && vowels.IndexOf(word[j + 1]) != -1)
                        j++;
                }
                totalVowels += wordVowelCount;
                wordVowelCount = 0;
            }
            return totalVowels;
        }

        private int CountPolysyllables()
        {
            const string vowels = "aeiouy";
            string[] words = Text.Split(" ");
            int wordVowelCount = 0;
            int polysyllablesCount = 0;
            foreach (string word in words)
            {
                for (int j = 0; j < word.Length; j++)
                {
                    if (vowels.IndexOf(word[j]) == -1 || j == word.Length - 1 && word[j] != 'e') continue;
                    wordVowelCount++;
                    if (j != word.Length - 1 && vowels.IndexOf(word[j + 1]) != -1)
                        j++;
                }
                if (wordVowelCount > 2)
                    polysyllablesCount++;
                wordVowelCount = 0;
            }
            return polysyllablesCount;
        }

        public TextProperties(string text)
        {
            Text = text;
            WordCount = CountWords();
            SentenceCount = CountSentences();
            CharacterCount = CountCharacters();
            SyllablesCount = CountSyllables();
            PolysyllablesCount = CountPolysyllables();
        }

        public int WordCount { get; }

        public int SentenceCount { get; }

        public int CharacterCount { get; }

        public int SyllablesCount { get; }

        public int PolysyllablesCount { get; }

        public string Text { get; }
    }
}