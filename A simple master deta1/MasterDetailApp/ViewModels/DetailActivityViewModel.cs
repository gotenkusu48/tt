using Android.App;
using Codeplex.Reactive;
using Codeplex.Reactive.Extensions;
using MasterDetailApp.Models;
using System;
using System.Reactive.Linq;

namespace MasterDetailApp.ViewModels
{
    public class DetailActivityViewModel
    {
        public ReactiveProperty<PersonViewModel> EditTarget { get; private set; }

        public ReactiveCommand SaveCommand { get; private set; }

        public DetailActivityViewModel(Activity context, AppContext app)
        {
            this.EditTarget = app.Detail
                .ObserveProperty(x => x.EditTarget)
                .Select(x => new PersonViewModel(x))
                .ToReactiveProperty();

            this.SaveCommand = new ReactiveCommand();
            this.SaveCommand.Subscribe(_ =>
                {
                    app.Detail.Update();
                    context.Finish();
                });
        }
    }
}