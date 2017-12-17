using System;//matanya
using BE;
using BL;
using GoogleMapsApi;
using GoogleMapsApi.Entities.DistanceMatrix.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
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
        BE.Contract Cont;
        public AddingContracts()
        {
            InitializeComponent();
            bl = new ourBL();
             
         
            //this.comboBoxChild.ItemsSource = bl.GetAllChilds();
            //this.comboBoxChild.DisplayMemberPath = "name";
            //this.comboBoxChild.SelectedValuePath = "id";
            foreach (var item in bl.NeedNanny())
            {
                comboBoxChild.Items.Add(new ComboBoxItem() { Content = item.id });
            }

           
            this.TypecomboBox.ItemsSource = Enum.GetValues(typeof(BE.ContractType));
        }

        private void AddTheContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                Cont.n = bl.GetNanny(int.Parse(NannyChosedTextBox.Text));
                Cont.c = bl.GetChild(int.Parse(comboBoxChild.Text));
         
                
               
                bl.addContract(Cont);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

      

       

        private void TypecomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {    Cont = new Contract();
                 this.DataContext = Cont;
            string selectedText = TypecomboBox.Text;
            Child SelChi = bl.GetChild(int.Parse(comboBoxChild.Text));
            MatchedNanniesTextBox.Text = "";
            if ((BE.ContractType)TypecomboBox.SelectedValue==  ContractType.hourly)
            {


                foreach (var item in bl.GetAllMatchedNannies(SelChi.mom, true))
                {
                    MatchedNanniesTextBox.Text += item.ToString() + '\n';

                }


            }
            if ((BE.ContractType)TypecomboBox.SelectedValue == ContractType.monthly)
            {

                foreach (var item in bl.GetAllMatchedNannies(SelChi.mom, false))
                {
                    MatchedNanniesTextBox.Text += item.ToString() + '\n';

                }


            }
            if (bl.GetAllNanniesByTerm(SelChi.mom).Count() == 0)//when there is no match to the demands of the mother
            {
                MessageBox.Show("there is no match to the mother demands. the nannies are shown is the best five");
                foreach (var item in bl.TheBestFive(SelChi.mom))
                {
                    MatchedNanniesTextBox.Text += item.ToString() + " The distance is: " + bl.CalculateDistance(Cont.c.mom.address, Cont.n.address) + '\n';

                }
            }

        }
    }
}
