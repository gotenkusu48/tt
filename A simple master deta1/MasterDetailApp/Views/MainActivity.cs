using System;
using System.Reactive.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MasterDetailApp.ViewModels;
using MasterDetailApp.Models;
using ReactiveProperty.XamarinAndroid;
using ReactiveProperty.XamarinAndroid.Extensions;
using Android.Util;

namespace MasterDetailApp.Views
{
    [Activity(Label = "MasterDetailApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        private MainActivityViewModel viewModel;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.viewModel = new MainActivityViewModel(this, AppContext.Instance);
            var header = new Button(this)
            {
                Text = "Add"
            };
            header.ClickAsObservable().SetCommand(this.viewModel.InsertNewCommand);
            this.ListView.AddHeaderView(header);

            this.ListAdapter = this.viewModel.People.ToAdapter(
                (_, __) => LayoutInflater.FromContext(this).Inflate(Android.Resource.Layout.SimpleListItem1, null),
                (_, x, v) => v.FindViewById<TextView>(Android.Resource.Id.Text1).SetBinding(y => y.Text, x.Name),
                (_, x) => x.Person.Id);

            this.ListView.ScrollAsObservable()
                .Where(x => x.TotalItemCount == x.FirstVisibleItem + x.VisibleItemCount)
                .SetCommand(this.viewModel.LoadMoreCommand);

            this.ListView.ItemClickAsObservable()
                .Select(x => x.Id)
                .SetCommand(this.viewModel.EditCommand);
        }

        protected override void OnStart()
        {
            base.OnStart();
            this.viewModel.LoadCommand.Execute();
        }
    }
}

