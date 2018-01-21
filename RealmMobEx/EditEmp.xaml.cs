using Realms;  
using System;  
using Xamarin.Forms;  
using Xamarin.Forms.Xaml;  
   
namespace RealmMobEx  
{  
    [XamlCompilation(XamlCompilationOptions.Compile)]  
    public partial class EditEmp : ContentPage  
    {  
        private Employee mSelEmployee;  
   
        public EditEmp(Employee mSelEmployee)  
        {  
            InitializeComponent();  
            this.mSelEmployee = mSelEmployee;  
            BindingContext = mSelEmployee;  
        }  
   
        public void OnSaveClicked(object sender, EventArgs args)  
        {  
            var vRealmDb = Realm.GetInstance();  
            using (var trans = vRealmDb.BeginWrite())  
            {  
                mSelEmployee.EmpName = txtEmpName.Text;  
                mSelEmployee.Department = txtDepartment.Text;  
                mSelEmployee.Designation = txtDesign.Text;  
                mSelEmployee.Qualification = txtQualification.Text;                  
                trans.Commit();  
            }           
            Navigation.PopToRootAsync();  
        }  
    }  
}  
