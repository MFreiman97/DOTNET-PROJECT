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
using BE;
using BL;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for DeletionsWindow.xaml
    /// </summary>
 
    public partial class DeletionsWindow : MetroWindow
    {   BL.ourBL bl;
        public DeletionsWindow()
        {
            bl = new ourBL();
            InitializeComponent();
            listBoxChild.ItemsSource = bl.GetAllChilds();
            listBoxChild.DisplayMemberPath = "FullName";
            listBoxChild.SelectedValuePath= "id";
            dataGridContracts.ItemsSource = bl.GetAllContracts();
            dataGridContracts.SelectedValuePath = "contnum";
            listBoxMother.ItemsSource = bl.GetAllMothers();
            listBoxMother.DisplayMemberPath = "FullName";
            listBoxMother.SelectedValuePath = "id";


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxChild.SelectedValue != null)
            {
                try
                {
                    Child m = bl.GetChild((int)listBoxChild.SelectedValue);
                    bl.deleteChild(m);
                    listBoxChild.ItemsSource = bl.GetAllChilds();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridContracts.SelectedValue != null)
            {
                try
                {
                    Contract c = bl.GetContract((int)dataGridContracts.SelectedValue);
                    bl.deleteContract(c);
                    dataGridContracts.ItemsSource = bl.GetAllContracts();
                    dataGridContracts.SelectedValuePath = "contnum";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxMother.SelectedValue != null)
            {
                try
                {
                    Mother m = bl.GetMother((int)listBoxMother.SelectedValue);
                    bl.deleteMom(m);
                    listBoxMother.ItemsSource = bl.GetAllMothers();
                    listBoxMother.DisplayMemberPath = "FullName";
                    listBoxMother.SelectedValuePath = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
