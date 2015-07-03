using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;

namespace MasterDetailApp.Models
{
    public class Master : ObservableObject
    {
        private const int PageSize = 10;

        private int page;

        public int Page
        {
            get { return this.page; }
            private set { this.Set(ref this.page, value); }
        }

        private bool canLoadMore;

        public bool CanLoadMore
        {
            get { return this.canLoadMore; }
            private set { this.Set(ref this.canLoadMore, value); }
        }


        public ObservableCollection<Person> People { get; private set; }

        public Master()
        {
            this.People = new ObservableCollection<Person>();
        }

        public void Load()
        {
            this.People.Clear();
            this.Page = 0;
            this.CanLoadMore = true;
            this.LoadImpl();
        }

        public void LoadMore()
        {
            this.LoadImpl();
        }

        private void LoadImpl()
        {
            if (!this.CanLoadMore)
            {
                return;
            }

            using (var conn = ConnectionProvider.GetConnection())
            {
                var results = conn.Table<Person>()
                    .OrderBy(x => x.Id)
                    .Skip(this.Page++ * PageSize)
                    .Take(PageSize)
                    .ToArray();
                foreach (var p in results)
                {
                    this.People.Add(p);
                }
                if (!results.Any())
                {
                    this.CanLoadMore = false;
                }
            }
        }

        public void InsertNew()
        {
            using (var conn = ConnectionProvider.GetConnection())
            {
                var p = new Person { Name = "êVãK" };
                conn.Insert(p);
                this.People.Insert(0, p);
            }
        }

    }
}