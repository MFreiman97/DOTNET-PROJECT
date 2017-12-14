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
    /// Interaction logic for DeletingNanny.xaml
    /// </summary>
    public partial class DeletingNanny : Window
    {
        BL.ourBL bl;
        BE.Nanny n;
        public DeletingNanny()
        {
            bl = new ourBL();
            InitializeComponent();

            Nanny n = new Nanny();
            foreach (var item in bl.GetAllNannies())
            {

              comboBoxNanny.Items.Add(new ComboBoxItem() { Content = item.id });

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Nanny n = bl.GetNanny(int.Parse(comboBoxNanny.Text));              
                bl.deleteNanny(n);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
