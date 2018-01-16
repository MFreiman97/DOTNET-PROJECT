﻿using System;
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
        BL.IBL bl;
        int x;
       
        public MainWindow()
        {
            InitializeComponent();

            bl = BL.FactoryBL.GetBL();
            this.Closing += MainWindow_Closing;
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
            n1.schedule[0][ 0] = TimeSpan.Parse("8:00");
            n1.schedule[1][ 0] = TimeSpan.Parse("16:00");

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
            m1.timeWork[0][ 0] = TimeSpan.Parse("8:00");
            m1.timeWork[1][ 0] = TimeSpan.Parse("15:20");
            bl.addMom(m1);
            Mother m2 = new Mother()
            {
                id = int.Parse("3333"),
                lName = "Fridman",
                fName = "Ana",
                phone = "0533232323"
            ,
                address = "Kiryat Atta" + "," + "Pinsker" + "," + "6"
            ,
                note = ""
            };
            m2.needNanny[0] = true;
            m2.timeWork[0][ 0] = TimeSpan.Parse("8:00");
            m2.timeWork[1][ 0] = TimeSpan.Parse("16:00");
            m2.nannyArea = 200;
            bl.addMom(m2);
           m1 = new Mother()
            {
                id = int.Parse("4444"),
                lName = "Levy",
                fName = "Lea",
                phone = "0523774828"
          ,
                address = "Jerusalem" + "," + "Yaffo" + "," + "40"
          ,
                note = ""
            };
            m1.nannyArea = 30;
            m1.needNanny[0] = true;
            m1.timeWork[0][ 0] = TimeSpan.Parse("8:00");
            m1.timeWork[1][ 0] = TimeSpan.Parse("16:00");
            bl.addMom(m1);
            #endregion//Adding 2 Mothers
            #region init CHILDS FOR DEBUGGING
            Child ch = new Child();
            ch.birth = DateTime.Now.AddYears(-1);

            ch.mom = bl.GetMother(2222);

            ch.momId = (2222);
            ch.id = int.Parse("74382");

            ch.kindSpecial = "";
            ch.special = true;
            ch.name = "Miki";
            bl.addChild(ch);
            ch = new Child();
            ch.birth = DateTime.Now.AddYears(-1);
            ch.birth = ch.birth.AddDays(2);
            ch.mom = bl.GetMother(3333);
            ch.id = int.Parse("728429");
            ch.momId = (3333);
            ch.name = "Yanki";
            ch.kindSpecial = "";
            ch.special = false;
            bl.addChild(ch);

            ch = new Child();
            ch.birth = DateTime.Now.AddYears(-1);
            ch.birth = ch.birth.AddDays(20);
            ch.mom = bl.GetMother(2222);
            ch.id = int.Parse("542352");
            ch.momId = (2222);
            ch.name = "Moshe";
            ch.kindSpecial = "";
            ch.special = true;
            bl.addChild(ch);



            #endregion
         
            comboBoxWhatToUpdate.Items.Add(new ComboBoxItem() { Content = "childs" });
            comboBoxWhatToUpdate.Items.Add(new ComboBoxItem() { Content = "contracts" });
            comboBoxWhatToUpdate.Items.Add(new ComboBoxItem() { Content = "mothers" });
            comboBoxWhatToUpdate.Items.Add(new ComboBoxItem() { Content = "nannies" });
     
     

        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);

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

      

        private void LinqButton_Click(object sender, RoutedEventArgs e)
        {
            var v = new Linq();
            v.ShowDialog();
        }

       
        private void Deletions_Click(object sender, RoutedEventArgs e)
        {
            var v = new DeletionsWindow();
            v.ShowDialog();
        }

        private void ComboBoxChanged(object sender, RoutedEventArgs e)
        {
            dataGridChild.ItemsSource = null;
            dataGridChild.ItemsSource = bl.GetAllChilds();
           dataGridChild.DataContext = bl.GetAllChilds();
         
            dataGridChild.SelectedValuePath = "id";

            dataGridContract.ItemsSource = null;
            dataGridContract.ItemsSource = bl.GetAllContracts();
            dataGridContract.SelectedValuePath = "contnum";

            dataGridNanny.ItemsSource = null;
            dataGridNanny.ItemsSource = bl.GetAllNannies();
            dataGridNanny.DisplayMemberPath = "FullName";
            dataGridNanny.SelectedValuePath = "id";

            dataGridMother.ItemsSource = null;
            dataGridMother.ItemsSource = bl.GetAllMothers();
            dataGridMother.DisplayMemberPath = "FullName";
            dataGridMother.SelectedValuePath = "id";

       
        }
     

        private void DoubleClickedOnChild(object sender, MouseButtonEventArgs e)
        {
            if (dataGridChild.SelectedValue != null)
            {
                try
                {
                    var v = new SmallWindowUpdating((object)dataGridChild.SelectedItem);
        
              
                    v.ShowDialog();
                    refresh();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
      public  void refresh()
        {
         dataGridChild.ItemsSource = null;
            dataGridChild.ItemsSource = bl.GetAllChilds();
            dataGridChild.DataContext = bl.GetAllChilds();

            dataGridChild.SelectedValuePath = "id";

            dataGridContract.ItemsSource = null;
            dataGridContract.ItemsSource = bl.GetAllContracts();
            dataGridContract.SelectedValuePath = "contnum";

            dataGridNanny.ItemsSource = null;
            dataGridNanny.ItemsSource = bl.GetAllNannies();
            dataGridNanny.DisplayMemberPath = "FullName";
            dataGridNanny.SelectedValuePath = "id";

            dataGridMother.ItemsSource = null;
            dataGridMother.ItemsSource = bl.GetAllMothers();
            dataGridMother.DisplayMemberPath = "FullName";
            dataGridMother.SelectedValuePath = "id";

        }

        private void DoubleClickedOnMother(object sender, MouseButtonEventArgs e)
        {
            if (dataGridMother.SelectedValue != null)
            {
                try
                {
                    var v = new SmallWindowUpdating((object)dataGridMother.SelectedItem);
                    v.ShowDialog();
                    refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DoubleClickedOnContract(object sender, MouseButtonEventArgs e)
        {
            if (dataGridContract.SelectedValue != null)
            {
                try
                {
                    var v = new UpdateContract((object)dataGridContract.SelectedItem as Contract);
                    v.ShowDialog();
                    refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DoubleClickedOnNanny(object sender, MouseButtonEventArgs e)
        {
            if (dataGridNanny.SelectedValue != null)
            {
                try
                {
                    var v = new SmallWindowUpdating((object)dataGridNanny.SelectedItem);
                    v.ShowDialog();
                    refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Information_Click(object sender, RoutedEventArgs e)
        {
            if (InformationFlyout.IsOpen == false) InformationFlyout.IsOpen = true;
            else InformationFlyout.IsOpen = false;
        }

       
    }
}
