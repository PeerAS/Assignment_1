using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Assignment_1
{
    public partial class ErrorPage : PhoneApplicationPage
    {
        public ErrorPage()
        {
            InitializeComponent();
        }

        public static Exception Exception;

        //runs when the page is navigated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ErrorText.Text = Exception.ToString(); //displays the exception that occured to screen
        }
    }
}