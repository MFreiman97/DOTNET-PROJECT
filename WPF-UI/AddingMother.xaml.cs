using BE;
using BL;
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

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for AddingMother.xaml
    /// </summary>
    public partial class AddingMother : Window
    {
        BL.ourBL bl;
        BE.Mother mother;
        public AddingMother()
        {
            InitializeComponent();  
         
            this.UpdateButton.IsEnabled = false;
            bl = new ourBL();  
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

       
    }
}
