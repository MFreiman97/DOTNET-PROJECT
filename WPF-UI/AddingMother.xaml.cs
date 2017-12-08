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
            bl = new ourBL();
           
        }

        private void MotherAdded_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mother = new Mother() {id=int.Parse(IDtextBox.Text),lName= PNAMEtextBox.Text,fName= FnameTextBox.Text,phone= PhoneNumTextBox.Text };
                bl.addMom(mother);
                // student = new BE.Student();
                this.DataContext = mother;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
