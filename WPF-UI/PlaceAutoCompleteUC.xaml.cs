using GoogleMapsApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for PlaceAutoCompleteUC.xaml
    /// </summary>
    public partial class PlaceAutoCompleteUC : UserControl
    {
        static string API_KEY = ConfigurationSettings.AppSettings.Get("googleApiKey");
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(PlaceAutoCompleteUC), new PropertyMetadata(null));


        public PlaceAutoCompleteUC()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        void run(object text)
        {
            if (text != null)
            {
                try
                {
                    List<string> result = GetPlaceAutoComplete(text.ToString());

                    Action<List<string>> action = setListInvok;
                    Dispatcher.BeginInvoke(action, new object[] { result });
                }
                catch (Exception)
                {


                }
            }
        }
        public static List<string> GetPlaceAutoComplete(string str)
        {
            List<string> result = new List<string>();
            GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest request = new GoogleMapsApi.Entities.PlaceAutocomplete.Request.PlaceAutocompleteRequest();
            request.ApiKey = API_KEY;
            request.Input = str;

            var response = GoogleMaps.PlaceAutocomplete.Query(request);

            foreach (var item in response.Results)
            {
                result.Add(item.Description);
            }

            return result;
        }
        private void setListInvok(List<string> list)
        {
            this.textComboBox.ItemsSource = null;

            if (list.Count > 0 && list[0].CompareTo(Text) != 0)
            {
                this.textComboBox.ItemsSource = list;
                textComboBox.IsDropDownOpen = true;
            }
            else
            {
                textComboBox.IsDropDownOpen = false;
            }
        }


        private void textInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Thread thread = new Thread(run);
            thread.Start(Text);
        }

        private void textComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = textComboBox.SelectedItem;
            if (item != null)
            {
                this.Text = item.ToString();
                textComboBox.IsDropDownOpen = false;
            }
        }



        private void textInput_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            {
                this.textComboBox.Focus();

            }
        }

        private void textComboBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Up)

                if (this.textComboBox.SelectedIndex == 0)
                    this.textInput.Focus();
        }
    }
}
