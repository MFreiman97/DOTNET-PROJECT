﻿using BE;
using BL;
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

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for AddingChild.xaml
    /// </summary>
    public partial class AddingChild : Window
    {
        BE.Child ch;
        BL.IBL bl;
        public AddingChild()
        {
            InitializeComponent();
          
            bl = new ourBL();
       
            comboBoxBool.Items.Add( new ComboBoxItem() { Content = "Yes" });
            comboBoxBool.Items.Add(new ComboBoxItem() { Content = "No" });
            foreach(var item in bl.GetAllMothers())
            {
                comboBoxMothers.Items.Add(new ComboBoxItem() { Content = item.id  });
            }
        }

        private void ChildAdded_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ch = new Child()
                {
                    mom = bl.GetMother(int.Parse(comboBoxMothers.SelectedValue.ToString())),
                    id = int.Parse(IDtextBox.Text),
                    name = NAMEtextBox.Text,
                    kindSpecial = DescOfDisabilityTextBox.Text
                };
                if (comboBoxBool.Text == "Yes")
                    ch.special = true;
                else
                    ch.special = false;

                 
                bl.addChild(ch);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
    }

