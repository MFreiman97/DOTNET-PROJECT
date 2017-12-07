using BE;
using BL;
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
    /// <summary>
    /// Interaction logic for AddingChild.xaml
    /// </summary>
    public partial class AddingChild : Window
    {
        public AddingChild()
        {
            InitializeComponent();
            comboBoxBool.Items.Add( new ComboBoxItem() { Content = "Yes" });
            comboBoxBool.Items.Add(new ComboBoxItem() { Content = "No" });
        }

        private void ChildAdded_Click(object sender, RoutedEventArgs e)
        {
            Child c = new Child() { id = int.Parse(IDtextBox.Text),
                momId = int.Parse(IDMOMtextBox.Text),
                birth = new DateTime(ChildBornDate.SelectedDate.Value.Year, ChildBornDate.SelectedDate.Value.Month, ChildBornDate.SelectedDate.Value.Day),
                name = NAMEtextBox.Text,
                
              //  special = bool.Parse(DisabletexTBOX.Text)
          };
        }
    }
}
