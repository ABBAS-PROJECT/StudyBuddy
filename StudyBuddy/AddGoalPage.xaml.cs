using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;  // ← ADD THIS LINE

namespace StudyBuddy
{
    public partial class AddGoalPage : ContentPage
    {
        private readonly Stopwatch stopwatch;
        private TimeSpan elapsedTime;
        private CancellationTokenSource? cancellationTokenSource;
        private bool isStopwatchRunning;

        public AddGoalPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
            UpdateStopwatchLabel();
        }

        private void StartStopButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (isStopwatchRunning)
                {
                    StopStopwatch();
                    button.Text = "Start";
                    button.BackgroundColor = Color.FromArgb("#10B981");
                }
                else
                {
                    StartStopwatch();
                    button.Text = "Stop";
                    button.BackgroundColor = Color.FromArgb("#EF4444");
                }

                isStopwatchRunning = !isStopwatchRunning;
            }
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            if (isStopwatchRunning)
            {
                StopStopwatch();
                isStopwatchRunning = false;
            }

            stopwatch.Reset();
            elapsedTime = TimeSpan.Zero;
            SubjectNameEntry.Text = string.Empty;
            UpdateStopwatchLabel();

            StartStopButton.Text = "Start";
            StartStopButton.BackgroundColor = Color.FromArgb("#10B981");
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            var subjectName = SubjectNameEntry.Text?.Trim();
            if (string.IsNullOrWhiteSpace(subjectName))
            {
                await DisplayAlert("Missing Subject", "Please enter a subject name before saving.", "OK");
                return;
            }

            if (elapsedTime.TotalSeconds < 1)
            {
                await DisplayAlert("No Time Recorded", "Please use the timer to record study time.", "OK");
                return;
            }

            if (sender is Button button)
            {
                button.IsEnabled = false;
                button.Text = "Saving...";
            }

            try
            {
                var goalRecord = new GoalRecord(subjectName, elapsedTime);
                var firebaseHelper = new FirebaseHelper();
                await firebaseHelper.SaveGoalRecord(goalRecord);

                await DisplayAlert("Success!", $"Study session saved!\n\n{subjectName}\nDuration: {elapsedTime:hh\\:mm\\:ss}", "OK");

                ResetButton_Clicked(sender, e);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to save: {ex.Message}\n\nPlease check your internet connection.", "OK");
            }
            finally
            {
                if (sender is Button saveButton)
                {
                    saveButton.IsEnabled = true;
                    saveButton.Text = "💾 Save Goal";
                }
            }
        }

        private void StartStopwatch()
        {
            stopwatch.Start();
            cancellationTokenSource = new CancellationTokenSource();
            _ = UpdateStopwatchLabelAsync(cancellationTokenSource.Token);
        }

        private void StopStopwatch()
        {
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
            cancellationTokenSource?.Cancel();
        }

        private void UpdateStopwatchLabel()
        {
            StopwatchLabel.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private async Task UpdateStopwatchLabelAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    elapsedTime = stopwatch.Elapsed;
                    UpdateStopwatchLabel();
                    await Task.Delay(100, cancellationToken);
                }
            }
            catch (TaskCanceledException)
            {
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (isStopwatchRunning)
            {
                StopStopwatch();
            }
        }
    }
}