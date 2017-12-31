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
using System.Threading;
using System.ComponentModel;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainContracts.xaml
    /// </summary>
    public partial class AddingContracts : Window
    {
        BL.ourBL bl;
        bool BestFive=false;
        BE.Contract Cont;
        BE.Child child;
        BE.ContractType ContType;//usefull for using the thread of the distance calculation
        string str;//usefull for using the thread of the distance calculation
        static Random r = new Random();
        public AddingContracts()
        {
            InitializeComponent();
            bl = new ourBL();
             
         
            this.comboBoxChild.ItemsSource = bl.GetAllChilds();
            this.comboBoxChild.DisplayMemberPath = "FullName";
            this.comboBoxChild.SelectedValuePath = "id";
            this.TypecomboBox.ItemsSource = Enum.GetValues(typeof(BE.ContractType));
            Cont = new Contract();
         this.   DataContext = Cont;
            TypecomboBox.IsEnabled = false;
        }

        private void AddTheContract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                Cont.n = bl.GetNanny(int.Parse(NannyChosedTextBox.Text));
                Cont.c = bl.GetChild((int)comboBoxChild.SelectedValue);



                Thread t = new Thread(() => bl.addContract(Cont));
                t.Start();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        

        private void TypecomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypecomboBox.IsEnabled == true)
            {
                BackgroundWorker work = new BackgroundWorker();
                work.WorkerSupportsCancellation = true;
                Cont.c = bl.GetChild((int)comboBoxChild.SelectedValue);

            
                child = bl.GetChild((int)comboBoxChild.SelectedValue);
                ContType = (BE.ContractType)TypecomboBox.SelectedValue;
                str = "";
                work.DoWork += W_DoWork;
                work.RunWorkerCompleted += W_RunWorkerCompleted;
                work.RunWorkerAsync();
            }
            else
            {
                TypecomboBox.IsEnabled = true;
            }

        }

        private void W_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            
        {
            
            MatchedNanniesTextBox.Text = str;
            BackgroundWorker work = sender as BackgroundWorker;
            work.CancelAsync();
        }

        private void W_DoWork(object sender, DoWorkEventArgs e)
        {
          
            if (ContType == ContractType.hourly)
            {
              

                foreach (var item in bl.GetAllMatchedNannies(Cont.c.mom, true))
                {

                    str += item.ToString() + '\n';

                }


            }
            if (ContType == ContractType.monthly)
            {
               
                foreach (var item in bl.GetAllMatchedNannies(Cont.c.mom, false))
                {

                    str += item.ToString() + '\n';

                }


            }
            if (bl.GetAllNanniesByTerm(Cont.c.mom).Count() == 0)//when there is no match to the demands of the mother
            {
    
                str += "the nannies are shown is the best 5"+'\n';
                foreach (var item in bl.TheBestFive(Cont.c.mom))
                {
                    str += item.ToString();
                }

            }


        }

   
    }
}
