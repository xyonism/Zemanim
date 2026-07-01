using Android.App;
using Android.Content.PM;
using Android.OS;
using Android;
using AndroidX.Core.App;
using AndroidX.Core.Content;

namespace Zemanim;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
	const int RequestLocationId = 1000;
	readonly string[] LocationPermissions = new[]
	{
		Manifest.Permission.AccessFineLocation,
		Manifest.Permission.AccessCoarseLocation
	};

	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);

		// Request runtime location permission (required on Android 6.0+)
		if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
		{
			if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation) != (int)Permission.Granted)
			{
				ActivityCompat.RequestPermissions(this, LocationPermissions, RequestLocationId);
			}
		}
	}

	public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
	}
}
