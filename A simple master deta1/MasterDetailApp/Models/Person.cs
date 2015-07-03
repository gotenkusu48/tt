using GalaSoft.MvvmLight;
using SQLite.Net.Attributes;

namespace MasterDetailApp.Models
{
    [Table("People")]
    public class Person : ObservableObject
    {
        private int id;

        [PrimaryKey]
        [AutoIncrement]
        [Column("_id")]
        public int Id
        {
            get { return this.id; }
            set { this.Set(ref this.id, value); }
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.Set(ref this.name, value); }
        }

        private int age;

        public int Age
        {
            get { return this.age; }
            set { this.Set(ref this.age, value); }
        }
    }
}
