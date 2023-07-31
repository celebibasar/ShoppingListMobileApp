using Microsoft.Maui.Controls;
using ShoppingListMobileApp.Models;
using ShoppingListMobileApp.ViewModels;
using System;
using Notification = ShoppingListMobileApp.Models.Notification;


namespace ShoppingListMobileApp
{
    public partial class NotificationsPageView : ContentPage
    {
        public NotificationsPageView()
        {
            InitializeComponent();
            
        }
        private void ShowButton_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Notification notification)
            {
                DisplayAlert(notification.Title, notification.Message, "OK");
            }
        }

    }
}
