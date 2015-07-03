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
using GalaSoft.MvvmLight;

namespace MasterDetailApp.Models
{
    public class Detail : ObservableObject
    {
        private Person editTarget;

        public Person EditTarget
        {
            get { return this.editTarget; }
            private set { this.Set(ref this.editTarget, value); }
        }

        public void SetEditTarget(long id)
        {
            using (var conn = ConnectionProvider.GetConnection())
            {
                this.EditTarget = conn.Find<Person>(id);
            }
        }

        public void Update()
        {
            using (var conn = ConnectionProvider.GetConnection())
            {
                conn.Update(this.EditTarget);
            }
        }
    }
}