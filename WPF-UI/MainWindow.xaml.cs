using System;//matanya
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using BL;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.ourBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = new ourBL();
        }

        private void AddNanny_Click(object sender, RoutedEventArgs e)
        {
           var v= new AddingNanny();
            v.ShowDialog();
        }

        private void AddMother_Click(object sender, RoutedEventArgs e)
        {
            var v = new AddingMother();
            v.ShowDialog();
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
          
            var v = new AddingChild();
            if (bl.GetAllMothers().Count() == 0)
            {
                MessageBox.Show("you have to add mother before adding a child");
            }
            else
            v.ShowDialog();
        }

        private void Adding_Contracts_Click(object sender, RoutedEventArgs e)// add contract button
        {
        
            var v = new AddingContracts();
         
            v.ShowDialog();
        }

        private void All_Contracts_Click_1(object sender, RoutedEventArgs e)
        {
            var v = new Contracts();

            v.ShowDialog();
        }

        private void LinqButton_Click(object sender, RoutedEventArgs e)
        {
            var v = new Linq();
            v.ShowDialog();
        }

        private void DeleteNanny_Click(object sender, RoutedEventArgs e)
        {
            var v = new DeletingNanny();
            v.ShowDialog();
        }

        private void DeleteMother_Click(object sender, RoutedEventArgs e)
        {
            var v = new DeletingMother();
            v.ShowDialog();
        }

        private void DeleteChild_Click(object sender, RoutedEventArgs e)
        {
            var v = new DeletingChild();
            v.ShowDialog();
        }

        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            var v = new DeletingContracts();
                v.ShowDialog();
        }
    }
}
