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
        BL.IBL bl;= 
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
            comboBox.Items.Add(new ComboBoxItem() { Content = "Childs" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "contracts" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "mothers" });
            comboBox.Items.Add(new ComboBoxItem() { Content = "nannies" });
        }

        private void comboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ContractsDistanceAbove40.IsEnabled = false;
            NeededChildsButton.IsEnabled = false;
            SpecialChildsButton.IsEnabled = false;
            NannyByTheGovButton.IsEnabled = false;
            JerusalemNannyButton.IsEnabled = false;
            JerusalemMothersButton.IsEnabled = false;
            textBoxOutput.Text = "";
            if (comboBox.Text == "childs")
            {
                foreach (var item in bl.GetAllChilds())
                {
                    textBoxOutput.Text = item.ToString() + '\n';
                   
                }
                NeededChildsButton.IsEnabled = true;
                    SpecialChildsButton.IsEnabled = true;
            }
            if (comboBox.Text == "contracts")
            {
                foreach (var item in bl.GetAllContracts())
                {
                    textBoxOutput.Text = item.ToString() + '\n';

                }
                ContractsDistanceAbove40.IsEnabled = true;
            }
            if (comboBox.Text == "mothers")
            {
                foreach (var item in bl.GetAllMothers())
                {
                    textBoxOutput.Text = item.ToString() + '\n';

                }
                JerusalemMothersButton.IsEnabled = true;
            }
            if (comboBox.Text == "nannies")
            {
                foreach (var item in bl.GetAllNannies())
                {
                    textBoxOutput.Text = item.ToString() + '\n';

                }
                JerusalemNannyButton.IsEnabled = true;
                NannyByTheGovButton.IsEnabled = true;
            }


        }

        private void NeededChildsButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";
            foreach (var item in bl.NeedNanny())
            {
                textBoxOutput.Text = item.ToString() + '\n';

            }
        }

        private void SpecialChildsButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";
            foreach (var item in bl.GetSpecialChilds())
            {
                textBoxOutput.Text = item.ToString() + '\n';

            }
        }

        private void NannyByTheGov_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";
            foreach (var item in bl.WorkingByTheGov())
            {
                textBoxOutput.Text = item.ToString() + '\n';

            }
        }

        private void JerusalemNannyButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";
            foreach (var item in bl.GetAllNanniesFromJerusalem())
            {
                textBoxOutput.Text = item.ToString() + '\n';

            }
        }

        private void JerusalemMothersButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";
            foreach (var item in bl.GetAllMothersFromJerusalem())
            {
                textBoxOutput.Text = item.ToString() + '\n';

            }
        }

        private void ContractsDistanceAbove40_Click(object sender, RoutedEventArgs e)
        {
            textBoxOutput.Text = "";
            foreach (var item in bl.GetAllContracts(c=>c.distance>=40))
            {
                textBoxOutput.Text = item.ToString() + '\n';

            }
        }
    }
}
