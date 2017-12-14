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
            ContactsTextBox.Text = "";
          foreach (var item in bl.GetAllContracts())
            {
                ContactsTextBox.Text = item.ToString()+'\n';
            }


        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)//i need to think about it!
        {//i will implement a function that open a window of updating a contract
   ////////// var v=int.Parse(ContractUpdatetextBox.Text)
            
        }

      
    }
}
