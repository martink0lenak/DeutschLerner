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
    /// Interaction logic for ModeSelection.xaml
    /// </summary>
    public partial class ModeSelection : Window
    {
        public ModeSelection()
        {
            InitializeComponent();
        }
        #region stores the selected Mode into a string
        public static string SelectMode { get; private set; }
        #endregion

        #region stores a boolean value to avoid starting without a mode selected
        public static bool IsModeSelected { get; private set; } = false;
        #endregion

        #region checks whether a mode is selected and which is selected
        private void IsModeChosen()
        {
            if (geSkRadioButton.IsChecked == true)
            {
                IsModeSelected = true;
                SelectMode = "gesk";
                this.Close();
            }
            else if (skGeRadioButton.IsChecked == true)
            {
                IsModeSelected = true;
                Mode = "skge";
                this.Close();
            }
            else if (perfetkumRadioButton.IsChecked == true)
            {
                IsModeSelected = true;
                Mode = "perfektum";
                this.Close();
            }
            else if (pluralRadioButton.IsChecked == true)
            {
                IsModeSelected = true;
                Mode = "plural";
                this.Close();
            }
            else if (genderRadioButton.IsChecked == true)
            {
                IsModeSelected = true;
                Mode = "gender";
                this.Close();
            }
            else
            {
                IsModeSelected = false;
                Mode = null;     
                this.Close();
            }
        }
        #endregion

        #region OK button click stores the selected mode value
        private void ModeSelectionOKButton_Click(object sender, RoutedEventArgs e)
        {
            IsModeChosen();
        }
        #endregion

        #region resets a static boolean preventing from multiple instances running at the same time
        private void ModeSelectionWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.IsModeSelectionOpen = false;
        }
        #endregion
    }
}
