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
    public partial class AddingContracts : Window
    {
        BL.ourBL bl;
        BE.Contract co;
        public AddingContracts()
        {
            InitializeComponent();
            bl = new ourBL();
            co = new BE.Contract();
            this.TypecomboBox.ItemsSource = Enum.GetValues(typeof(BE.ContractType));
        }

        private void AddTheContract_Click(object sender, RoutedEventArgs e)
        {try
            {
                co = new Contract()
                {
                    n = bl.GetNanny(int.Parse(NannyChosedTextBox.Text)),
                    c = bl.GetChild(int.Parse(comboBox.Text)),
                };


                bl.addContract(co);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            MatchedNanniesTextBox.Text = "";//if the user changed the child
              foreach (var item in bl.GetAllNannies(co.c.mom))
            {
                MatchedNanniesTextBox.Text += item.ToString()+" The distance is: "+ bl.CalculateDistance(co.c.mom.address,co.n.address)+'\n';
           
            }
              if(bl.GetAllNannies(co.c.mom).Count()==0)//when there is no match to the demands of the mother
            {
                MessageBox.Show("there is no match to the mother demands. the nannies are shown is the best five");
                foreach (var item in bl.TheBestFive(co.c.mom))
                {
                    MatchedNanniesTextBox.Text += item.ToString() + " The distance is: " + bl.CalculateDistance(co.c.mom.address, co.n.address) + '\n';

                }
            }
        }
    }
}
