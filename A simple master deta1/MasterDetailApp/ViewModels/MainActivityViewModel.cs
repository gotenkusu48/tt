using Android.App;
using Codeplex.Reactive;
using Codeplex.Reactive.Extensions;
using MasterDetailApp.Models;
using MasterDetailApp.Views;
using System;

namespace MasterDetailApp.ViewModels
{
    public class MainActivityViewModel
    {
        public ReadOnlyReactiveCollection<PersonViewModel> People { get; private set; }

        public ReactiveCommand InsertNewCommand { get; private set; }

        public ReactiveCommand LoadCommand { get; private set; }

        public ReactiveCommand LoadMoreCommand { get; private set; }

        public ReactiveCommand<long> EditCommand { get; private set; }

        public MainActivityViewModel(Activity context, AppContext app)
        {
            this.People = app.Master.People.ToReadOnlyReactiveCollection(x => new PersonViewModel(x));

            this.InsertNewCommand = new ReactiveCommand();
            this.InsertNewCommand.Subscribe(_ => app.Master.InsertNew());

            this.LoadCommand = new ReactiveCommand();
            this.LoadCommand.Subscribe(_ => app.Master.Load());

            this.LoadMoreCommand = app.Master.ObserveProperty(x => x.CanLoadMore)
                .ToReactiveCommand();
            this.LoadMoreCommand.Subscribe(_ => app.Master.LoadMore());

            this.EditCommand = new ReactiveCommand<long>();
            this.EditCommand.Subscribe(id =>
                {
                    app.Detail.SetEditTarget(id);
                    context.StartActivity(typeof(DetailActivity));
                });
        }
    }
}