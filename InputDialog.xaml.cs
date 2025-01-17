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

namespace AtmApplication_shweta
{
    
    /// Interaction logic for InputDialog.xaml
   
 
        public partial class InputDialog : Window
        {
            public string InputText { get; private set; }
            public bool IsOK { get; private set; }
            public string Prompt { get; set; }

            public InputDialog(string prompt)
            {
                InitializeComponent();
                Prompt = prompt;
                DataContext = this;
            }

            private void OK_Click(object sender, RoutedEventArgs e)
            {
                InputText = txtInput.Text;
                IsOK = true;
                Close();
            }

            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                InputText = null;
                IsOK = false;
                Close();
            }
        }
    }

