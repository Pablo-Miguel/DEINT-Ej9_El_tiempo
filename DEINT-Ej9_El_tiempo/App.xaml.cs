using DEINT_Ej9_El_tiempo.MVVM.View;

namespace DEINT_Ej9_El_tiempo;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new WeatherView();
	}
}
