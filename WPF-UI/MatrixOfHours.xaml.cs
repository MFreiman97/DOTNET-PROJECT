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

            tp00.DataContext = Value[0, 0];
      tp01.DataContext = Value[1, 0];
            tp10.DataContext = Value[0, 1];
            tp11.DataContext = Value[1, 1];
            tp20.DataContext = Value[0, 2];
            tp21.DataContext = Value[1, 2];
            tp30.DataContext = Value[0, 3];
            tp31.DataContext = Value[1, 3];
            tp40.DataContext = Value[0, 4];
            tp41.DataContext = Value[1, 4];
            tp50.DataContext = Value[0, 5];
            tp51.DataContext = Value[1, 5];

        }
  


        public DateTime[,] Value
        {
            get { return (DateTime[,])GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(DateTime[,]), typeof(MatrixOfHours), new PropertyMetadata(new DateTime[6,6]));


    }
}
