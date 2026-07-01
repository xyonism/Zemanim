using Foundation;
using UIKit;
using CoreLocation;

namespace Zemanim;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	CLLocationManager? locationManager;

	public override bool FinishedLaunching(UIApplication app, NSDictionary options)
	{
		// Request iOS location permission for geolocation to work in the WebView
		locationManager = new CLLocationManager();
		locationManager.RequestWhenInUseAuthorization();

		return base.FinishedLaunching(app, options);
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
