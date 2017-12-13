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
    /// Interaction logic for DeletingChild.xaml
    /// </summary>
    public partial class DeletingChild : Window
    {
        BL.ourBL bl;
        BE.Child ch;
        public DeletingChild()
        {          
            bl = new ourBL();
            InitializeComponent();

            Child ch = new Child();
            this.ChildComboBox.DisplayMemberPath = "name";
            this.ChildComboBox.SelectedValuePath = "id";
            this.DataContext = ch;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Child ch = bl.GetChild(int.Parse(ChildComboBox.SelectedValuePath));
                bl.deleteChild(ch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
