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
using MahApps.Metro.Controls;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for Linq.xaml
    /// </summary>
    /// 
  
    public partial class Linq : MetroWindow
    {
        BL.IBL bl; 
        public Linq()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
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

            dataGridLinq.ItemsSource = bl.NeedNanny();
            
        }

        private void SpecialChildsButton_Click(object sender, RoutedEventArgs e)
        {

            dataGridLinq.ItemsSource = bl.GetSpecialChilds();
       
        }

        private void NannyByTheGov_Click(object sender, RoutedEventArgs e)
        {

            dataGridLinq.ItemsSource = bl.WorkingByTheGov();
            
        }

        private void JerusalemNannyButton_Click(object sender, RoutedEventArgs e)
        {

            dataGridLinq.ItemsSource = bl.GetAllNanniesFromJerusalem();
          
        }

        private void JerusalemMothersButton_Click(object sender, RoutedEventArgs e)
        {

            dataGridLinq.ItemsSource = bl.GetAllMothersFromJerusalem();
            
        }

        private void ContractsDistanceAbove40_Click(object sender, RoutedEventArgs e)
        {

            dataGridLinq.ItemsSource = bl.GetAllContracts(c => c.distance >= 40000);
         
        }

        /// <summary>
        /// Make At First All The Buttons As Enable & Change Them In Accordance With What Been Chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
    
            ContractsDistanceAbove40.IsEnabled = false;
            NeededChildsButton.IsEnabled = false;
            SpecialChildsButton.IsEnabled = false;
            NannyByTheGovButton.IsEnabled = false;
            JerusalemNannyButton.IsEnabled = false;
            JerusalemMothersButton.IsEnabled = false;
          
            ComboBoxItem cbi = (ComboBoxItem)comboBox.SelectedItem;
            string selectedText = cbi.Content.ToString();//this codes are actually help me to relate to the selected item as the current selected item
            if ( selectedText=="childs")
            {
                dataGridLinq.ItemsSource = bl.GetAllChilds();
               
                NeededChildsButton.IsEnabled = true;
                SpecialChildsButton.IsEnabled = true;
            }
            if ((selectedText == "contracts"))
            {
                dataGridLinq.ItemsSource = bl.GetAllContracts();
            
                ContractsDistanceAbove40.IsEnabled = true;
            }
            if ((selectedText == "mothers"))
            {
                dataGridLinq.ItemsSource = bl.GetAllMothers();
             
                JerusalemMothersButton.IsEnabled = true;
            }
            if ((selectedText == "nannies"))
            {
                dataGridLinq.ItemsSource = bl.GetAllNannies();
            
                JerusalemNannyButton.IsEnabled = true;
                NannyByTheGovButton.IsEnabled = true;
            }


        }

        /// <summary>
        /// Make At First All The Buttons As Enable & Change Them In Accordance With What Been Chosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_TextInput(object sender, TextCompositionEventArgs e)
        {
            ContractsDistanceAbove40.IsEnabled = false;
            NeededChildsButton.IsEnabled = false;
            SpecialChildsButton.IsEnabled = false;
            NannyByTheGovButton.IsEnabled = false;
            JerusalemNannyButton.IsEnabled = false;
            JerusalemMothersButton.IsEnabled = false;
        
            if ((comboBox.SelectedItem).ToString() == "childs" || comboBox.Text == "childs")
            {
                dataGridLinq.ItemsSource = bl.GetAllChilds();
     
                NeededChildsButton.IsEnabled = true;
                SpecialChildsButton.IsEnabled = true;
            }
            if ((comboBox.SelectedValue).ToString() == "contracts")
            {
                dataGridLinq.ItemsSource = bl.GetAllContracts();
                ContractsDistanceAbove40.IsEnabled = true;
            }
            if ((comboBox.SelectedValue).ToString() == "mothers")
            {
                dataGridLinq.ItemsSource = bl.GetAllMothers();
             
                JerusalemMothersButton.IsEnabled = true;
            }
            if ((comboBox.SelectedValue).ToString() == "nannies")
            {
                dataGridLinq.ItemsSource = bl.GetAllNannies();
               
                JerusalemNannyButton.IsEnabled = true;
                NannyByTheGovButton.IsEnabled = true;
            }


        }
    }
    }

