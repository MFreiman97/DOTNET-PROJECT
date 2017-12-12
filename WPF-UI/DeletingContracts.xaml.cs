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
        public DeletingContracts()
        {
            InitializeComponent();
            bl = new ourBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Contract co = bl.GetAllContracts(c => c.contnum() == int.Parse(NumbertextBox.Text));
                //bl.deleteChild(co);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
