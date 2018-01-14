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
            for (int i = 0; i < 2; i++)
            {
                ValueTimes[i] = new TimeSpan[6];
            }
            DataContext = this;
        }
  


        public TimeSpan[][] ValueTimes   
        {
            get { return (TimeSpan[][])GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("ValueTimes", typeof(TimeSpan[][]), typeof(MatrixOfHours), new PropertyMetadata(new TimeSpan[2][]));


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
