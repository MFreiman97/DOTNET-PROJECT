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
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for AddingNanny.xaml
    /// </summary>
    public partial class AddingNanny : Window
    {
        BL.ourBL bl;
       BE.Nanny nanny;

        public AddingNanny()
        {
            InitializeComponent();
            bl = new ourBL();
          
            nanny = new Nanny();
            this.DataContext = nanny;
            this.UpdateButton.IsEnabled = false;
            this.FloorComboBox.ItemsSource = Enum.GetValues(typeof(BE.FLOORS));
        }

        /// <summary>
        /// function that added to the event of the clicking that adding the nanny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NannyAdded_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                nanny.id = int.Parse(IDtextBox.Text); nanny.fname = fNametextBox.Text; nanny.name = lNametextBox.Text;
                nanny.cell = phoneNumbertextBox.Text; nanny.address = CitytextBox.Text + "," + StreettextBox.Text + "," + FlattextBox.Text;
                nanny.elevator = LiftCheckBox.IsChecked.GetValueOrDefault();
                nanny.experience = int.Parse(ExperienceextBox.Text);
                nanny.Maxkids = int.Parse(MaxKidstextBox.Text); nanny.MinAge = int.Parse(MinAgetextBox.Text);nanny.MaxAge = int.Parse(MaxAgetextBox.Text);
                nanny.SalaryPerHour = SalaryPerHourCheckBox.IsChecked.GetValueOrDefault();
                nanny.HolidaysByTheGOV = HolidaysByGovCheckBox.IsChecked.GetValueOrDefault(); nanny.recom = RecommendationstextBox.Text;

                if (SalaryPerHourCheckBox.IsChecked == true)
                    nanny.HourSalary = double.Parse(HourSalarytextBox.Text);
                else
                    nanny.MonthSalary = double.Parse(MonthSalarytextBox.Text);
                // Indicating What Days The Nanny Works
                nanny.DaysOfWork[0] = sunday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[1] = monday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[2] = tuesday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[3] = wednesday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[4] = thursday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[5] = friday.IsChecked.GetValueOrDefault();

                // Sunday
                if (nanny.DaysOfWork[0] == true)
                {
                    nanny.schedule[0, 0] = DateTime.Parse(start1.Text);
                    nanny.schedule[1, 0] = DateTime.Parse(end1.Text);
                }
                // Monday
                if (nanny.DaysOfWork[1] == true)
                {
                    nanny.schedule[0, 1] = DateTime.Parse(start2.Text);
                    nanny.schedule[1, 1] = DateTime.Parse(end2.Text);
                }
                // Teusday
                if (nanny.DaysOfWork[2] == true)
                {
                    nanny.schedule[0, 2] = DateTime.Parse(start3.Text);
                    nanny.schedule[1, 2] = DateTime.Parse(end3.Text);
                }
                // Wednesday
                if (nanny.DaysOfWork[3] == true)
                {
                    nanny.schedule[0, 3] = DateTime.Parse(start4.Text);
                    nanny.schedule[1, 3] = DateTime.Parse(end4.Text);
                }
                // Thursday
                if (nanny.DaysOfWork[4] == true)
                {
                    nanny.schedule[0, 4] = DateTime.Parse(start5.Text);
                    nanny.schedule[1, 4] = DateTime.Parse(end5.Text);
                }
                // Friday
                if (nanny.DaysOfWork[5] == true)
                {
                    nanny.schedule[0, 5] = DateTime.Parse(start6.Text);
                    nanny.schedule[1, 5] = DateTime.Parse(end6.Text);
                }
                
                this.DataContext = nanny;
                bl.addNanny(nanny);
               this. Close();
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
                nanny.DaysOfWork[0] = sunday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[1] = monday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[2] = tuesday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[3] = wednesday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[4] = thursday.IsChecked.GetValueOrDefault();
                nanny.DaysOfWork[5] = friday.IsChecked.GetValueOrDefault();

                // Sunday
                if (nanny.DaysOfWork[0] == true)
                {
                    nanny.schedule[0, 0] = DateTime.Parse(start1.Text);
                    nanny.schedule[1, 0] = DateTime.Parse(end1.Text);
                }
                // Monday
                if (nanny.DaysOfWork[1] == true)
                {
                    nanny.schedule[0, 1] = DateTime.Parse(start2.Text);
                    nanny.schedule[1, 1] = DateTime.Parse(end2.Text);
                }
                // Teusday
                if (nanny.DaysOfWork[2] == true)
                {
                    nanny.schedule[0, 2] = DateTime.Parse(start3.Text);
                    nanny.schedule[1, 2] = DateTime.Parse(end3.Text);
                }
                // Wednesday
                if (nanny.DaysOfWork[3] == true)
                {
                    nanny.schedule[0, 3] = DateTime.Parse(start4.Text);
                    nanny.schedule[1, 3] = DateTime.Parse(end4.Text);
                }
                // Thursday
                if (nanny.DaysOfWork[4] == true)
                {
                    nanny.schedule[0, 4] = DateTime.Parse(start5.Text);
                    nanny.schedule[1, 4] = DateTime.Parse(end5.Text);
                }
                // Friday
                if (nanny.DaysOfWork[5] == true)
                {
                    nanny.schedule[0, 5] = DateTime.Parse(start6.Text);
                    nanny.schedule[1, 5] = DateTime.Parse(end6.Text);
                }

                this.DataContext = nanny;
                bl.updateNanny(nanny);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
       
    }
}
