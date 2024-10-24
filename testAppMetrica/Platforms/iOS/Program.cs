using ObjCRuntime;
using UIKit;

namespace testAppMetrica;

public class Program
{
	// This is the main entry point of the application.
	static void Main(string[] args)
	{
		// if you want to use a different Application Delegate class from "AppDelegate"
		// you can specify it here.

		UIApplication.Main(args, null, typeof(AppDelegate));
	}
}
/*
StackTrace	"   at AppMetrica.MAUI.iOS.AMAAppMetricaConfiguration..ctor(String apiKey) in
	/Users/mac/Desktop/PROJ2/AppMetrica.MAUI.iOS/obj/Debug/net8.0-ios/iOS/AppMetrica.MAUI.iOS/AMAAppMetricaConfiguration.g.cs:line 707\n  \
	at AppMetrica.MAUI.iOS.YandexMetricaImplementatio…"	string



	StackTrace	"   at AppMetrica.MAUI.iOS.YandexMetrica_581.ActivateWithConfiguration(AMAAppMetricaConfiguration configuration) in
/Users/mac/Desktop/PROJ2/AppMetrica.MAUI.iOS/obj/Debug/net8.0-ios/iOS/AppMetrica.MAUI.iOS/YandexMetrica_581.g.cs:line 503\n
at AppMetrica.MAUI.i…"	string
*/