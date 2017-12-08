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
    /// Interaction logic for AddingChild.xaml
    /// </summary>
    public partial class AddingChild : Window
    {
        Child ch;
        BL.IBL bl;
        public AddingChild()
        {
            InitializeComponent();
            ch = new Child();
            bl = new ourBL();
            this.DataContext = ch;
            comboBoxBool.Items.Add( new ComboBoxItem() { Content = "Yes" });
            comboBoxBool.Items.Add(new ComboBoxItem() { Content = "No" });
            foreach(var item in bl.GetAllMothers())
            {
                comboBoxMothers.Items.Add(new ComboBoxItem() { Content = item.id  });
            }
        }

        private void ChildAdded_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ch.mom = bl.GetMother(int.Parse(comboBoxMothers.SelectedValue.ToString()));
                bl.addChild(ch);
             // student = new BE.Student();
                this.DataContext = ch;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
    }

