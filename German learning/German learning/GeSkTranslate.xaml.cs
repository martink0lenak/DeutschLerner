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
    /// Interaction logic for GeSkTranslate.xaml
    /// </summary>


    public partial class GeSkTranslate : Window
    {
        private GeSkMode geSkMode;


        public static string Answer { get; private set; }
        public GeSkTranslate()
        {
            InitializeComponent();
        }
    }
}
