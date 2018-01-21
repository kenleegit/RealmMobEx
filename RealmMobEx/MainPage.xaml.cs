using Realms;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace RealmMobEx
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vRealmDb = Realm.GetInstance();
            var vAllEmployees = vRealmDb.All<Employee>();
            lstData.ItemsSource = vAllEmployees;
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
                //ItemSelected is called on deselection,   
                //which results in SelectedItem being set to null  
            }
            var vSelUser = (Employee)e.SelectedItem;
            Navigation.PushAsync(new ShowEmp(vSelUser));
        }
        public void OnNewClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new AddEmp());
        }
    }
}