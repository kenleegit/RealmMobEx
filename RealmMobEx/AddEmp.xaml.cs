using Realms;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmMobEx
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmp : ContentPage
    {
        public AddEmp()
        {
            InitializeComponent();
        }
        public void OnSaveClicked(object sender, EventArgs args)
        {
            var vRealmDb = Realm.GetInstance();
            var vEmpId = vRealmDb.All<Employee>().Count() + 1;
            var vEmployee = new Employee()
            {
                EmpId = vEmpId,
                EmpName = txtEmpName.Text,
                Department = txtDepartment.Text,
                Designation = txtDesign.Text,
                Qualification = txtQualification.Text
            };
            vRealmDb.Write(() => {
                vEmployee = vRealmDb.Add(vEmployee);
            });
            Navigation.PopAsync();
        }
    }
}