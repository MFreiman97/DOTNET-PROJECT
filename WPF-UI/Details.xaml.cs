using BE;
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
using BL;
namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : MetroWindow
    {
        Child c;
        Nanny n;
        Contract co;
        Mother m;
        BL.ourBL bl;
        public Details(Object obj)
        {
            bl = new ourBL();
            InitializeComponent();
            if(obj is Child)
            {
                WhatToShowTB.Text = "Child";
                Child c = obj as Child;
                DetailsOfChild.DataContext = c;
            }
            if (obj is Mother)
            {
                WhatToShowTB.Text = "Mother";
                Mother m = obj as Mother;
             DetailsOfMother.DataContext = m;
            }
            if (obj is Nanny)
            {
                WhatToShowTB.Text = "Nanny";//using the trigger
                Nanny n = obj as Nanny;
              DetailsOfNanny.DataContext = n;
            }
            if (obj is Contract)
            {
                WhatToShowTB.Text = "Contract";//using the trigger
                Contract co = obj as Contract;
               DetailsOfContract.DataContext = co;
            }
        }
        #region Updating Mother
        private void UpdateMotherClicked(object sender, RoutedEventArgs e)
        {

            m = new Mother()
            {

                fName = fNameTextBox.Text,
                lName = lNameTextBox.Text,
                phone = phoneTextBox.Text
                 ,
                address = addressTextBox.Text
                 ,
                note = noteTextBox.Text,
                nannyArea = int.Parse(nannyAreaTextBox.Text)
            };
            bl.updateMom(m);

        }
       
        private void PhoneNumTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (phoneTextBox.Text.Any(char.IsLetter))
                {
                    phoneTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Numbers Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fNAMEtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (fNameTextBox.Text.Any(char.IsDigit))
                {
                    fNameTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lNameTextBox.Text.Any(char.IsDigit))
                {
                    lNameTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Address_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (addressTextBox.Text.Any(char.IsDigit))
                {
                    addressTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only Letters Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void NannyAREA_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nannyAreaTextBox.Text.Any(char.IsLetter))
                {
                    nannyAreaTextBox.Text = "";
                    throw new Exception("ERROR - Enter Only NUMBERS Please!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion 
     
      
        //private void UpdateChildClicked(object sender, RoutedEventArgs e)
        //{
        //    c= new Child() { 
      
        //        name = nameTextBox.Text,
        //        kindSpecial = kindSpecialTextBox.Text
        //    };
        //c.special= specialCheckBox.IsChecked.GetValueOrDefault();

        //    bl.updateChild(c);


        //}
        //private void UpdateContractClicked(object sender, RoutedEventArgs e)
        //{



        //}
        //private void UpdateNannyClicked(object sender, RoutedEventArgs e)
        



       
         

    }
}
