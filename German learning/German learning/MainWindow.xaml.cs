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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;

namespace German_learning
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    //Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) - ProgramFiles filepath


    public partial class MainWindow : Window
    {


        #region string storing the lecture and sublecture selection in a format NumberLetter (eg. 11B)
        public static string LectureSelectionFileName { get; private set; }
        #endregion

        #region boolean which is true when the ModeSelection window is open, preventing multiple instances
        public static bool IsModeSelectionOpen { private get; set; } = false;
        #endregion

        public static string GameMode { get; private set; }

        #region class constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region open mode selection window
        private void modeSelectionBtnClick(object sender, RoutedEventArgs e)
        {
            if (IsModeSelectionOpen == false)
            {
                ModeSelection modeSelection = new ModeSelection();

                modeSelection.Show();
                IsModeSelectionOpen = true;
            }
            else
            {

            }
        }
        #endregion

        #region start button - runs the selected mode
        private void menuStartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!GeSkTranslate.IsOpen)
            {
                if (ModeSelection.IsModeSelected == true && lectureNumTextBox.Text != "" && subLectureComboBox.Text != "")
                {
                    for (int i = 11; i <= 21; i++)
                    {
                        string iStr = i.ToString();
                        if (i == 21)
                        {
                            MessageBox.Show("Prosím, zadajte správne číslo (11-20) a uistite sa, či za ním nie sú medzery.");
                            break;
                        }
                        else if (lectureNumTextBox.Text == iStr)
                        {
                            if (lectureNumTextBox.Text == "11" && subLectureComboBox.Text == "A")
                            {
                                MessageBox.Show("Lekcia 11A nemá žiadnu slovnú zásobu");
                                break;
                            }

                            LectureSelectionFileName = iStr + subLectureComboBox.Text + ".json";
                            if (!File.Exists(@"Lekcie\" + LectureSelectionFileName))
                            {
                                MessageBox.Show(@"Súbor nebol nájdený. Uistite sa, že sa súbor nachádza v zložke Lekcie");
                                break;
                            }
                            ////////

                            if (GameMode == "flipcard")
                            {
                                Flashcard flashcard = new Flashcard();
                                flashcard.Show();
                                break;
                            }
                            else if (GameMode == "QnA")
                            {
                                GeSkTranslate geSkTranslate = new GeSkTranslate();
                                geSkTranslate.Show();
                                break;
                            }
                            



                            ////////
                        }
                    }

                }
                else
                {
                    if (lectureNumTextBox.Text == "")
                    {
                        MessageBox.Show("Prosím, zvoľte číslo lekcie");
                    }
                    else if (ModeSelection.IsModeSelected == false)
                    {
                        MessageBox.Show("Prosím, vyberte si mód");
                    }
                    else if (subLectureComboBox.Text == "")
                    {
                        MessageBox.Show("Prosím, zvoľte podlekciu alebo celú lekciu");
                    }

                }
            }
            
        }
        #endregion

        #region opens the license
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            if (!About.IsOpen)
            {
                About about = new About();
                about.Show();
            }
        }
        #endregion

        #region flipcard mode radio button
        private void FlipcardRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            GameMode = "flipcard";
        }
        #endregion

        #region QnA mode radio button
        private void QuestionAnswerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            GameMode = "QnA";
        }
        #endregion

    }
}
