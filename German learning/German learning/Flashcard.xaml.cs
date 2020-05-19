using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace German_learning
{
    /// <summary>
    /// Interaction logic for Flashcard.xaml
    /// </summary>
    public partial class Flashcard : Window
    {
        private Mode mode;
        private bool AnswerSwitch = true;
        public Flashcard()
        {
            mode = new Mode();
            mode.GenerateWord();
            InitializeComponent();
            FlipcardButton.Content = mode.GeneratedWord;

        }

        private void FlipcardButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerSwitch)
            {
                FlipcardButton.Content = mode.AnswerWord;
                AnswerSwitch = false;
            }
            else
            {
                FlipcardButton.Content = mode.GeneratedWord;
                AnswerSwitch = true;
            }
        }

        private void NextWordButton_Click(object sender, RoutedEventArgs e)
        {
            if (mode.guessedWord.Count < mode.listWords.Count)
            {
                mode.guessedWord.Add(mode.GeneratedWord);
                mode.GenerateWord();
                FlipcardButton.Content = mode.GeneratedWord;
            }
            else
            {
                this.Close();
            }
        }
            
    }
}
