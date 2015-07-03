package md58c1c13f47f8c9a3243c3cb673271bc85;


public class ObservableCollectionAdapter_1
	extends md58c1c13f47f8c9a3243c3cb673271bc85.ListAdapter_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ReactiveProperty.XamarinAndroid.ObservableCollectionAdapter`1, ReactiveProperty.XamarinAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ObservableCollectionAdapter_1.class, __md_methods);
	}


	public ObservableCollectionAdapter_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ObservableCollectionAdapter_1.class)
			mono.android.TypeManager.Activate ("ReactiveProperty.XamarinAndroid.ObservableCollectionAdapter`1, ReactiveProperty.XamarinAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
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
