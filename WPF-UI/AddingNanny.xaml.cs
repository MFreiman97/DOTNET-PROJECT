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
        ourBL bl;
        Nanny nanny;

        public AddingNanny()
        {
            InitializeComponent();
            bl = new ourBL();
            this.DataContext = nanny;
            this.UpdateButton.IsEnabled = false;
            FloorComboBox.Items.Add(new ComboBoxItem() { Content = "Zero" });
            FloorComboBox.Items.Add(new ComboBoxItem() { Content = "First" });
            FloorComboBox.Items.Add(new ComboBoxItem() { Content = "Second" });
            FloorComboBox.Items.Add(new ComboBoxItem() { Content = "Third" });
            FloorComboBox.Items.Add(new ComboBoxItem() { Content = "Fourth" });
            FloorComboBox.Items.Add(new ComboBoxItem() { Content = "Fifth" });
            FloorComboBox.Items.Add(new ComboBoxItem() { Content = "Sixth" });
            FloorComboBox.Items.Add(new ComboBoxItem() { Content = "Seventh" });
        }

        private void NannyAdded_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                nanny = new Nanny() { id = int.Parse(IDtextBox.Text), Fname = fNametextBox.Text, Name = lNametextBox.Text,
                    Born = DateTime.Parse(BorntextBox.Text), cell = phoneNumbertextBox.Text, address = CitytextBox.Text + "," + StreettextBox.Text + "," + FlattextBox.Text,
                    elevator = LiftCheckBox.IsChecked.GetValueOrDefault(),
                    floor = (FLOORS)Enum.Parse(typeof(FLOORS), FloorComboBox.Text), experience = int.Parse(ExperienceextBox.Text),
                    Maxkids = int.Parse(MaxKidstextBox.Text), MinAge = int.Parse(MinAgetextBox.Text), MaxAge = int.Parse(MaxAgetextBox.Text),
                    SalaryPerHour = SalaryPerHourCheckBox.IsChecked.GetValueOrDefault(), HourSalary = double.Parse(HourSalarytextBox.Text), MonthSalary = double.Parse(MonthSalarytextBox.Text),
                    HolidaysByTheGOV = HolidaysByGovCheckBox.IsChecked.GetValueOrDefault(), recom = RecommendationstextBox.Text};

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
                    nanny.schedule[0, 0] = int.Parse(start1.Text);
                    nanny.schedule[1, 0] = int.Parse(end1.Text);
                }
                // Monday
                if (nanny.DaysOfWork[1] == true)
                {
                    nanny.schedule[0, 1] = int.Parse(start1.Text);
                    nanny.schedule[1, 1] = int.Parse(end1.Text);
                }
                // Teusday
                if (nanny.DaysOfWork[2] == true)
                {
                    nanny.schedule[0, 2] = int.Parse(start1.Text);
                    nanny.schedule[1, 2] = int.Parse(end1.Text);
                }
                // Wednesday
                if (nanny.DaysOfWork[3] == true)
                {
                    nanny.schedule[0, 3] = int.Parse(start1.Text);
                    nanny.schedule[1, 3] = int.Parse(end1.Text);
                }
                // Thursday
                if (nanny.DaysOfWork[4] == true)
                {
                    nanny.schedule[0, 4] = int.Parse(start1.Text);
                    nanny.schedule[1, 4] = int.Parse(end1.Text);
                }
                // Friday
                if (nanny.DaysOfWork[5] == true)
                {
                    nanny.schedule[0, 5] = int.Parse(start1.Text);
                    nanny.schedule[1, 5] = int.Parse(end1.Text);
                }


                bl.addNanny(nanny);
                Close();
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
                Fname = fNametextBox.Text,
                Name = lNametextBox.Text,
                Born = DateTime.Parse(BorntextBox.Text),
                cell = phoneNumbertextBox.Text,
                address = CitytextBox.Text + "," + StreettextBox.Text + "," + FlattextBox.Text,
                elevator = LiftCheckBox.IsChecked.GetValueOrDefault(),
                floor = (FLOORS)Enum.Parse(typeof(FLOORS),FloorComboBox.Text),
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
                nanny.schedule[0, 0] = int.Parse(start1.Text);
                nanny.schedule[1, 0] = int.Parse(end1.Text);
            }
            // Monday
            if (nanny.DaysOfWork[1] == true)
            {
                nanny.schedule[0, 1] = int.Parse(start1.Text);
                nanny.schedule[1, 1] = int.Parse(end1.Text);
            }
            // Teusday
            if (nanny.DaysOfWork[2] == true)
            {
                nanny.schedule[0, 2] = int.Parse(start1.Text);
                nanny.schedule[1, 2] = int.Parse(end1.Text);
            }
            // Wednesday
            if (nanny.DaysOfWork[3] == true)
            {
                nanny.schedule[0, 3] = int.Parse(start1.Text);
                nanny.schedule[1, 3] = int.Parse(end1.Text);
            }
            // Thursday
            if (nanny.DaysOfWork[4] == true)
            {
                nanny.schedule[0, 4] = int.Parse(start1.Text);
                nanny.schedule[1, 4] = int.Parse(end1.Text);
            }
            // Friday
            if (nanny.DaysOfWork[5] == true)
            {
                nanny.schedule[0, 5] = int.Parse(start1.Text);
                nanny.schedule[1, 5] = int.Parse(end1.Text);
            }


            bl.updateNanny(nanny);
        }

        private void FloortextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox && ((ComboBox)sender).SelectedIndex > -1)
            {
                ComboBox comboBox = (ComboBox)sender;
                object si = comboBox.SelectedItem;
                nanny.floor = (FLOORS)Enum.Parse(typeof(FLOORS), FloorComboBox.Text);
                //        ComboBox comboBox = (ComboBox)sender;
                //        //var = FloorComboBox.Text;
                //      var  g = (FLOORS)Enum.Parse(typeof(FLOORS), (string)comboBox.SelectedItem);
                //    MessageBox.Show(g);
            }
        }

        private FLOORS GetSelectedFloor()
        {
            object result = FloorComboBox.SelectedValue;

            if (result == null)
                throw new Exception("Must Select Floor First");
            return (FLOORS)result;
        }
    }
}
