using Realms;  
using System;  
using System.Linq;  
using Xamarin.Forms;  
using Xamarin.Forms.Xaml;  
   
namespace RealmMobEx  
{  
    [XamlCompilation(XamlCompilationOptions.Compile)]  
    public partial class ShowEmp : ContentPage  
    {  
        Employee mSelEmployee;  
        public ShowEmp()  
        {  
            InitializeComponent();  
        }  
        public ShowEmp(Employee aSelEmp)  
        {  
            InitializeComponent();  
            mSelEmployee = aSelEmp;  
            BindingContext = mSelEmployee;  
        }   
     
        public void OnEditClicked(object sender, EventArgs args)  
        {  
            Navigation.PushAsync(new EditEmp(mSelEmployee));  
        }  
        public async void OnDeleteClicked(object sender, EventArgs args)  
        {  
            bool accepted = await DisplayAlert("Confirm", "Are you Sure ?", "Yes", "No");  
            if (accepted)  
            {  
                var vRealmDb = Realm.GetInstance();  
                var vSelEmp = vRealmDb.All<Employee>().First(b => b.EmpId == mSelEmployee.EmpId);  
   
                // Delete an object with a transaction  
                using (var trans = vRealmDb.BeginWrite())  
                {  
                    vRealmDb.Remove(vSelEmp);  
                    trans.Commit();  
                }  
            }  
            await Navigation.PopToRootAsync();  
        }  
    }  
}  
