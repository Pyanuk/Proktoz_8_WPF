using System;
using System.IO;
using System.Windows;

namespace Libraries
{
    public partial class App : Application
    {
        private static string theme;
        private static string language;

        public static string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                var dict = new ResourceDictionary { Source = new Uri("/LibraryThemes;component/Themes/" + value + ".xaml", UriKind.Relative) };

                if (Current.Resources.MergedDictionaries.Count > 0)
                {
                    Current.Resources.MergedDictionaries.RemoveAt(0);
                }
                Current.Resources.MergedDictionaries.Insert(0, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\theme.txt", value);
            }
        }

        public static string Language
        {
            get { return language; }
            set
            {
                language = value;
                var t = new ResourceDictionary { Source = new Uri("/RussianEnglish;component/Language/" + value + ".xaml", UriKind.Relative) };

                if (Current.Resources.MergedDictionaries.Count > 1)
                {
                    Current.Resources.MergedDictionaries.RemoveAt(2);
                }
                Current.Resources.MergedDictionaries.Insert(2, t);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                File.WriteAllText($"{desktop}\\language.txt", value);
            }
        }

        public App()
        {
            InitializeComponent();

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists($"{desktop}\\theme.txt"))
            {
                Theme = File.ReadAllText($"{desktop}\\theme.txt");
            }
            if (File.Exists($"{desktop}\\language.txt"))
            {
                Language = File.ReadAllText($"{desktop}\\language.txt");
            }
        }
    }
}
