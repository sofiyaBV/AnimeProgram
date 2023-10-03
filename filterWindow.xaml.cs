using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AnimeProgram
{
    /// <summary>
    /// Логика взаимодействия для filterWindow.xaml
    /// </summary>
    public partial class filterWindow : Window
    {
        public event EventHandler<string> ComboBoxItemSelected;
        public filterWindow()
        {
            InitializeComponent();
        }
        List<string> list_img = new List<string>
        {
            "Waifu",
            "Husbando",
            "Kitsune",
            "Neko",
        };
        List<string> list_gif = new List<string>
        {
           "Dance",
           "Baka",
           "Bite",
           "Blush",
           "Bored",
           "Cry",
           "Cuddle",
           "Facepalm",
           "Feed",
           "Handhold",
           "Happy",
           "Highfive",
           "Hug",
           "Kick",
           "Kiss",
           "Laugh",
           "Nod",
           "Nom",
           "Nope",
           "Pat",
           "Poke",
           "Pout",
           "Shrug",
           "Slap",
           "Sleep",
           "Smile",
           "Smug",
           "Stare",
           "Think",
           "Thumbsup",
           "Tickle",
           "Wave",
           "Wink",
           "Yeet"
        };
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cb_img.ItemsSource = list_img;
            cb_gif.ItemsSource = list_gif;
        }

        private void cb_img_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_img.SelectedItem != null)
            {
                string selectedValue = cb_img.SelectedItem.ToString();
                ComboBoxItemSelected?.Invoke(this, selectedValue);
                Close();
            }
        }

        private void cb_gif_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_gif.SelectedItem != null)
            {
                string selectedValue = cb_gif.SelectedItem.ToString();
                ComboBoxItemSelected?.Invoke(this, selectedValue);
                Close();
            }
        }
    }
}
