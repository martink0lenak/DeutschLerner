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
        private GeSkMode geSkMode { get; set; } = new GeSkMode();
        
        
        public string Answer { get; private set; }


        public GeSkTranslate()
        {
            InitializeComponent();
            
        }

        
    }
}
