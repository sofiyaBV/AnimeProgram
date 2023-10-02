using NekosBestApiNet;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
        List<ImageItem> _images = new List<ImageItem>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
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

        private void ME_MediaEnded(object sender, RoutedEventArgs e)
        {
            var mediaElement = sender as MediaElement;
            mediaElement.Position = TimeSpan.FromMilliseconds(1);
            mediaElement.Play();
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
            ImageItem imageItem = (sender as FrameworkElement)?.DataContext as ImageItem;

            if (imageItem != null)
            {
                // Создайте новое окно InfoWindow
                InfoWindow infoWindow = new InfoWindow
                {
                    Name = imageItem.Author,
                    URL = imageItem.Url
                };

                // Откройте окно
                infoWindow.ShowDialog();
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            filterWindow filterWindow = new filterWindow();
            filterWindow.ComboBoxItemSelected += filterWindow_SelectionChanged; 
            filterWindow.ShowDialog();
        }
        private async void filterWindow_SelectionChanged(object sender, string selectedValue)
        {
            switch (selectedValue)
            {
                case "Waifu":
                    await ApplyFilter(FilterType.Waifu);
                    break;
                case "Husbando":
                    await ApplyFilter(FilterType.Husbando);
                    break;
                case "Kitsune":
                    await ApplyFilter(FilterType.Kitsune);
                    break;
                case "Neko":
                    await ApplyFilter(FilterType.Neko);
                    break;
                case "Dance":
                    await ApplyFilter(FilterType.Dance);
                    break;
                case "Baka":
                    await ApplyFilter(FilterType.Baka);
                    break;
                case "Bite":
                    await ApplyFilter(FilterType.Bite);
                    break;
                case "Blush":
                    await ApplyFilter(FilterType.Blush);
                    break;
                case "Bored":
                    await ApplyFilter(FilterType.Bored);
                    break;
                case "Cry":
                    await ApplyFilter(FilterType.Cry);
                    break;
                case "Cuddle":
                    await ApplyFilter(FilterType.Cuddle);
                    break;
                case "Facepalm":
                    await ApplyFilter(FilterType.Facepalm);
                    break;
                case "Feed":
                    await ApplyFilter(FilterType.Feed);
                    break;
                case "Handhold":
                    await ApplyFilter(FilterType.Handhold);
                    break;
                case "Happy":
                    await ApplyFilter(FilterType.Happy);
                    break;
                case "Highfive":
                    await ApplyFilter(FilterType.Highfive);
                    break;
                case "Hug":
                    await ApplyFilter(FilterType.Hug);
                    break;
                case "Kick":
                    await ApplyFilter(FilterType.Kick);
                    break;
                case "Kiss":
                    await ApplyFilter(FilterType.Kiss);
                    break;
                case "Laugh":
                    await ApplyFilter(FilterType.Laugh);
                    break;
                case "Nod":
                    await ApplyFilter(FilterType.Nod);
                    break;
                case "Nom":
                    await ApplyFilter(FilterType.Nom);
                    break;
                case "Nope":
                    await ApplyFilter(FilterType.Nope);
                    break;
                case "Pat":
                    await ApplyFilter(FilterType.Pat);
                    break;
                case "Poke":
                    await ApplyFilter(FilterType.Poke);
                    break;
                case "Pout":
                    await ApplyFilter(FilterType.Pout);
                    break;
                case "Shrug":
                    await ApplyFilter(FilterType.Shrug);
                    break;
                case "Slap":
                    await ApplyFilter(FilterType.Slap);
                    break;
                case "Sleep":
                    await ApplyFilter(FilterType.Sleep);
                    break;
                case "Smile":
                    await ApplyFilter(FilterType.Smile);
                    break;
                case "Smug":
                    await ApplyFilter(FilterType.Smug);
                    break;
                case "Stare":
                    await ApplyFilter(FilterType.Stare);
                    break;
                case "Think":
                    await ApplyFilter(FilterType.Think);
                    break;
                case "Thumbsup":
                    await ApplyFilter(FilterType.Thumbsup);
                    break;
                case "Tickle":
                    await ApplyFilter(FilterType.Tickle);
                    break;
                case "Wave":
                    await ApplyFilter(FilterType.Wave);
                    break;
                case "Wink":
                    await ApplyFilter(FilterType.Wink);
                    break;
                case "Yeet":
                    await ApplyFilter(FilterType.Yeet);
                    break;
            }
        }
        private async Task ApplyFilter(FilterType filterType)
        {
            _images.Clear();
            for (int i = 0; i < 20; i++)
            {
                string url;
                string author;
                switch (filterType)
                {
                    case FilterType.Waifu:
                        url = (await _nekosBestApi.CategoryApi.Waifu()).Results[0].Url;
                        author = (await _nekosBestApi.CategoryApi.Waifu()).Results[0].ArtistName;
                        break;
                    case FilterType.Husbando:
                        url = (await _nekosBestApi.CategoryApi.Husbando()).Results[0]?.Url;
                        author = (await _nekosBestApi.CategoryApi.Husbando()).Results[0].ArtistName;
                        break;
                    case FilterType.Kitsune:
                        url = (await _nekosBestApi.CategoryApi.Kitsune()).Results[0]?.Url;
                        author = (await _nekosBestApi.CategoryApi.Kitsune()).Results[0].ArtistName;
                        break;
                    case FilterType.Neko:
                        url = (await _nekosBestApi.CategoryApi.Neko()).Results[0]?.Url;
                        author = (await _nekosBestApi.CategoryApi.Neko()).Results[0].ArtistName;
                        break;
                    case FilterType.Dance:
                        url = (await _nekosBestApi.ActionsApi.Dance()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Dance()).Results[0].AnimeName;
                        break;
                    case FilterType.Baka:
                        url = (await _nekosBestApi.ActionsApi.Baka()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Baka()).Results[0].AnimeName;
                        break;
                    case FilterType.Bite:
                        url = (await _nekosBestApi.ActionsApi.Bite()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Bite()).Results[0].AnimeName;
                        break;
                    case FilterType.Blush:
                        url = (await _nekosBestApi.ActionsApi.Blush()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Blush()).Results[0].AnimeName;
                        break;
                    case FilterType.Bored:
                        url = (await _nekosBestApi.ActionsApi.Bored()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Bored()).Results[0].AnimeName;
                        break;
                    case FilterType.Cry:
                        url = (await _nekosBestApi.ActionsApi.Cry()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Cry()).Results[0].AnimeName;
                        break;
                    case FilterType.Cuddle:
                        url = (await _nekosBestApi.ActionsApi.Cuddle()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Cuddle()).Results[0].AnimeName;
                        break;
                    case FilterType.Facepalm:
                        url = (await _nekosBestApi.ActionsApi.Facepalm()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Facepalm()).Results[0].AnimeName;
                        break;
                    case FilterType.Feed:
                        url = (await _nekosBestApi.ActionsApi.Feed()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Feed()).Results[0].AnimeName;
                        break;
                    case FilterType.Handhold:
                        url = (await _nekosBestApi.ActionsApi.Handhold()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Handhold()).Results[0].AnimeName;
                        break;
                    case FilterType.Happy:
                        url = (await _nekosBestApi.ActionsApi.Happy()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Happy()).Results[0].AnimeName;
                        break;
                    case FilterType.Highfive:
                        url = (await _nekosBestApi.ActionsApi.Highfive()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Highfive()).Results[0].AnimeName;
                        break;
                    case FilterType.Hug:
                        url = (await _nekosBestApi.ActionsApi.Hug()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Hug()).Results[0].AnimeName;
                        break;
                    case FilterType.Kick:
                        url = (await _nekosBestApi.ActionsApi.Kick()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Kick()).Results[0].AnimeName;
                        break;
                    case FilterType.Kiss:
                        url = (await _nekosBestApi.ActionsApi.Kiss()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Kiss()).Results[0].AnimeName;
                        break;
                    case FilterType.Laugh:
                        url = (await _nekosBestApi.ActionsApi.Laugh()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Laugh()).Results[0].AnimeName;
                        break;
                    case FilterType.Nod:
                        url = (await _nekosBestApi.ActionsApi.Nod()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Nod()).Results[0].AnimeName;
                        break;
                    case FilterType.Nom:
                        url = (await _nekosBestApi.ActionsApi.Nom()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Nom()).Results[0].AnimeName;
                        break;
                    case FilterType.Nope:
                        url = (await _nekosBestApi.ActionsApi.Nope()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Nope()).Results[0].AnimeName;
                        break;
                    case FilterType.Pat:
                        url = (await _nekosBestApi.ActionsApi.Pat()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Pat()).Results[0].AnimeName;
                        break;
                    case FilterType.Poke:
                        url = (await _nekosBestApi.ActionsApi.Poke()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Poke()).Results[0].AnimeName;
                        break;
                    case FilterType.Pout:
                        url = (await _nekosBestApi.ActionsApi.Pout()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Pout()).Results[0].AnimeName;
                        break;
                    case FilterType.Shrug:
                        url = (await _nekosBestApi.ActionsApi.Shrug()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Shrug()).Results[0].AnimeName;
                        break;
                    case FilterType.Slap:
                        url = (await _nekosBestApi.ActionsApi.Slap()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Slap()).Results[0].AnimeName;
                        break;
                    case FilterType.Sleep:
                        url = (await _nekosBestApi.ActionsApi.Sleep()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Sleep()).Results[0].AnimeName;
                        break;
                    case FilterType.Smile:
                        url = (await _nekosBestApi.ActionsApi.Smile()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Smile()).Results[0].AnimeName;
                        break;
                    case FilterType.Smug:
                        url = (await _nekosBestApi.ActionsApi.Smug()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Smug()).Results[0].AnimeName;
                        break;
                    case FilterType.Stare:
                        url = (await _nekosBestApi.ActionsApi.Stare()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Stare()).Results[0].AnimeName;
                        break;
                    case FilterType.Think:
                        url = (await _nekosBestApi.ActionsApi.Think()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Think()).Results[0].AnimeName;
                        break;
                    case FilterType.Thumbsup:
                        url = (await _nekosBestApi.ActionsApi.Thumbsup()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Thumbsup()).Results[0].AnimeName;
                        break;
                    case FilterType.Tickle:
                        url = (await _nekosBestApi.ActionsApi.Tickle()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Tickle()).Results[0].AnimeName;
                        break;
                    case FilterType.Wave:
                        url = (await _nekosBestApi.ActionsApi.Wave()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Wave()).Results[0].AnimeName;
                        break;
                    case FilterType.Wink:
                        url = (await _nekosBestApi.ActionsApi.Wink()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Wink()).Results[0].AnimeName;
                        break;
                    case FilterType.Yeet:
                        url = (await _nekosBestApi.ActionsApi.Dance()).Results[0]?.Url;
                        author = (await _nekosBestApi.ActionsApi.Yeet()).Results[0].AnimeName;
                        break;
                    default:
                        throw new ArgumentException("incorrect filter type");
                }

                if (!string.IsNullOrEmpty(url))
                {
                    _images.Add(new ImageItem(url, author));
                }
            }

            listImages.ItemsSource = null;
            listImages.ItemsSource = _images;
        }
        public enum FilterType
        {
            Waifu,
            Husbando,
            Kitsune,
            Neko,
            Dance,
            Baka,
            Bite,
            Blush,
            Bored,
            Cry,
            Cuddle,
            Facepalm,
            Feed,
            Handhold,
            Happy,
            Highfive,
            Hug,
            Kick,
            Kiss,
            Laugh,
            Nod,
            Nom,
            Nope,
            Pat,
            Poke,
            Pout,
            Shrug,
            Slap,
            Sleep,
            Smile,
            Smug,
            Stare,
            Think,
            Thumbsup,
            Tickle,
            Wave,
            Wink,
            Yeet
         }
    }
}
