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
using MahApps.Metro.Controls;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for UpdateContract.xaml
    /// </summary>
    public partial class UpdateContract : MetroWindow
    {
        BL.IBL bl;
        Contract temp;

        /// <summary>
        /// Get The Contract By Number & Changes It's Date
        /// </summary>
        /// <param name="co"></param>
        public UpdateContract(Contract co)
        {
           
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            temp = new Contract();
            temp = bl.GetContract(co.contnum);//the paramater of updating is only the date of the ending of the contract
            ContractTextBox.Text =""+ co.contnum;
            this.DataContext = temp;
            dt.DisplayDateStart = DateTime.Now.AddDays(1);//day from today
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bl.updateContract(temp);
            this.Close();
        }
    }
}
