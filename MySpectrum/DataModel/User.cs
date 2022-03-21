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

namespace MySpectrum
{
    /// <summary>
    /// Data mode for user information
    /// </summary>
   public class User
    {
        public string Name { get; set; }    
        public string Password { get; set; }
        public string Email { get; set; }

        public override string ToString() { return Name; }
    }
}