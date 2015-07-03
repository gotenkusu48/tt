using Codeplex.Reactive;
using Codeplex.Reactive.Extensions;
using MasterDetailApp.Models;

namespace MasterDetailApp.ViewModels
{
    public class PersonViewModel
    {
        public Person Person { get; private set; }

        public ReactiveProperty<string> Name { get; private set; }

        public ReactiveProperty<string> Age { get; private set; }

        public PersonViewModel(Person person)
        {
            this.Person = person;

            this.Name = this.Person.ToReactivePropertyAsSynchronized(x => x.Name);
            this.Age = this.Person.ToReactivePropertyAsSynchronized(x => x.Age,
                convert: x => x.ToString(),
                convertBack: x =>
                    {
                        try
                        {
                            return int.Parse(x);
                        }
                        catch
                        {
                            return 0;
                        }
                    });
        }
    }
}
