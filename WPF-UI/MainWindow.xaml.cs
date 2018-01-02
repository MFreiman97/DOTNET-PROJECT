using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using BL;
using System.Configuration;
using System.Data;
using BE;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GoogleMapsApi;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using GoogleMapsApi.Entities.DistanceMatrix.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;


using System.Threading;
using System.ComponentModel;
using MahApps.Metro.Controls;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        BL.ourBL bl;
        int x;
        public MainWindow()
        {
            InitializeComponent();
         
             bl = new ourBL();
            #region init for dubugging
            Nanny n1 = new Nanny()
            {
                id = int.Parse("3214"),
                fname = "Barnel",
                name = "Nicki",
                cell = "0532445356",
                address = "Jerusalem" + "," + "Erich Mendelson" + "," + "4",
                elevator = false,
                experience = int.Parse("5"),
                Maxkids = int.Parse("5"),
                MinAge = int.Parse("3"),
                MaxAge = int.Parse("14"),
                SalaryPerHour = true,
                HolidaysByTheGOV = true,
                recom = ""
            };
            n1.HourSalary = double.Parse("30.5");
            n1.born = new DateTime(1990, 3, 20);
            n1.floor = FLOORS.Fourth;
            n1.DaysOfWork[0] = true;
            n1.schedule[0, 0] = DateTime.Parse("8:00");
            n1.schedule[1, 0] = DateTime.Parse("16:00");
            bl.addNanny(n1);
            #endregion//adding Nanny
            #region init for debugging
            Mother m1 = new Mother()
            {
                id = int.Parse("2222"),
                lName = "Lev",
                fName = "Nava",
                phone = "0523748738"
            ,
                address = "Jerusalem" + "," + "Yaffo" + "," + "4"
            ,
                note = ""
            };
            m1.nannyArea = 10;
            m1.needNanny[0] = true;
            m1.timeWork[0, 0] = DateTime.Parse("8:00");
            m1.timeWork[1, 0] = DateTime.Parse("16:00");
            bl.addMom(m1);
            Mother m2 = new Mother()
            {
                id = int.Parse("3333"),
                lName = "Ana",
                fName = "Fridman",
                phone = "0533232323"
            ,
                address = "Jerusalem" + "," + "Havaad Haleumi" + "," + "21"
            ,
                note = ""
            };
            m2.needNanny[0] = true;
            m2.timeWork[0, 0] = DateTime.Parse("8:00");
            m2.timeWork[1, 0] = DateTime.Parse("16:00");
            m2.nannyArea = 50;
            bl.addMom(m2);

            #endregion//Adding 2 Mothers
           

        }

      

        private void W_DoWork(object sender, DoWorkEventArgs e)
        {
          
          
          //  CheckingApiText.Text = x.ToString();
        }

        #region Adding Clicks

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
        #endregion

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

        #region Deleting Clicks

        private void DeleteNanny_Click(object sender, RoutedEventArgs e)
        {
            if (bl.GetAllNannies().Count() == 0)
                MessageBox.Show("There is no Nanny to delete");
            else
            {
                var v = new DeletingNanny();
                v.ShowDialog();
            }
        }

        private void DeleteMother_Click(object sender, RoutedEventArgs e)
        {
            if (bl.GetAllMothers().Count() == 0)
                MessageBox.Show("There is no Mother to delete");
            else
            {
                var v = new DeletingMother();
                v.ShowDialog();
            }
        }

        private void DeleteChild_Click(object sender, RoutedEventArgs e)
        {
            if (bl.GetAllChilds().Count() == 0)
                MessageBox.Show("There is no Child to delete");
            else
            {
                var v = new DeletingChild();
                v.ShowDialog();

            }
        }

        private void DeleteContract_Click(object sender, RoutedEventArgs e)
        {
            if (bl.GetAllContracts().Count() == 0)
                MessageBox.Show("There is no Contract to delete");
            else
            { 
            var v = new DeletingContracts();
            v.ShowDialog();
            }
        }
        #endregion

        private void Servers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Deletions_Click(object sender, RoutedEventArgs e)
        {
            var v = new DeletionsWindow();
            v.ShowDialog();
        }
    }
}
