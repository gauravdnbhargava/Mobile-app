using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MySpectrum
{
    class UserData
    {
        public static List<User> Users { get; private set; }

        /// <summary>
        /// Added soem static data for initial load
        /// </summary>
        static UserData()
        {
            Users = new List<User>();

            Users.Add(new User()
            {
                Name = "Gaurav Bhargava",
                Email = "gauravdnbhargava@gmail.com"
            });

            Users.Add(new User()
            {
                Name = "John Doe",
                Email = "john.doe@gmail.com"
            });

            
        }
    }
}