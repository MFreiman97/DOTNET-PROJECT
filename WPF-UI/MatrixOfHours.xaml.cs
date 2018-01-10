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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MatrixOfHours.xaml
    /// </summary>
    public partial class MatrixOfHours : UserControl
    {
        public MatrixOfHours()
        {
            InitializeComponent();

            tp00.DataContext = ValueTimes[0, 0];
      tp01.DataContext = ValueTimes[1, 0];
            tp10.DataContext = ValueTimes[0, 1];
            tp11.DataContext = ValueTimes[1, 1];
            tp20.DataContext = ValueTimes[0, 2];
            tp21.DataContext = ValueTimes[1, 2];
            tp30.DataContext = ValueTimes[0, 3];
            tp31.DataContext = ValueTimes[1, 3];
            tp40.DataContext = ValueTimes[0, 4];
            tp41.DataContext = ValueTimes[1, 4];
            tp50.DataContext = ValueTimes[0, 5];
            tp51.DataContext = ValueTimes[1, 5];
            sunday.DataContext = ValueBool[0];
            monday.DataContext = ValueBool[1];
            tuesday.DataContext = ValueBool[2];
            wednesday.DataContext = ValueBool[3];
            thursday.DataContext = ValueBool[4];
            friday.DataContext = ValueBool[5];
        }
  


        public DateTime[,] ValueTimes   
        {
            get { return (DateTime[,])GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("ValueTimes", typeof(DateTime[,]), typeof(MatrixOfHours), new PropertyMetadata(new DateTime[6,6]));


        public bool[] ValueBool
        {
            get { return (bool[])GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("ValueBool", typeof(bool[]), typeof(MatrixOfHours), new PropertyMetadata(new bool[6]));



    }
}
