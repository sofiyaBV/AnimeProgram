using NekosBestApiNet;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
        NekosBestApi ?_nekosBestApi;//подключение Api
        List<ImageItem> _images = new List<ImageItem>();//список фото\гифок
        private void Window_Loaded(object sender, RoutedEventArgs e)//загрузка первых 10 фото
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

        private void ME_MediaEnded(object sender, RoutedEventArgs e)//постоянный перезапуск гифок 
        {

            var mediaElement = sender as MediaElement;
            if (mediaElement != null)
            {
                mediaElement.Position = TimeSpan.FromMilliseconds(1);
                mediaElement.Play();
            }
        }

        //при нажатии на стекпанель открываеться новое окно с информацией о изображении
        private void StackPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ImageItem imageItem = (sender as FrameworkElement)?.DataContext as ImageItem;

            if (imageItem != null)
            {
                InfoWindow infoWindow = new InfoWindow
                {
                    Name = imageItem.Author,
                    URL = imageItem.Url
                };
                infoWindow.ShowDialog();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)//открытие фильтра
        {
            filterWindow filterWindow = new filterWindow();
            filterWindow.ComboBoxItemSelected += filterWindow_SelectionChanged; 
            filterWindow.ShowDialog();
        }
        //получаем тип фотографии и отправляем в перезапись формы с выбраным фильтром
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
        //переприсвоение данных под определённый фильтр что мы получили ранее
        private async Task ApplyFilter(FilterType filterType)
        {
            _images.Clear();
            for (int i = 0; i < 20; i++)
            {
                if (_nekosBestApi != null)
                {
                    switch (filterType)
                    {
                        case FilterType.Waifu:
                            var waifu = _nekosBestApi.CategoryApi.Waifu().Result.Results[0];
                            _images.Add(new ImageItem(waifu.Url, waifu.ArtistName));
                            break;
                        case FilterType.Husbando:
                            var husbando = _nekosBestApi.CategoryApi.Husbando().Result.Results[0];
                            _images.Add(new ImageItem(husbando.Url, husbando.ArtistName));
                            break;
                        case FilterType.Kitsune:
                            var kitsune = _nekosBestApi.CategoryApi.Kitsune().Result.Results[0];
                            _images.Add(new ImageItem(kitsune.Url, kitsune.ArtistName));
                            break;
                        case FilterType.Neko:
                            var neko = _nekosBestApi.CategoryApi.Neko().Result.Results[0];
                            _images.Add(new ImageItem(neko.Url, neko.ArtistName));
                            break;
                        case FilterType.Dance:
                            var dance = _nekosBestApi.ActionsApi.Dance().Result.Results[0];
                            _images.Add(new ImageItem(dance.Url, dance.AnimeName));
                            break;
                        case FilterType.Baka:
                            var baka = _nekosBestApi.ActionsApi.Baka().Result.Results[0];
                            _images.Add(new ImageItem(baka.Url, baka.AnimeName));
                            break;
                        case FilterType.Bite:
                            var bite = _nekosBestApi.ActionsApi.Bite().Result.Results[0];
                            _images.Add(new ImageItem(bite.Url, bite.AnimeName));
                            break;
                        case FilterType.Blush:
                            var blush = _nekosBestApi.ActionsApi.Blush().Result.Results[0];
                            _images.Add(new ImageItem(blush.Url, blush.AnimeName));
                            break;
                        case FilterType.Bored:
                            var bored = _nekosBestApi.ActionsApi.Bored().Result.Results[0];
                            _images.Add(new ImageItem(bored.Url, bored.AnimeName));
                            break;
                        case FilterType.Cry:
                            var cry = _nekosBestApi.ActionsApi.Cry().Result.Results[0];
                            _images.Add(new ImageItem(cry.Url, cry.AnimeName));
                            break;
                        case FilterType.Cuddle:
                            var cuddle = _nekosBestApi.ActionsApi.Cuddle().Result.Results[0];
                            _images.Add(new ImageItem(cuddle.Url, cuddle.AnimeName));
                            break;
                        case FilterType.Facepalm:
                            var facepalm = _nekosBestApi.ActionsApi.Facepalm().Result.Results[0];
                            _images.Add(new ImageItem(facepalm.Url, facepalm.AnimeName));
                            break;
                        case FilterType.Feed:
                            var feed = _nekosBestApi.ActionsApi.Feed().Result.Results[0];
                            _images.Add(new ImageItem(feed.Url, feed.AnimeName));
                            break;
                        case FilterType.Handhold:
                            var handhold = _nekosBestApi.ActionsApi.Handhold().Result.Results[0];
                            _images.Add(new ImageItem(handhold.Url, handhold.AnimeName));
                            break;
                        case FilterType.Happy:
                            var happy = _nekosBestApi.ActionsApi.Happy().Result.Results[0];
                            _images.Add(new ImageItem(happy.Url, happy.AnimeName));
                            break;
                        case FilterType.Highfive:
                            var highfive = _nekosBestApi.ActionsApi.Highfive().Result.Results[0];
                            _images.Add(new ImageItem(highfive.Url, highfive.AnimeName));
                            break;
                        case FilterType.Hug:
                            var hug = _nekosBestApi.ActionsApi.Hug().Result.Results[0];
                            _images.Add(new ImageItem(hug.Url, hug.AnimeName));
                            break;
                        case FilterType.Kick:
                            var kock = _nekosBestApi.ActionsApi.Kick().Result.Results[0];
                            _images.Add(new ImageItem(kock.Url, kock.AnimeName));
                            break;
                        case FilterType.Kiss:
                            var kiss = _nekosBestApi.ActionsApi.Kiss().Result.Results[0];
                            _images.Add(new ImageItem(kiss.Url, kiss.AnimeName));
                            break;
                        case FilterType.Laugh:
                            var laudh = _nekosBestApi.ActionsApi.Laugh().Result.Results[0];
                            _images.Add(new ImageItem(laudh.Url, laudh.AnimeName));
                            break;
                        case FilterType.Nod:
                            var nod = _nekosBestApi.ActionsApi.Nod().Result.Results[0];
                            _images.Add(new ImageItem(nod.Url, nod.AnimeName));
                            break;
                        case FilterType.Nom:
                            var nom = _nekosBestApi.ActionsApi.Nom().Result.Results[0];
                            _images.Add(new ImageItem(nom.Url, nom.AnimeName));
                            break;
                        case FilterType.Nope:
                            var nope = _nekosBestApi.ActionsApi.Nope().Result.Results[0];
                            _images.Add(new ImageItem(nope.Url, nope.AnimeName));
                            break;
                        case FilterType.Pat:
                            var pat = _nekosBestApi.ActionsApi.Pat().Result.Results[0];
                            _images.Add(new ImageItem(pat.Url, pat.AnimeName));
                            break;
                        case FilterType.Poke:
                            var poke = _nekosBestApi.ActionsApi.Poke().Result.Results[0];
                            _images.Add(new ImageItem(poke.Url, poke.AnimeName));
                            break;
                        case FilterType.Pout:
                            var pout = _nekosBestApi.ActionsApi.Pout().Result.Results[0];
                            _images.Add(new ImageItem(pout.Url, pout.AnimeName));
                            break;
                        case FilterType.Shrug:
                            var shrug = _nekosBestApi.ActionsApi.Shrug().Result.Results[0];
                            _images.Add(new ImageItem(shrug.Url, shrug.AnimeName));
                            break;
                        case FilterType.Slap:
                            var salp = _nekosBestApi.ActionsApi.Slap().Result.Results[0];
                            _images.Add(new ImageItem(salp.Url, salp.AnimeName));
                            break;
                        case FilterType.Sleep:
                            var sleep = _nekosBestApi.ActionsApi.Sleep().Result.Results[0];
                            _images.Add(new ImageItem(sleep.Url, sleep.AnimeName));
                            break;
                        case FilterType.Smile:
                            var smile = _nekosBestApi.ActionsApi.Smile().Result.Results[0];
                            _images.Add(new ImageItem(smile.Url, smile.AnimeName));
                            break;
                        case FilterType.Smug:
                            var smug = _nekosBestApi.ActionsApi.Smug().Result.Results[0];
                            _images.Add(new ImageItem(smug.Url, smug.AnimeName));
                            break;
                        case FilterType.Stare:
                            var stare = _nekosBestApi.ActionsApi.Stare().Result.Results[0];
                            _images.Add(new ImageItem(stare.Url, stare.AnimeName));
                            break;
                        case FilterType.Think:
                            var think = _nekosBestApi.ActionsApi.Think().Result.Results[0];
                            _images.Add(new ImageItem(think.Url, think.AnimeName));
                            break;
                        case FilterType.Thumbsup:
                            var thumbsup = _nekosBestApi.ActionsApi.Thumbsup().Result.Results[0];
                            _images.Add(new ImageItem(thumbsup.Url, thumbsup.AnimeName));
                            break;
                        case FilterType.Tickle:
                            var tickle = _nekosBestApi.ActionsApi.Tickle().Result.Results[0];
                            _images.Add(new ImageItem(tickle.Url, tickle.AnimeName));
                            break;
                        case FilterType.Wave:
                            var wave = _nekosBestApi.ActionsApi.Wave().Result.Results[0];
                            _images.Add(new ImageItem(wave.Url, wave.AnimeName));
                            break;
                        case FilterType.Wink:
                            var winck = _nekosBestApi.ActionsApi.Wink().Result.Results[0];
                            _images.Add(new ImageItem(winck.Url, winck.AnimeName));
                            break;
                        case FilterType.Yeet:
                            var yeet = _nekosBestApi.ActionsApi.Yeet().Result.Results[0];
                            _images.Add(new ImageItem(yeet.Url, yeet.AnimeName));
                            break;
                        default:
                            throw new ArgumentException("incorrect filter type");
                    }
                }
            }
            listImages.ItemsSource = null;
            listImages.ItemsSource = _images;
        }
        //все типы
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
