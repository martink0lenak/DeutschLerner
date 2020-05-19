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
using Newtonsoft.Json;
using static German_learning.RootWord;

namespace German_learning
{
    /// <summary>
    /// Interaction logic for GeSkTranslate.xaml
    /// </summary>


    public partial class GeSkTranslate : Window
    {
        private Mode mode = new Mode();
        public string Answer { get; private set; }
        public static bool IsOpen { get; private set; } = false;
        public GeSkTranslate()
        {
            IsOpen = true;
            InitializeComponent();
            mode.GenerateWord();
            generatedWordTxtBlck.Text = mode.GeneratedWordGender + " " + mode.GeneratedWord;
        }

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mode.IsRight(answerTextBox.Text))
            {
                correctAnswersTextBlock.Text = mode.RightAnswers.ToString();
            }
            else
            {
                incorrectAnswersTextBlock.Text = mode.WrongAnswers.ToString();
            }
            mode.GenerateWord();
            if (mode.isOver)
            {
                this.Close();
                MessageBox.Show("Správnych: " + mode.RightAnswers + "\n" + "Nesprávnych: " + mode.WrongAnswers);
            }
            else
            {
                generatedWordTxtBlck.Text = $"{mode.GeneratedWordGender} {mode.GeneratedWord}";
                answerTextBox.Text = "";
            }
        }

        private void CapitalUButton_Click(object sender, RoutedEventArgs e)
        {
            answerTextBox.Text += "Ü";
        }

        private void SmallUButton_Click(object sender, RoutedEventArgs e)
        {
            answerTextBox.Text += "ü";
        }

        private void SmallOButton_Click(object sender, RoutedEventArgs e)
        {
            answerTextBox.Text += "ö";
        }

        private void SharpSButton_Click(object sender, RoutedEventArgs e)
        {
            answerTextBox.Text += "ß";
        }

        private void GeSkWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
        }
    }
}
