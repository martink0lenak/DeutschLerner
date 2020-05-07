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
        


        public GeSkTranslate()
        {
            InitializeComponent();
            mode.GenerateWord();
            generatedWordTxtBlck.Text = mode.GeneratedWord;
        }

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mode.usedIndex.Count < mode.listWords.Count)
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
                generatedWordTxtBlck.Text = mode.GeneratedWord;
                answerTextBox.Text = "";
            }
            else
            {
                if (mode.IsRight(answerTextBox.Text))
                {
                    correctAnswersTextBlock.Text = mode.RightAnswers.ToString();
                }
                else
                {
                    incorrectAnswersTextBlock.Text = mode.WrongAnswers.ToString();
                }
                this.Close();
                MessageBox.Show("Správnych: " + mode.RightAnswers + "\n" + "Nesprávnych: " + mode.WrongAnswers);
            }
            
            
        }
    }
}
