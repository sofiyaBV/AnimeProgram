using System;
using System.Windows;
using System.Windows.Controls;

namespace AnimeProgram
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();
        }
        public string URL { get; set; }
        public string Name { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(URL))
            {
                Uri mediaElement = new Uri(URL);

                me_element.Source = mediaElement;
                me_element.LoadedBehavior = MediaState.Play; // Автоматически проигрывать
            }
            tb_Name.Text = Name;
            tb_url.Text = URL;
        }

        private void ME_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mediaElement = sender as MediaElement;
            mediaElement.Position = TimeSpan.FromMilliseconds(1);
            mediaElement.Play();
        }
    }
}
