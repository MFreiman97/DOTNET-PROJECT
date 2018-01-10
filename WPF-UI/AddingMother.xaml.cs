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
            mother = new Mother();
            MyMatrix.ValueTimes = mother.timeWork;
            MyMatrix.ValueBool = mother.needNanny;

    
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





                mother.id = int.Parse(IDtextBox.Text);
                mother.lName = PNAMEtextBox.Text;
                mother.fName = FnameTextBox.Text;
                mother.phone = PhoneNumTextBox.Text;

                mother.address = CityTextBox.Text + "," + StreetTextBox.Text + "," + ApartmentTextBox.Text;
                mother.note = CommentsTextBox.Text;
                mother.nannyArea = int.Parse(NannyAreaTextBoxAnswer.Text);
             
                bl.addMom(mother);
                this.ShowMessageAsync("New Mother was added successfully!", "I assume that the mother add childrens -> lets add child!");
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
            MyMatrix.ValueTimes = mother.timeWork;
            MyMatrix.ValueBool = mother.needNanny;





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
