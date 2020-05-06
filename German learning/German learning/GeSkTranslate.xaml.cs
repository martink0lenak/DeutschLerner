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
        private GeSkMode geSkMode;


        public string Answer { get; private set; }
        


        public GeSkTranslate()
        {
            InitializeComponent();
            geSkMode = new GeSkMode();
            geSkMode.GenerateWord();
            generatedWordTxtBlck.Text = geSkMode.GeneratedWord;
        }

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (geSkMode.usedIndex.Count < geSkMode.listWords.Count)
            {
                if (geSkMode.IsRight(answerTextBox.Text))
                {
                    correctAnswersTextBlock.Text = geSkMode.RightAnswers.ToString();
                }
                else
                {
                    incorrectAnswersTextBlock.Text = geSkMode.WrongAnswers.ToString();
                }
                geSkMode.GenerateWord();
                generatedWordTxtBlck.Text = geSkMode.GeneratedWord;
                answerTextBox.Text = "";
            }
            else
            {
                if (geSkMode.IsRight(answerTextBox.Text))
                {
                    correctAnswersTextBlock.Text = geSkMode.RightAnswers.ToString();
                }
                else
                {
                    incorrectAnswersTextBlock.Text = geSkMode.WrongAnswers.ToString();
                }
                this.Close();
                MessageBox.Show("Správnych: " + geSkMode.RightAnswers + "\n" + "Nesprávnych: " + geSkMode.WrongAnswers);
            }
            
            
        }
    }
}
