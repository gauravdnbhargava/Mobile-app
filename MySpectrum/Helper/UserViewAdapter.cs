using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MySpectrum
{
    public class UserViewAdapter : RecyclerView.Adapter
    {
        List<User> users;

        public UserViewAdapter(List<User> users)
        {
            this.users = users;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var userViewAdapter = (UserViewHolder)holder;
            userViewAdapter.Name.Text = users[position].Name;        
            userViewAdapter.Email.Text = users[position].Email;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var layout = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.UsersDetail, parent, false);
            return new UserViewHolder(layout);
        }

        public override int ItemCount
        {
            get { return users.Count; }
        }
    }
}