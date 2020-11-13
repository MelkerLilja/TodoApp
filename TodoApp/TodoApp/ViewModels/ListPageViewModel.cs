using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Models;
using TodoApp.Views;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class ListPageViewModel : BaseViewModel
    {
        public ICommand ButtonAction { private set; get; }
        public ObservableCollection<TodoItem> Items { get; set; }

        public ICommand LoadItemsCommand { get; }

        private TodoItem selectedItem;
        public TodoItem SelectedItem { 
            get
            {
                return selectedItem; 
            }
            set
            {
                selectedItem = value;

                if (selectedItem == null)
                    return;

                OnListItemSelected(selectedItem);

                SelectedItem = null;
            }}

        public ListPageViewModel()
        {
            Items = new ObservableCollection<TodoItem>();
            LoadItemsCommand = new Command(async () => await FetchItems());
            Task.Run(async () => { await FetchItems(); });
            
            ButtonAction = new Command(execute: async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MakeTodoPage());
            });
        }
        
        async void OnListItemSelected(TodoItem e)
        {
            if (e != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MakeTodoPage(e));
            }
        }

        private async Task FetchItems()
        {
            IsBusy = true;
            Items.Clear();
            foreach (var item in await App.Database.GetItemsAsync())
            {
                Items.Add(item);
            }

            IsBusy = false;
        }

    }
    }
