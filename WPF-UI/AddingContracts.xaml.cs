using System;//matanya
using BE;
using BL;
using GoogleMapsApi;
using GoogleMapsApi.Entities.DistanceMatrix.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;


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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainContracts.xaml
    /// </summary>
    public partial class AddingContracts : MetroWindow
    {
        BL.IBL bl;
        bool BestFive=false;
        BE.Contract Cont;
        BE.Child child;
        BE.ContractType ContType;//usefull for using the thread of the distance calculation
        List<Nanny> str;//usefull for using the thread of the distance calculation
        BackgroundWorker work;
        static Random r = new Random();

        public AddingContracts()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();

            str = new List<Nanny>();
            this.comboBoxChild.Text = "-";
            this.comboBoxChild.ItemsSource = bl.NeedNanny();
            this.comboBoxChild.DisplayMemberPath = "FullName";
            this.comboBoxChild.SelectedValuePath = "id";
            this.TypecomboBox.ItemsSource = Enum.GetValues(typeof(BE.ContractType));
            Cont = new Contract();
            this.DataContext = Cont;
            Cont.DateEnd = DateTime.Now;
            Cont.DateEnd=Cont.DateEnd.AddYears(1);
            ContDatePicker.DisplayDateStart = DateTime.Now.AddDays(1);
            this.TypecomboBox.IsEnabled = false;
            dataGridNannies.ItemsSource = str.AsEnumerable();
            dataGridNannies.SelectedValuePath = "id";
        }

        /// <summary>
        /// function that added to the event of the clicking that adding the contract
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddTheContract_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridNannies.SelectedValue != null)
            {
                try
                {

                    Cont.n = bl.GetNanny((int)dataGridNannies.SelectedValue);
                    Cont.c = bl.GetChild((int)comboBoxChild.SelectedValue);



                    Thread t = new Thread(() => bl.addContract(Cont));
                    t.Start();
                    var Message = await this.ShowMessageAsync("New Contract was added successfully!", "Good Day!!!");
                    this.comboBoxChild.ItemsSource = null;
                    this.comboBoxChild.ItemsSource = bl.NeedNanny();
                    this.comboBoxChild.DisplayMemberPath = "FullName";
                    this.comboBoxChild.SelectedValuePath = "id";
                    dataGridNannies.ItemsSource = null;

                    if (Message == MessageDialogResult.Affirmative)
                        this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }





        private void TypecomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TypecomboBox.IsEnabled == true)
            {
                work = new BackgroundWorker();
                work.WorkerSupportsCancellation = true;
                Cont.c = bl.GetChild((int)comboBoxChild.SelectedValue);


                child = bl.GetChild((int)comboBoxChild.SelectedValue);
                ContType = (BE.ContractType)TypecomboBox.SelectedValue;
                str = new List<Nanny>();

                work.DoWork += W_DoWork;
                work.RunWorkerCompleted += W_RunWorkerCompleted;
                work.ProgressChanged += Work_ProgressChanged;
                work.WorkerReportsProgress = true;
                work.RunWorkerAsync();
            }

        }

        private void Work_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressRing.IsActive = true;
        }

        private void W_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            
        {
            if (e.Error == null)
            {
                ProgressRing.IsActive = false;
                dataGridNannies.ItemsSource = null;
                dataGridNannies.ItemsSource = str.AsEnumerable();
                dataGridNannies.SelectedValuePath = "id";
                BackgroundWorker work = sender as BackgroundWorker;
                  work.CancelAsync();
                if (str.Count == 0)
                    this.ShowMessageAsync("There is no matched nanny to this child", "good day!");
            }
            else if (e.Error != null || e.Error.Message == "הרצף לא מכיל תווים"||e.Error.Message== "הרצף לא מכיל רכיבים")
            {
            
                MessageBox.Show("Error: " + e.Error.Message);
                ProgressRing.IsActive = false;
                work.CancelAsync();
            }
        else
            {
                ProgressRing.IsActive = false;
                MessageBox.Show("Check your connection to the internet");
                work.CancelAsync();
            }
            
        }

        private void W_DoWork(object sender, DoWorkEventArgs e)
        {

            work.ReportProgress(5);
            if (ContType == ContractType.hourly)
            {
              

                foreach (var item in bl.GetAllMatchedNannies(Cont.c.mom,Cont.c, true))
                {

                    str.Add(item);

                }


            }
            if (ContType == ContractType.monthly)
            {
               
                foreach (var item in bl.GetAllMatchedNannies(Cont.c.mom, Cont.c, false))
                {

                    str.Add(item);
                }


            }
            if (bl.GetAllNanniesByTerm(Cont.c.mom).Count() == 0)//when there is no match to the demands of the mother
            {
    
              //***************************************************
                //foreach (var item in bl.TheBestFive(Cont.c.mom))
                //{
                //    if(bl.TheBestFive(Cont.c.mom)!=null)
                //    str.Add(item);
                //}

            }


        }

        private void comboBoxChild_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxChild.Text = comboBoxChild.Text;
            TypecomboBox.IsEnabled = true;
        }
    }
}
