using BE;
using BL;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
    /// Interaction logic for AddingChild.xaml
    /// </summary>
    public partial class AddingChild : MetroWindow
    {
        BE.Child ch;
        BL.IBL bl;
        public AddingChild()
        {
            InitializeComponent();

            bl = BL.FactoryBL.GetBL();
            ch = new Child();
            this.DataContext = ch;//to allow binding connection
            ch.birth = DateTime.Now;
            this.UpdateButton.IsEnabled = false;
            comboBoxBool.Items.Add(new ComboBoxItem() { Content = "Yes" });
            comboBoxBool.Items.Add(new ComboBoxItem() { Content = "No" });
            comboBoxMothers.ItemsSource = bl.GetAllMothers();
            comboBoxMothers.DisplayMemberPath = "FullName";//the combobox will display the Full NAME of the Mothers 
            comboBoxMothers.SelectedValuePath = "id";//the selected value is the id of the mother



        }
        /// <summary>
        /// This function added to the event of the clicking on the button. the details that entered will be inserted to the object of the child and the child will be inserted to the repository 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildAdded_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ch.mom = bl.GetMother((int)comboBoxMothers.SelectedValue);
                ch.id = int.Parse(IDtextBox.Text);
                ch.momId = ((int)comboBoxMothers.SelectedValue);
                ch.name = NAMEtextBox.Text;
                ch.kindSpecial = DescOfDisabilityTextBox.Text;
               
               
                if (comboBoxBool.Text == "Yes")
                    ch.special = true;
                else
                    ch.special = false;

             
                bl.addChild(ch);
                this.ShowMessageAsync("New Child was added successfully!", "Now you can add contract to the child");
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (ex.Message == "the Child you tried to add already exist!")
                {
                    this.UpdateButton.IsEnabled = true;
                    this.IDtextBox.IsEnabled = false;
                }
            }
            


        }
        /// <summary>
        ///if the id that inserted in the textbox is belonged to existing Child .the updating oppurtunity is enabling .this function inserting the element by the terms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            ch = new Child()
            {
                mom = bl.GetMother(int.Parse(comboBoxMothers.Text)),
                id = int.Parse(IDtextBox.Text),
                momId = int.Parse(comboBoxMothers.Text),
                name = NAMEtextBox.Text,
                kindSpecial = DescOfDisabilityTextBox.Text
            };
            if (comboBoxBool.Text == "Yes")
                ch.special = true;
            else
                ch.special = false;


            bl.updateChild(ch);
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

        private void NAMEtextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NAMEtextBox.Text.Any(char.IsDigit))
                {
                    NAMEtextBox.Text = "";
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

