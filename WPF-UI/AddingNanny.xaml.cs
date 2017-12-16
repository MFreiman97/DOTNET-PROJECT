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
                n1.born =new DateTime( 1990,3,20);
            n1.floor = FLOORS.Fourth;
                n1.DaysOfWork[0] = true;
                n1.schedule[0, 0] = DateTime.Parse("8:00");
                n1.schedule[1, 0] = DateTime.Parse("16:00");
                bl.addNanny(n1);
                #endregion
         
            this.DataContext = nanny;
            this.UpdateButton.IsEnabled = false;
            this.FloorComboBox.ItemsSource = Enum.GetValues(typeof(BE.FLOORS));
        }

        private void NannyAdded_Click(object sender, RoutedEventArgs e)
        {

            try
            {
             
                nanny = new Nanny() { id = int.Parse(IDtextBox.Text), fname = fNametextBox.Text, name = lNametextBox.Text,
                  cell = phoneNumbertextBox.Text, address = CitytextBox.Text + "," + StreettextBox.Text + "," + FlattextBox.Text,
                    elevator = LiftCheckBox.IsChecked.GetValueOrDefault(),
                  experience = int.Parse(ExperienceextBox.Text),
                    Maxkids = int.Parse(MaxKidstextBox.Text), MinAge = int.Parse(MinAgetextBox.Text), MaxAge = int.Parse(MaxAgetextBox.Text),
                    SalaryPerHour = SalaryPerHourCheckBox.IsChecked.GetValueOrDefault(), 
                    HolidaysByTheGOV = HolidaysByGovCheckBox.IsChecked.GetValueOrDefault(), recom = RecommendationstextBox.Text};

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

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

       
    }
}
