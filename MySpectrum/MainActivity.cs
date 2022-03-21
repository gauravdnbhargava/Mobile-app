using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace MySpectrum
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView recyclerView;
        const int ADD_USER_REQUEST = 1; // Request code
        UserViewAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);        
            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Vertical, false));
            adapter = new UserViewAdapter(UserData.Users);
            recyclerView.SetAdapter(adapter);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        /// <summary>
        /// Call the add user activity for result
        /// </summary>
        /// <param name="item">User icon</param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_adduser)
            {
                var intent = new Intent(this, typeof(AddUserActivity));
                StartActivityForResult(intent, ADD_USER_REQUEST);
            }

            return base.OnOptionsItemSelected(item);
        }

        /// <summary>
        /// Method is called when control/user is returned from add user activity
        /// When successful data is recycler view data is updated
        /// </summary>
        /// <param name="requestCode">As passed by main activity</param>
        /// <param name="resultCode">Indicated return via save or back button</param>
        /// <param name="data">User data</param>
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {           
            if (requestCode == ADD_USER_REQUEST && resultCode == Result.Ok)
            {
                string name =  data.GetStringExtra("ItemName");
                string email = data.GetStringExtra("ItemEmail");
                UserData.Users.Add(new User()
                {
                    Name = name,
                    Email = email
                });
                adapter.NotifyDataSetChanged();
            }
        }
    }
}

