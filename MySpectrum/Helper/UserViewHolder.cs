using System;
using System.Collections.Generic;
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
    class UserViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; set; }      
        public TextView Email { get; set; }

        public UserViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.name);         
            Email = itemView.FindViewById<TextView>(Resource.Id.email);
        }
    }
}