using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using System;
using System.IO;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public partial class TipsPage : ContentPage
    {
        public TipsPage()
        {
            InitializeComponent();
            LoadTipsFromFile();
        }

        private async void LoadTipsFromFile()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("tips.txt");
                using var reader = new StreamReader(stream);

                int tipNumber = 1;
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var tipCard = new Border
                    {
                        BackgroundColor = Colors.White,
                        StrokeThickness = 0,
                        Padding = new Thickness(18),
                        Margin = new Thickness(0, 0, 0, 12),
                        Shadow = new Shadow
                        {
                            Brush = Colors.Black,
                            Opacity = 0.08f,
                            Radius = 6,
                            Offset = new Point(0, 2)
                        },
                        StrokeShape = new RoundRectangle { CornerRadius = 12 }
                    };

                    var contentStack = new VerticalStackLayout
                    {
                        Spacing = 8
                    };

                    var tipNumberLabel = new Label
                    {
                        Text = $"Tip #{tipNumber}",
                        FontSize = 14,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.FromArgb("#6366F1")
                    };

                    var tipLabel = new Label
                    {
                        Text = line,
                        FontSize = 16,
                        TextColor = Color.FromArgb("#1F2937"),
                        LineHeight = 1.4
                    };

                    contentStack.Children.Add(tipNumberLabel);
                    contentStack.Children.Add(tipLabel);
                    tipCard.Content = contentStack;

                    TipsStackLayout.Children.Add(tipCard);
                    tipNumber++;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load tips: {ex.Message}", "OK");
            }
        }
    }
}