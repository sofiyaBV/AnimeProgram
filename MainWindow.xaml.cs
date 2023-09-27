using NekosBestApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace AnimeProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
        }

        NekosBestApi _nekosBestApi;
        List<ImageItem> _images;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_images = new List<ImageItem>();
            //var httpClient = new HttpClient
            //{
            //    BaseAddress = new Uri("https://nekos.best/api/v2")
            //};
            //_nekosBestApi = new NekosBestApi(httpClient);
            //for (int i = 0; i < 20; i++)
            //{
            //    var request_item = _nekosBestApi.ActionsApi.Pout().Result.Results[0];
            //    _images.Add(new ImageItem(request_item.Url, request_item.AnimeName));

            //}
            //listImages.ItemsSource = _images;
            _images = new List<ImageItem>();
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://nekos.best/api/v2")
            };
            _nekosBestApi = new NekosBestApi(httpClient);
            for (int i = 0; i < 10; i++)
            {
                var request_item = _nekosBestApi.CategoryApi.Neko().Result.Results[0];
                _images.Add(new ImageItem(request_item.Url, request_item.ArtistName));
            }
            listImages.ItemsSource = _images;

        }

        private void StackPanel_Executed(object sender, EventArgs e)
        {
            var panel = sender as StackPanel;
            MessageBox.Show(panel.Children[0].ToString());
            var me = panel.Children[0] as MediaElement;
            me.Play();

        }

        private void StackPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var panel = sender as StackPanel;

            MediaElement me = panel.Children[0] as MediaElement;
            me.Position = TimeSpan.FromMilliseconds(1);
            me.Play();
        }
    }
}
