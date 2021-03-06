﻿using System;
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
using BE;
using BL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading;


namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for AddingNanny.xaml
    /// </summary>
    public partial class AddingNanny : MetroWindow
    {
       BL.IBL bl;
       BE.Nanny nanny;

        public AddingNanny()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();

            nanny = new Nanny();
            this.DataContext = nanny;
            nanny.born = DateTime.Parse("07/09/97");
    
            BornDatePicker.DisplayDateEnd = DateTime.Now;
            this.UpdateButton.IsEnabled = false;
            this.FloorComboBox.ItemsSource = Enum.GetValues(typeof(BE.FLOORS));
        }

        /// <summary>
        /// function that added to the event of the clicking that adding the nanny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NannyAdded_Click(object sender, RoutedEventArgs e)
        {

            try
            {
       nanny.schedule = MyMatrixNanny.ValueTimes;
         nanny.DaysOfWork = MyMatrixNanny.ValueBool;

                nanny.id = int.Parse(IDtextBox.Text); nanny.fname = fNametextBox.Text; nanny.name = lNametextBox.Text;
                nanny.cell = phoneNumbertextBox.Text; nanny.address = CitytextBox.Text + "," + StreettextBox.Text + "," + FlattextBox.Text;
                nanny.elevator = LiftCheckBox.IsChecked.GetValueOrDefault();
                nanny.experience = int.Parse(ExperienceextBox.Text);
                nanny.Maxkids = int.Parse(MaxKidstextBox.Text); nanny.MinAge = int.Parse(MinAgetextBox.Text); nanny.MaxAge = int.Parse(MaxAgetextBox.Text);
                nanny.SalaryPerHour = SalaryPerHourCheckBox.IsChecked.GetValueOrDefault();
                nanny.HolidaysByTheGOV = HolidaysByGovCheckBox.IsChecked.GetValueOrDefault(); nanny.recom = RecommendationstextBox.Text;

                if (SalaryPerHourCheckBox.IsChecked == true)
                    nanny.HourSalary = double.Parse(HourSalarytextBox.Text);
                else
                    nanny.MonthSalary = double.Parse(MonthSalarytextBox.Text);
                // Indicating What Days The Nanny Works

                this.DataContext = nanny;
                Thread t = new Thread(() => bl.addNanny(nanny));
                bl.addNanny(nanny);
                var Message = await this.ShowMessageAsync("New Nanny was added successfully!", "");

                if (Message == MessageDialogResult.Affirmative)
                    this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (ex.Message == "the Nanny you tried to add already exist!")
                {
                    this.UpdateButton.IsEnabled = true;
                    this.IDtextBox.IsEnabled = false;
                }
            }

        }

        /// <summary>
        /// if the id that inserted in the textbox is belonged to existing nanny .the updating oppurtunity is enabling this function inserting the element by the terms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nanny = new Nanny()
                {
                    id = int.Parse(IDtextBox.Text),
                    fname = fNametextBox.Text,
                    name = lNametextBox.Text,

                    cell = phoneNumbertextBox.Text,
                    address = CitytextBox.Text + "," + StreettextBox.Text + "," + FlattextBox.Text,
                    elevator = LiftCheckBox.IsChecked.GetValueOrDefault(),

                    experience = int.Parse(ExperienceextBox.Text),
                    Maxkids = int.Parse(MaxKidstextBox.Text),
                    MinAge = int.Parse(MinAgetextBox.Text),
                    MaxAge = int.Parse(MaxAgetextBox.Text),
                    SalaryPerHour = SalaryPerHourCheckBox.IsChecked.GetValueOrDefault(),
                    HourSalary = double.Parse(HourSalarytextBox.Text),
                    MonthSalary = double.Parse(MonthSalarytextBox.Text),
                    HolidaysByTheGOV = HolidaysByGovCheckBox.IsChecked.GetValueOrDefault(),
                    recom = RecommendationstextBox.Text,
                };

                // Indicating What Days The Nanny Works
              

                this.DataContext = nanny;
                bl.updateNanny(nanny);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    
       

        private void IDtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IDtextBox.Text.Any(char.IsLetter))
                {
                    IDtextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Numbers Please!");
                }
                if (IDtextBox.Text.Length != 9)
                    throw new Exception("ERROR - Enter Nine Digits Please!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fNametextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (fNametextBox.Text.Any(char.IsDigit))
                {
                    fNametextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lNametextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lNametextBox.Text.Any(char.IsDigit))
                {
                    lNametextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void phoneNumbertextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (phoneNumbertextBox.Text.Any(char.IsLetter))
                {
                    phoneNumbertextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Numbers Please!");
                }
                if (phoneNumbertextBox.Text.Length != 10)
                    throw new Exception("ERROR - Enter Ten Digits Please!");
                if (phoneNumbertextBox.Text[0] != '0' || phoneNumbertextBox.Text[1] != '5')
                    throw new Exception("ERROR - Enter Valid Number Please!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CitytextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CitytextBox.Text.Any(char.IsDigit))
                {
                    CitytextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StreettextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StreettextBox.Text.Any(char.IsDigit))
                {
                    StreettextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
