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
using BL;
using BE;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for UpdateContract.xaml
    /// </summary>
    public partial class UpdateContract : Window
    {
        BL.ourBL bl;
        Contract temp;
        public UpdateContract(Contract co)
        {
           
            InitializeComponent();
             bl = new ourBL();
            temp = new Contract();
            ContractTextBox.Text =""+ co.contnum;
            this.DataContext = temp;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bl.updateContract(temp);
        }
    }
}
