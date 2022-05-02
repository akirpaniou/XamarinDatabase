using AppXam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await App.Database.CreateTable();
            coursesList.ItemsSource = await App.Database.GetItemsAsync();

            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Course selectedCourse = (Course)e.SelectedItem;
            CoursePage coursePage = new CoursePage();
            coursePage.BindingContext = selectedCourse;
            await Navigation.PushAsync(coursePage);
        }
        private async void CreateCourse(object sender, EventArgs e)
        {
            Course course = new Course();
            CoursePage coursePage = new CoursePage();
            coursePage.BindingContext = course;
            await Navigation.PushAsync(coursePage);
        }

        /*
        protected override void OnAppearing()
        {
            coursesList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Course selectedCourse = (Course)e.SelectedItem;
            CoursePage coursePage = new CoursePage();
            coursePage.BindingContext = selectedCourse;
            await Navigation.PushAsync(coursePage);
        }
        private async void CreateCourse(object sender, EventArgs e)
        {
            Course course = new Course();
            CoursePage coursePage = new CoursePage();
            coursePage.BindingContext = course;
            await Navigation.PushAsync(coursePage);
        }
        */
    }
}
