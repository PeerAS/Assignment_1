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
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace Assignment_1
{
    public partial class SendDataPage : PhoneApplicationPage
    {
        public SendDataPage()
        {
            InitializeComponent();
        }

        private void SendDataButton_Click(object sender, RoutedEventArgs e)
        {
            string user_input = UserInput.Text;
            string data_input = DataInput.Text;

            if (data_input == "" || user_input == "")
            {   //if you haven't entered any text this will pop up
                MessageBox.Show("One or more of the inputs are empty");
            }
            else
            {   //creates a new webClient
                WebClient upload = new WebClient();
                upload.Headers["Content-Type"] = "text/javascript"; //sets the header used
                Uri address = new Uri("http://www.gtl.hig.no/mobile/logging.php?user="+ user_input +"&data=" + data_input, UriKind.Absolute);
                upload.UploadStringAsync(address, "");
                upload.UploadStringCompleted += new UploadStringCompletedEventHandler(upload_UploadStringCompleted);
            }
        }

        void upload_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            MessageBox.Show("The data has been sent");
            UserInput.Text = "";
            DataInput.Text = "";
        }
    }
}