using AppXam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursePage : ContentPage
    {
        public CoursePage()
        {
            InitializeComponent();
        }
        private async void SaveCourse(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            if (!String.IsNullOrEmpty(course.CourseName))
            {
                await App.Database.SaveItemAsync(course);
            }
            await this.Navigation.PopAsync();
        }
        private async void DeleteCourse(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            await App.Database.DeleteItemAsync(course);
            await this.Navigation.PopAsync();
        }
        private async void Cancel(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
        /*
        private void SaveCourse(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            if (!String.IsNullOrEmpty(course.CourseName))
            {
                App.Database.SaveItem(course);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteCourse(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            App.Database.DeleteItem(course.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
        */
    }

}