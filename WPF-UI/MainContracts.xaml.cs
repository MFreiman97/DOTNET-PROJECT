using System;//matanya
using BE;
using BL;
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
    /// Interaction logic for MainContracts.xaml
    /// </summary>
    public partial class MainContracts : Window
    {
        BL.ourBL bl;
        BE.Contract co;
        public MainContracts()
        {
            InitializeComponent();
            bl = new ourBL();
            co = new BE.Contract();
            this.TypecomboBox.ItemsSource = Enum.GetValues(typeof(BE.ContractType));
        }

        private void AddTheContract_Click(object sender, RoutedEventArgs e)
        {
            co = new Contract() {n=bl.GetNanny(int.Parse(NannyChosedTextBox.Text)) };




            bl.addContract(co);
        }

        private void comboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MatchedNanniesTextBox.Text = "";//if the user changed the child
              foreach (var item in bl.GetAllNannies(co.c.mom))
            {
                MatchedNanniesTextBox.Text += item.ToString()+'\n';
           
            }
        }
    }
}
