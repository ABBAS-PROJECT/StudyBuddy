using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace StudyBuddy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadTipOfTheDay();
        }

        private async void LoadTipOfTheDay()
        {
            try
            {
                var tip = await GetTipOfTheDay();
                TipOfTheDayLabel.Text = tip ?? "No tip available today.";
            }
            catch (Exception ex)
            {
                TipOfTheDayLabel.Text = $"Error fetching tip: {ex.Message}";
                Console.WriteLine($"Error fetching tip: {ex.Message}");
            }
        }

        private async Task<string> GetTipOfTheDay()
        {
            // Open the tips.txt file from the Resources/Raw folder
            using var stream = await FileSystem.OpenAppPackageFileAsync("tips.txt");
            using var reader = new StreamReader(stream);

            var tips = await reader.ReadToEndAsync();
            var tipsArray = tips.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var randomTip = tipsArray.OrderBy(_ => Guid.NewGuid()).FirstOrDefault();
            if (randomTip != null)
            {
                return randomTip;
            }
            else
            {
                return "No tip available today.";
            }

        }

        private async void AddGoalButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddGoalPage());
        }
    }
}
