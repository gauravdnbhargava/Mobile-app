using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using System.Text.RegularExpressions;

namespace MySpectrum
{
    [Activity(Label = "@string/add_user")]
    public class AddUserActivity : AppCompatActivity
    {
        EditText Name;
        EditText Email;
        EditText Password;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddUser);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true); // Set the back arrow-button
            SupportActionBar.SetHomeAsUpIndicator(Resource.Mipmap.ic_arrow_back_white_48dp); // Set the icon

            Name = FindViewById<EditText>(Resource.Id.name);
            Email = FindViewById<EditText>(Resource.Id.email);
            Password = FindViewById<EditText>(Resource.Id.password);
            //Subscribe to save button click
            FindViewById<Button>(Resource.Id.saveButton).Click += OnSaveClick;
        }
        /// <summary>
        /// Responsd to menu item click
        /// </summary>
        /// <param name="item">Clicked item</param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish(); // Finish activity if home/back button is clicked
                    break;
            }
            return true;
        }

        /// <summary>
        /// Validates and save/pass the user information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnSaveClick(object sender, EventArgs e)
        {
            if (OnValidate())
            {
                var intent = new Intent();

                // Load the new data into an Intent for transport back to the Activity that started this one.
                intent.PutExtra("ItemName", Name.Text);
                intent.PutExtra("ItemEmail", Email.Text);
                
                //Inform user
                Toast.MakeText(this, "User created succesfully", ToastLength.Short).Show();

                // Send the result code and data back (this does not end the current Activity)
                SetResult(Result.Ok, intent);              

                // End the current Activity.
                Finish();
            }
        }
        /// <summary>
        /// This method validates the user input
        /// </summary>
        /// <returns>Returns true if user input is all valid, else false</returns>
        bool OnValidate()
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(Name.Text))
            {
                Name.SetError(Resources.GetString(Resource.String.required_name), null);
                return isValid = false;
            }
           
            if (String.IsNullOrEmpty(Password.Text))
            { 
                Password.SetError(Resources.GetString(Resource.String.required_password), null);
                return isValid = false;
            }

            if (String.IsNullOrEmpty(Email.Text))
            {
                Email.SetError(Resources.GetString(Resource.String.required_email), null);
                return isValid = false;
            }
           if(!IsValidEmail(Email.Text))
            {
                Toast.MakeText(this, "Email not in correct format", ToastLength.Long).Show();
                return isValid = false;
            }
            isValid = IsValidPassord(Password.Text);

            return isValid;
        }

        /// <summary>
        /// Validates the email 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();                    
        }

        /// <summary>
        /// Validates the password string
        /// </summary>
        /// <param name="password">user entered text</param>
        /// <returns>bool</returns>
        public bool IsValidPassord(string password)
        {
            bool isValid = false;
            Regex rx = new Regex(@"^(?!.*(?<g>[a-z\d]+)\k<g>.*)[a-z\d]{5,12}(?<=.*[a-z].*)(?<=.*\d.*)$", RegexOptions.Compiled );
            if (!rx.IsMatch(password))
            {

                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle(Resources.GetString(Resource.String.password_rule));
                alert.SetMessage(Resources.GetString(Resource.String.password_validation));
                alert.SetButton(Resources.GetString(Resource.String.ok), (c, ev) =>
                {
                    // Ok button click task  
                });

                alert.Show();
                isValid = false;
            }
            else
            {
               isValid = true;
            }

            return isValid;
        }
    }
}