﻿using System;
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
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public static bool IsOpen { get; protected set; } = false;
        public About()
        {
            IsOpen = true;
            InitializeComponent();
        }

        private void About_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsOpen = false;
        }
    }
}
