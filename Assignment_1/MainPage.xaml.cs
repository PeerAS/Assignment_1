using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Assignment_1
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            
            InitializeComponent();
            
            //fetches the image from the URL and places it in a URI
            Uri uri = new Uri("http://hig.no/var/ezwebin_site/storage/images/ansatte/avdeling_for_informatikk_og_medieteknikk/simon_j_r_mccallum/270018-7-nor-NO/simon_j_r_mccallum.jpg", UriKind.Absolute);
            this.image1.Source = new BitmapImage(uri); //links the image1 in the XAML with the URI
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {   //navigates to next page
            this.NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }

 

    }
}