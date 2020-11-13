using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class MakeTodoPageViewModel : BaseViewModel
    {

        public ICommand DeleteCommand { get; set; }
        
        public ICommand CancelCommand { get; set; }
        
        public ICommand SaveCommand { get; set; }
        public TodoItem Item { get; set; }
        public MakeTodoPageViewModel()
        {
            Item = new TodoItem();
            
            SaveCommand = new Command(execute: async () =>
            {
                await App.Database.SaveItemAsync(Item);
                OnPropertyChanged();
                await Application.Current.MainPage.Navigation.PopAsync();
            });
            
            DeleteCommand = new Command(execute: async () =>
            {
                await App.Database.DeleteItemAsync(Item);
                OnPropertyChanged();
                await Application.Current.MainPage.Navigation.PopAsync();
                
            });
            
            CancelCommand = new Command(execute: async () =>
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
                await Application.Current.MainPage.Navigation.PopAsync();
            });
            
            /*
            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var todoItem = (TodoItem)BindingContext;
                await App.Database.SaveItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var todoItem = (TodoItem)BindingContext;
                await App.Database.DeleteItemAsync(todoItem);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "Done" },
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
            
            */
        }
    }
}