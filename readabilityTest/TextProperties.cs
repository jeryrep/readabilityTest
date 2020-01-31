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
            return Text.EndsWith('?') || Text.EndsWith('!') || Text.EndsWith('.') ? sentenceCount : ++sentenceCount;
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
                for (int i = 0; i < word.Length; i++)
                {
                    if (vowels.IndexOf(word[i]) == -1 || i == word.Length - 1 && word[i] != 'e') 
                        continue;
                    wordVowelCount++;
                    if (i != word.Length - 1 && vowels.IndexOf(word[i + 1]) != -1)
                        i++;
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
                for (int i = 0; i < word.Length; i++)
                {
                    if (vowels.IndexOf(word[i]) == -1 || i == word.Length - 1 && word[i] != 'e') 
                        continue;
                    wordVowelCount++;
                    if (i != word.Length - 1 && vowels.IndexOf(word[i + 1]) != -1)
                        i++;
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