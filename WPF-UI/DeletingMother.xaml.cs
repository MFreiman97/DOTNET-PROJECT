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
    /// Interaction logic for DeletingMother.xaml
    /// </summary>
    public partial class DeletingMother : Window
    {
        BL.ourBL bl;
        BE.Mother mo;
        public DeletingMother()
        {
            InitializeComponent();
            mo = new Mother();
            bl = new ourBL();
         
            foreach (var item in bl.GetAllMothers())
            {
              MotherComboBox.Items.Add(new ComboBoxItem() { Content = item.id });
            }

        }

        /// <summary>
        /// Deleting Mother By ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mother m = bl.GetMother(int.Parse(MotherComboBox.Text));
                bl.deleteMom(m);
                   this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }

    }
}
