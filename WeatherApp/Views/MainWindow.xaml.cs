using OpenWeatherAPI;
using System.Windows;
using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TemperatureViewModel vm;

        public MainWindow()
        {
            InitializeComponent();

            var apiKey = AppConfiguration.GetValue("OWApiKey");
            ApiHelper.InitializeClient();

            vm = new TemperatureViewModel();
            vm.SetTemperatureService(new OpenWeatherService(apiKey));

            DataContext = vm; 
        }
    }
}
