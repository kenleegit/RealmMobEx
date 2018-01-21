using Realms;

namespace RealmMobEx
{
    public class Employee : RealmObject
    {
        [PrimaryKey]
        public long EmpId
        { get; set; }
        public string EmpName
        { get; set; }
        public string Company
        { get; set; }
        public string Designation
        { get; set; }
        public string Department
        { get; set; }
        public string Qualification
        { get; set; }
    }
}