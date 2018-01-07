using BE;
using BL;
using MahApps.Metro.Controls;
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
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for AddingMother.xaml
    /// </summary>
    public partial class AddingMother : MetroWindow
    {
        BL.IBL bl;
        BE.Mother mother;
        public AddingMother()
        {
            InitializeComponent();  
         
            this.UpdateButton.IsEnabled = false;
            bl = BL.FactoryBL.GetBL();


        }

        /// <summary>
        /// function that added to the event of the clicking that adding the mother
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MotherAdded_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            




                mother = new Mother() {id=int.Parse(IDtextBox.Text),lName= PNAMEtextBox.Text,fName= FnameTextBox.Text,phone= PhoneNumTextBox.Text
                ,address=CityTextBox.Text+","+StreetTextBox.Text+","+ApartmentTextBox.Text
                ,note=CommentsTextBox.Text
               ,nannyArea= int.Parse(NannyAreaTextBoxAnswer.Text)
                };
                mother.needNanny[0] = sunday.IsChecked.GetValueOrDefault();
                mother.needNanny[1] = monday.IsChecked.GetValueOrDefault();
                mother.needNanny[2] = tuesday.IsChecked.GetValueOrDefault();
                mother.needNanny[3] = wednesday.IsChecked.GetValueOrDefault();
                mother.needNanny[4] = thursday.IsChecked.GetValueOrDefault();
                mother.needNanny[5] = friday.IsChecked.GetValueOrDefault();
                
                    if(mother.needNanny[0]==true)
                    {
                        mother.timeWork[0, 0] = DateTime.Parse(start1.Text);
                        mother.timeWork[1, 0] = DateTime.Parse(end1.Text);
                    }

                if (mother.needNanny[1] == true)
                {
                    mother.timeWork[0,1] = DateTime.Parse(start2.Text);
                    mother.timeWork[1, 1] = DateTime.Parse(end2.Text);
                }
                if (mother.needNanny[2] == true)
                {
                    mother.timeWork[0, 2] = DateTime.Parse(start3.Text);
                    mother.timeWork[1, 2] = DateTime.Parse(end3.Text);
                }
                if (mother.needNanny[3] == true)
                {
                    mother.timeWork[0, 3] = DateTime.Parse(start4.Text);
                    mother.timeWork[1, 3] = DateTime.Parse(end4.Text);
                }
                if (mother.needNanny[4] == true)
                {
                    mother.timeWork[0, 4] = DateTime.Parse(start5.Text);
                    mother.timeWork[1, 4] = DateTime.Parse(end5.Text);
                }
                if (mother.needNanny[5] == true)
                {
                    mother.timeWork[0, 5] = DateTime.Parse(start6.Text);
                    mother.timeWork[1, 5] = DateTime.Parse(end6.Text);
                }




                bl.addMom(mother);
                this.Close(); 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if(ex.Message== "the Mother you tried to add already exist!")
                {
                    this.UpdateButton.IsEnabled = true;
                    this.IDtextBox.IsEnabled = false;
                }
            }

        }
        /// <summary>
        ///if the id that inserted in the textbox is belonged to existing mother .the updating oppurtunity is enabling this function inserting the element by the terms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            mother = new Mother()
            {
                id = int.Parse(IDtextBox.Text),
                fName = PNAMEtextBox.Text,
                lName = FnameTextBox.Text,
                phone = PhoneNumTextBox.Text
               ,
                address = CityTextBox.Text + "," + StreetTextBox.Text + "," + ApartmentTextBox.Text
               ,
                note = CommentsTextBox.Text,
                nannyArea = int.Parse(NannyAreaTextBoxAnswer.Text)
            };
            mother.needNanny[0] = sunday.IsChecked.GetValueOrDefault();
            mother.needNanny[1] = monday.IsChecked.GetValueOrDefault();
            mother.needNanny[2] = tuesday.IsChecked.GetValueOrDefault();
            mother.needNanny[3] = wednesday.IsChecked.GetValueOrDefault();
            mother.needNanny[4] = thursday.IsChecked.GetValueOrDefault();
            mother.needNanny[5] = friday.IsChecked.GetValueOrDefault();
            if (mother.needNanny[1] == true)
            {
                mother.timeWork[0, 1] = DateTime.Parse(start2.Text);
                mother.timeWork[1, 1] = DateTime.Parse(end2.Text);
            }
            if (mother.needNanny[2] == true)
            {
                mother.timeWork[0, 2] = DateTime.Parse(start3.Text);
                mother.timeWork[1, 2] = DateTime.Parse(end3.Text);
            }
            if (mother.needNanny[3] == true)
            {
                mother.timeWork[0, 3] = DateTime.Parse(start4.Text);
                mother.timeWork[1, 3] = DateTime.Parse(end4.Text);
            }
            if (mother.needNanny[4] == true)
            {
                mother.timeWork[0, 4] = DateTime.Parse(start5.Text);
                mother.timeWork[1, 4] = DateTime.Parse(end5.Text);
            }
            if (mother.needNanny[5] == true)
            {
                mother.timeWork[0, 5] = DateTime.Parse(start6.Text);
                mother.timeWork[1, 5] = DateTime.Parse(end6.Text);
            }





            bl.updateMom(mother);
            this.Close();
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

        private void PhoneNumTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PhoneNumTextBox.Text.Any(char.IsLetter))
                {
                    PhoneNumTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Numbers Please!");
                }
                if (PhoneNumTextBox.Text.Length != 10)
                    throw new Exception("ERROR - Enter Ten Digits Please!");
                if (PhoneNumTextBox.Text[0] != '0' || PhoneNumTextBox.Text[1] != '5')
                    throw new Exception("ERROR - Enter Valid Number Please!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PNAMEtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PNAMEtextBox.Text.Any(char.IsDigit))
                {
                    PNAMEtextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FnameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FnameTextBox.Text.Any(char.IsDigit))
                {
                    FnameTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CityTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CityTextBox.Text.Any(char.IsDigit))
                {
                    CityTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StreetTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StreetTextBox.Text.Any(char.IsDigit))
                {
                    StreetTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
