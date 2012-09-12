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

            BackgroundAudioPlayer.Instance.PlayStateChanged += new EventHandler(Instance_PlayStateChanged);
        }


        #region AudioFunctions
        
        private void PlaySong_Click(object sender, RoutedEventArgs e)
        {
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)    //if the song is playing pause it
                BackgroundAudioPlayer.Instance.Pause();
            else
                BackgroundAudioPlayer.Instance.Play();  //if the song is paused, play it

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (PlayState.Playing == BackgroundAudioPlayer.Instance.PlayerState)
                PlaySong.Content = "Pause Song";
            else
                PlaySong.Content = "Play Song";

        }

        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            switch(BackgroundAudioPlayer.Instance.PlayerState)
            {
                case PlayState.Playing: PlaySong.Content = "Pause Song"; break;

                case PlayState.Paused:
                case PlayState.Stopped:
                    PlaySong.Content = "Play Song"; break;
            }

        }

        #endregion

        #region WebRequest
       
        private void SendData_Click(object sender, RoutedEventArgs e)
        {
            WebClient upload = new WebClient();
            upload.Headers["Content-Type"] = "text/javascript";
            Uri address = new Uri("http://www.gtl.hig.no/mobile/logging.php?user=Peer&data=1", UriKind.Absolute);
            upload.UploadStringAsync(address, "");
            upload.UploadStringCompleted += new UploadStringCompletedEventHandler(upload_UploadStringCompleted);
            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://www.gtl.hig.no/mobile/logging.php", UriKind.Absolute)); //declares a webrequest to the specified URL

            //webRequest.Method = "POST"; //using POST
            //webRequest.ContentType = "application/x-www-form-urlencoded"; //what type of POST

            //webRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), webRequest); //makes an asynchronous call to the page
        
        }

        void upload_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result);
        }

        void GetRequestStreamCallback(IAsyncResult asyncResult)
        {
        //    HttpWebRequest webRequest = (HttpWebRequest)asyncResult.AsyncState;

        //    Stream postStream = webRequest.EndGetRequestStream(asyncResult);

        //    string data = "?User=Peer";
        //    byte[] bytes = Encoding.UTF8.GetBytes(data);

        //    postStream.Write(bytes, 0, bytes.Length);
        //    postStream.Close();
        }

        #endregion

        #region Fetching data from web


        #endregion
    }
}