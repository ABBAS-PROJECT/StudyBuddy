using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace StudyBuddy
{
    public partial class GoalsListPage : ContentPage
    {
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        private List<GoalRecord>? goalRecords;

        public GoalsListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadGoalRecords();
        }

        private async void LoadGoalRecords()
        {
            try
            {
                goalRecords = await firebaseHelper.GetGoalRecords();
                GoalRecordsCollectionView.ItemsSource = goalRecords;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load goals:\n{ex.Message}\n\nPlease check your internet connection.", "OK");
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.CommandParameter is not string id)
            {
                await DisplayAlert("Error", "Could not identify the goal to delete.", "OK");
                return;
            }

            var goalToDelete = goalRecords?.FirstOrDefault(g => g.Id == id);
            if (goalToDelete == null)
            {
                await DisplayAlert("Error", "Goal not found.", "OK");
                return;
            }

            bool confirm = await DisplayAlert(
                "Delete Goal?",
                $"Delete this study session?\n\n{goalToDelete.SubjectName}\nDuration: {goalToDelete.StudyDuration:hh\\:mm\\:ss}",
                "Delete",
                "Cancel"
            );

            if (!confirm)
                return;

            button.IsEnabled = false;
            button.Text = "Deleting...";

            try
            {
                await firebaseHelper.DeleteGoalRecord(id);
                await DisplayAlert("Deleted", "Study goal deleted successfully.", "OK");
                LoadGoalRecords();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to delete:\n{ex.Message}", "OK");
                button.IsEnabled = true;
                button.Text = "Delete";
            }
        }
    }
}