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

        private void SendData_Click(object sender, RoutedEventArgs e)
        {

        }

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
    }
}