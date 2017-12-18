using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BL;
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
    /// Interaction logic for Linq.xaml
    /// </summary>
    /// 
  
    public partial class Linq : Window
    {
        BL.IBL bl; 
        public Linq()
        {
            InitializeComponent();
            bl=new ourBL();
            ContractsDistanceAbove40.IsEnabled = false;
            NeededChildsButton.IsEnabled = false;
            SpecialChildsButton.IsEnabled = false;
            NannyByTheGovButton.IsEnabled = false;
            JerusalemNannyButton.IsEnabled = false;
            JerusalemMothersButton.IsEnabled = false; 
            comboBox.Items.Add(new ComboBoxItem() { Content = "childs" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "contracts" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "mothers" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "nannies" });
        }

      

        private void NeededChildsButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";//cleaning reason
            foreach (var item in bl.NeedNanny())
            {
                textBoxOutput.Text += item.ToString() + '\n';

            }
        }

        private void SpecialChildsButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";//cleaning reason
            foreach (var item in bl.GetSpecialChilds())
            {
                textBoxOutput.Text += item.ToString() + '\n';

            }
        }

        private void NannyByTheGov_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";//cleaning reason
            foreach (var item in bl.WorkingByTheGov())
            {
                textBoxOutput.Text += item.ToString() + '\n';

            }
        }

        private void JerusalemNannyButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";//cleaning reason
            foreach (var item in bl.GetAllNanniesFromJerusalem())
            {
                textBoxOutput.Text += item.ToString() + '\n';

            }
        }

        private void JerusalemMothersButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";//cleaning reason
            foreach (var item in bl.GetAllMothersFromJerusalem())
            {
                textBoxOutput.Text += item.ToString() + '\n';

            }
        }

        private void ContractsDistanceAbove40_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";//cleaning reason
            foreach (var item in bl.GetAllContracts(c=>c.distance>=40))
            {
                textBoxOutput.Text += item.ToString() + '\n';

            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
            ContractsDistanceAbove40.IsEnabled = false;
            NeededChildsButton.IsEnabled = false;
            SpecialChildsButton.IsEnabled = false;
            NannyByTheGovButton.IsEnabled = false;
            JerusalemNannyButton.IsEnabled = false;
            JerusalemMothersButton.IsEnabled = false;
            textBoxOutput.Text = "";
            ComboBoxItem cbi = (ComboBoxItem)comboBox.SelectedItem;
            string selectedText = cbi.Content.ToString();//this codes are actually help me to relate to the selected item as the current selected item
            if ( selectedText=="childs")
            {
                foreach (var item in bl.GetAllChilds())
                {
                    textBoxOutput.Text += item.ToString() + '\n';

                }
                NeededChildsButton.IsEnabled = true;
                SpecialChildsButton.IsEnabled = true;
            }
            if ((selectedText == "contracts"))
            {
                foreach (var item in bl.GetAllContracts())
                {
                    textBoxOutput.Text += item.ToString() + '\n';

                }
                ContractsDistanceAbove40.IsEnabled = true;
            }
            if ((selectedText == "mothers"))
            {
                foreach (var item in bl.GetAllMothers())
                {
                    textBoxOutput.Text += item.ToString() + '\n';

                }
                JerusalemMothersButton.IsEnabled = true;
            }
            if ((selectedText == "nannies"))
            {
                foreach (var item in bl.GetAllNannies())
                {
                    textBoxOutput.Text += item.ToString() + '\n';

                }
                JerusalemNannyButton.IsEnabled = true;
                NannyByTheGovButton.IsEnabled = true;
            }


        }

        private void comboBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            ContractsDistanceAbove40.IsEnabled = false;
            NeededChildsButton.IsEnabled = false;
            SpecialChildsButton.IsEnabled = false;
            NannyByTheGovButton.IsEnabled = false;
            JerusalemNannyButton.IsEnabled = false;
            JerusalemMothersButton.IsEnabled = false;
            textBoxOutput.Text = "";
            if ((comboBox.SelectedItem).ToString() == "childs" || comboBox.Text == "childs")
            {
                foreach (var item in bl.GetAllChilds())
                {
                    textBoxOutput.Text += item.ToString() + '\n';

                }
                NeededChildsButton.IsEnabled = true;
                SpecialChildsButton.IsEnabled = true;
            }
            if ((comboBox.SelectedValue).ToString() == "contracts")
            {
                foreach (var item in bl.GetAllContracts())
                {
                    textBoxOutput.Text += item.ToString() + '\n';

                }
                ContractsDistanceAbove40.IsEnabled = true;
            }
            if ((comboBox.SelectedValue).ToString() == "mothers")
            {
                foreach (var item in bl.GetAllMothers())
                {
                    textBoxOutput.Text += item.ToString() + '\n';

                }
                JerusalemMothersButton.IsEnabled = true;
            }
            if ((comboBox.SelectedValue).ToString() == "nannies")
            {
                foreach (var item in bl.GetAllNannies())
                {
                    textBoxOutput.Text += item.ToString() + '\n';

                }
                JerusalemNannyButton.IsEnabled = true;
                NannyByTheGovButton.IsEnabled = true;
            }


        }
    }
    }

