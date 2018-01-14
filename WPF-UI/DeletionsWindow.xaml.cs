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
using MahApps.Metro.Controls.Dialogs;
using System.Globalization;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for DeletionsWindow.xaml
    /// </summary>

    public partial class DeletionsWindow : MetroWindow
    {
        BL.IBL bl;
        public DeletionsWindow()
        {
            bl = BL.FactoryBL.GetBL();
            InitializeComponent();
            dataGridChilds.ItemsSource = bl.GetAllChilds();
            dataGridChilds.SelectedValuePath = "id";


            dataGridContracts.ItemsSource = bl.GetAllContracts();
            dataGridContracts.SelectedValuePath = "contnum";

            dataGridMothers.ItemsSource = bl.GetAllMothers();
            dataGridMothers.SelectedValuePath = "id";

            dataGridNannies.ItemsSource = bl.GetAllNannies();
            dataGridNannies.SelectedValuePath = "id";

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridChilds.SelectedValue != null)
            {
                try
                {
                    Child m = bl.GetChild((int)dataGridChilds.SelectedValue);
                    bl.deleteChild(m);
                    dataGridChilds.ItemsSource = null;
                    dataGridChilds.ItemsSource = bl.GetAllChilds();
                    this.ShowMessageAsync("New Child was deleted successfully!", "");
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
                    dataGridContracts.ItemsSource = null;
                    dataGridContracts.ItemsSource = bl.GetAllContracts();
                    this.ShowMessageAsync("New Contract was deleted successfully!", "");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMothers.SelectedValue != null)
            {
                try
                {
                    Mother m = bl.GetMother((int)dataGridMothers.SelectedValue);
                    bl.deleteMom(m);
                    dataGridMothers.ItemsSource = null;//neccesary!!!!
                    dataGridMothers.ItemsSource = bl.GetAllMothers();
                    this.ShowMessageAsync("New Mother was deleted successfully!", "");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMothers.SelectedValue != null)
            {
                try
                {
                    Nanny n = bl.GetNanny((int)dataGridNannies.SelectedValue);
                    bl.deleteNanny(n);
                    dataGridNannies.ItemsSource = null;//neccesary!!!!
                    dataGridNannies.ItemsSource = bl.GetAllNannies();
                    this.ShowMessageAsync("New Nanny was deleted successfully!", "");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridMothers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridMothers.SelectedValue != null)
            {
                try
                {
                    var v = new Details((object)dataGridMothers.SelectedItem);
                    v.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridNannies_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridNannies.SelectedValue != null)
            {
                try
                {
                    var v = new Details((object)dataGridNannies.SelectedItem);
                    v.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridContracts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridContracts.SelectedValue != null)
            {
                try
                {
                    var v = new Details((object)dataGridContracts.SelectedItem);
                    v.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridChilds_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridChilds.SelectedValue != null)
            {
                try
                {
                    var v = new Details((object)dataGridChilds.SelectedItem);
                    v.ShowDialog();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MapMother_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridMothers.SelectedValue != null)
            {
                try
                {
                    Mother m = bl.GetMother((int)dataGridMothers.SelectedValue);
                    var v = new MapWindow(m);
                    v.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MapNanny_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridNannies.SelectedValue != null)
            {
                try
                {
                    Nanny n = bl.GetNanny((int)dataGridNannies.SelectedValue);
                    var v = new MapWindow(n);
                    v.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
    public class IDChildToName : IValueConverter
        {
            IBL bl = FactoryBL.GetBL();

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                Child c = bl.GetChild((int)value);
              
                    return c.FullName;
               
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    public class IDNannyToName : IValueConverter
    {
        IBL bl = FactoryBL.GetBL();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Nanny n = bl.GetNanny((int)value);

            return n.FullName;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

