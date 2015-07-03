
using GalaSoft.MvvmLight;

namespace MasterDetailApp.Models
{
    public class AppContext : ObservableObject
    {
        public static readonly AppContext Instance = new AppContext();

        private Master master;

        public Master Master
        {
            get { return this.master; }
            private set { this.Set(ref this.master, value); }
        }

        private Detail detail;

        public Detail Detail
        {
            get { return this.detail; }
            private set { this.Set(ref this.detail, value); }
        }


        public AppContext()
        {
            this.Master = new Master();
            this.Detail = new Detail();
        }

    }
}