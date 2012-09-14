using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.BackgroundAudio;
using Microsoft.Phone.Controls;

namespace Assignment_1
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();

            
        }


        #region AudioFunctions
        
        private void PlaySong_Click(object sender, RoutedEventArgs e)
        {
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)    //if the song is playing pause it
                BackgroundAudioPlayer.Instance.Pause();
            else
                BackgroundAudioPlayer.Instance.Play();  //if the song is paused, play it
            
            BackgroundAudioPlayer.Instance.PlayStateChanged += new EventHandler(Instance_PlayStateChanged);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   //makes sure that when you navigate back to the page the buttons look the same
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                PlaySong.Content = "Stop Song";
            else
                PlaySong.Content = "Play Song";

        }

        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            switch(BackgroundAudioPlayer.Instance.PlayerState)
            {   //changes the button content
                case PlayState.Playing: PlaySong.Content = "Stop Song"; break;

                case PlayState.Paused:
                case PlayState.Stopped:
                    PlaySong.Content = "Play Song"; break;
            }

        }

        #endregion

        #region WebRequest
       
        private void SendData_Click(object sender, RoutedEventArgs e)
        {   //navigates to the next page
            this.NavigationService.Navigate(new Uri("/SendDataPage.xaml", UriKind.Relative));
          
        }

        #endregion

        #region Fetching data from web

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            WebClient download = new WebClient();   //starts a new weclient

            Uri address = new Uri("http://www.hig.no", UriKind.Absolute);   //the address to be used

            download.DownloadStringAsync(address);  //downloads the string from the address given
            
            download.DownloadStringCompleted += new DownloadStringCompletedEventHandler(download_DownloadStringCompleted); //event-handler for when the
                                                                                                                           //download finishes
        }

        void download_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {   //creates a splash screen with the downloaded content
            MessageBox.Show(e.Result);
        }
        #endregion
    }
}