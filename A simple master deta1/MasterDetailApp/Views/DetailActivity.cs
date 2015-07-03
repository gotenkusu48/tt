using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MasterDetailApp.ViewModels;
using MasterDetailApp.Models;
using Codeplex.Reactive.Extensions;
using ReactiveProperty.XamarinAndroid;
using ReactiveProperty.XamarinAndroid.Extensions;

namespace MasterDetailApp.Views
{
    [Activity(Label = "DetailActivity")]
    public class DetailActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            this.SetContentView(Resource.Layout.Detail);

            var viewModel = new DetailActivityViewModel(this, AppContext.Instance);
            this.FindViewById<EditText>(Resource.Id.EditTextName)
                .SetBinding(
                    x => x.Text,
                    viewModel.EditTarget.Value.Name,
                    x => x.TextChangedAsObservable().ToUnit());

            this.FindViewById<EditText>(Resource.Id.EditTextAge)
                .SetBinding(
                    x => x.Text,
                    viewModel.EditTarget.Value.Age,
                    x => x.TextChangedAsObservable().ToUnit());


            this.FindViewById<Button>(Resource.Id.ButtonSave)
                .ClickAsObservable()
                .SetCommand(viewModel.SaveCommand);
        }
    }
}