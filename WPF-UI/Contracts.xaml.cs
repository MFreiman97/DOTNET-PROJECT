using BL;//matanya
using BE;
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
    
    public partial class Contracts : Window
    {
        IBL bl;
        public Contracts()
        {

            InitializeComponent();
            bl = new ourBL();



            this.ContractsComboBox.ItemsSource = bl.GetAllContracts();
            this.ContractsComboBox.DisplayMemberPath = "contnum";
            this.ContractsComboBox.SelectedValuePath = "contnum";
        }

        private void ContractsComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            InfoTextBox.Text = "";
            foreach(var item in bl.GetAllContracts(c=>c.contnum==int.Parse(this.ContractsComboBox.Text)))
                {
                InfoTextBox.Text += item.ToString();
                 }

        }

        private void UpdateContractButton_Click(object sender, RoutedEventArgs e)
        {
            var item = new UpdateContract(int.Parse(this.ContractsComboBox.Text));//i need to make the this class!
        }
    }
}
