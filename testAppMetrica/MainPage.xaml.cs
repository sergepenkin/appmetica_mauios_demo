using AppMetrica.MAUI.Core;
using AppMetrica.MAUI.iOS;

namespace testAppMetrica;

public partial class MainPage : ContentPage
{
    public MainPage()
	{
		InitializeComponent();
	}
	private void OnCounterClicked(object sender, EventArgs e)
	{
		var config = new YandexMetricaConfig("84f048fe-c7eb-4014-805d-ba5f817a81aa")
		{
			//CrashReporting = false,
			LocationTracking = false,
			LogsEnabled = true,
			DataSendingEnabled = true,
			HandleFirstActivationAsUpdate = true
		};
        YandexMetricaImplementation.Activate( config );
        YandexMetrica.Implementation.ReportEvent("TTT1");
        YandexMetrica.Implementation.ReportEvent("TTT3");
        YandexMetrica.Implementation.ReportEvent("TTT3");

        string str = string.Empty;
    }
}


