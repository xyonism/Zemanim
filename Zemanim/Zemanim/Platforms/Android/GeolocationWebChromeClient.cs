using Android.Webkit;

namespace Zemanim;

public class GeolocationWebChromeClient : WebChromeClient
{
	public override void OnGeolocationPermissionsShowPrompt(string origin, GeolocationPermissions.ICallback callback)
	{
		// Automatically grant geolocation permission for the origin
		callback.Invoke(origin, true, false);
	}
}
