using System;
using TodoApp.Models;
using TodoApp.ViewModels;
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
            BindingContext = new MakeTodoPageViewModel();
        }
        
        public MakeTodoPage(TodoItem item)
        {
            InitializeComponent();
            BindingContext = new MakeTodoPageViewModel()
            {
                Item = item
            };
        }
    }
}