using readabilityTest.Algorithms;
using System;
using System.Windows;

namespace readabilityTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FillBoxes()
        {
            var textProperties = new TextProperties(Text.Text);
            var ari = new Ari(textProperties);
            var fkr = new Fkr(textProperties);
            var smog = new Smog(textProperties);
            var cli = new Cli(textProperties);
            Words.Text = $"Words: {textProperties.WordCount}";
            Sentences.Text = $"Sentences: {textProperties.SentenceCount}";
            Characters.Text = $"Characters: {textProperties.CharacterCount}";
            Syllables.Text = $"Syllables: {textProperties.SyllablesCount}";
            Polysyllables.Text = $"Polysyllables: {textProperties.PolysyllablesCount}";
            Ari.Text =
                $"Automated Readability Index: {Math.Round(ari.ReadabilityScore, 2)} (about {ari.ReadabilityAge} year old). ";
            Fkr.Text =
                $"Flesch-Kincaid readability tests: {Math.Round(fkr.ReadabilityScore, 2)} (about {fkr.ReadabilityAge} year old). ";
            Smog.Text =
                $"Simple Measure of Gobbledygook: {Math.Round(smog.ReadabilityScore, 2)} (about {smog.ReadabilityAge} year old). ";
            Cli.Text =
                $"Coleman-Liau index: {Math.Round(cli.ReadabilityScore, 2)} (about {cli.ReadabilityAge} year old). ";
            double averageAge = (ari.ReadabilityAge + fkr.ReadabilityAge + smog.ReadabilityAge + cli.ReadabilityAge) / 4.0;
            Average.Text =
                $"This text should be understood in average by {Math.Round(averageAge, 2)} year old.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Text.Text == "")
                MessageBox.Show("Enter text!", "Error");
            else
                FillBoxes();
        }
    }
}