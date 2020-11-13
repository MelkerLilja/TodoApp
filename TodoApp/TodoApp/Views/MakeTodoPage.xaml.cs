using System;
using TodoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TodoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakeTodoPage
    {
        
        public MakeTodoPage()
        {
            InitializeComponent();
        }
        

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
                var device = DeviceInfo.Platform.ToString();
                var firstText = "You're using a " + device + " device";
                var width = mainDisplayInfo.Width.ToString();
                var secText = "Screen width: " + width + "px";
                await Application.Current.MainPage.DisplayAlert(firstText, secText, "OK");
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                // iOS specific code
                var device = DeviceInfo.Platform.ToString();
                var firstText = "You're using a " + device + " device";
                var deviceBattery = Battery.ChargeLevel.ToString();
                var secText = "Battery level: " + deviceBattery;
                await Application.Current.MainPage.DisplayAlert(firstText, secText, "OK");
            }
            await Navigation.PopAsync();
        }
    }
}