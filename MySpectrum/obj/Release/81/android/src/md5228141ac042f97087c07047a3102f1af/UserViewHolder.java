package md5228141ac042f97087c07047a3102f1af;


public class UserViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("MySpectrum.UserViewHolder, MySpectrum", UserViewHolder.class, __md_methods);
	}


	public UserViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == UserViewHolder.class)
			mono.android.TypeManager.Activate ("MySpectrum.UserViewHolder, MySpectrum", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
