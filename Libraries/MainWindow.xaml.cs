using System.Windows;
using LibraryJson;
using Path = System.IO.Path;

namespace Libraries
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void indigoTheme_Click(object sender, RoutedEventArgs e)
        {
            App.Theme = "Purple";
        }

        private void aquamarineTheme_Click(object sender, RoutedEventArgs e)
        {
            App.Theme = "White";
        }

        private void serializationBtn_Click(object sender, RoutedEventArgs e)
        {
            string textToSerialize = inputText.Text;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, "Ser.json");
            Json.SerializeToFile(textToSerialize, jsonFilePath);

            inputText.Text = "";
        }

        private void deserializationBtn_Click(object sender, RoutedEventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, "Ser.json");
            string deserializedText = Json.DeserializeFromFile<string>(jsonFilePath);
            if (!string.IsNullOrEmpty(deserializedText))
            {
                dataLbx.Items.Add(deserializedText);
            }
        }

        private void english_Click(object sender, RoutedEventArgs e)
        {
            App.Language = "Russian";
        }

        private void russian_Click(object sender, RoutedEventArgs e)
        {
            App.Language = "English";
        }
    }
}