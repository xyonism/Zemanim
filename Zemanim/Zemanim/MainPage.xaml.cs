namespace Zemanim;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

#if ANDROID
		void ConfigureNative()
		{
			var native = blazorWebView.Handler?.PlatformView as Android.Webkit.WebView;
			if (native != null)
			{
				native.Settings.JavaScriptEnabled = true;
				native.Settings.SetGeolocationEnabled(true);
				native.SetWebChromeClient(new GeolocationWebChromeClient());
			}
		}

		if (blazorWebView.Handler != null)
			ConfigureNative();
		else
			blazorWebView.HandlerChanged += (s, e) => ConfigureNative();
#endif
	}
}
