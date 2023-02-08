using SkiaSharp.Views.Maui.Controls.Hosting;

namespace DEINT_Ej9_El_tiempo;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseSkiaSharp()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.ConfigureEssentials(essentials => {
				essentials.UseMapServiceToken("EX5QHaREPrrp05Nq5KQP~JRvwuGE_XzxaTLkzoI-Y3A~AvpIMrmn5kMSYo8tcNiNR8sCr7DrKzknbummcI1y5wNpeS34CIS3Usyf0KRB5Zpz");
			});

		return builder.Build();
	}
}
