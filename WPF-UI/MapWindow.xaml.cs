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
using Microsoft.Maps.MapControl.WPF;
using GoogleMapsGeocoding;
using BE;


using Microsoft.Maps.MapControl.WPF.Design;
using GoogleMaps.LocationServices;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        public MapWindow(object obj)
        {
            InitializeComponent();
            myMap.Focus();
            Pushpin pin;
            if (obj is Nanny)
            {
             Nanny   obj_ = obj as Nanny;


                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(obj_.address);

                var latitude = point.Latitude;
                var longitude = point.Longitude;
                Location pinLocation = new Location(latitude,longitude);
                    
                pin = new Pushpin();
                pin.Location = pinLocation;
                pin.Background = Brushes.Green;
           
                myMap.Children.Add(pin);

            }
            if (obj is Mother)
            {
               Mother obj_ = obj as Mother;
                myMap.Center.Latitude = obj_.co1;
                myMap.Center.Longitude = obj_.co2;
                Location pinLocation = new Location(obj_.co1, obj_.co2);
                pin = new Pushpin();
                pin.Location = pinLocation;
                pin.Background = Brushes.Green;
                myMap.Children.Add(pin);
            }
         
        
        }
    }
}
