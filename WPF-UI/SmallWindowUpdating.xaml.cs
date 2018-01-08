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

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for SmallWindowUpdating.xaml
    /// </summary>
    public partial class SmallWindowUpdating : MetroWindow
    {
        Child c;
        Nanny n;
        Contract co;
        Mother m;
        BL.IBL bl;
        public SmallWindowUpdating(object obj)
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            if (obj is Child)
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
    }
   public class MyClass:DependencyObject
    {


        public string MyProperty
        {
            get { return (string)GetValue(MyPropertyProperty); }
          
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MyClass), new PropertyMetadata("", PropertyChangedCallback));
        public static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var THIS = d as TextBox;
       


        }


    }
}
