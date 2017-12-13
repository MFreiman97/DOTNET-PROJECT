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
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for DeletingContracts.xaml
    /// </summary>
    public partial class DeletingContracts : Window
    {
        BL.ourBL bl;
        BE.Contract co;
        public DeletingContracts()
        {
            bl = new ourBL();
            InitializeComponent();

            Contract co = new Contract();
            this.ContractComboBox.DisplayMemberPath = "Contnum";
            this.ContractComboBox.SelectedValuePath = "Contnum";
            this.DataContext = co;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in bl.GetAllContracts(co => co.contnum.Equals(int.Parse(ContractComboBox.SelectedValuePath))))
                {
                    bl.deleteChild(item.c);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
