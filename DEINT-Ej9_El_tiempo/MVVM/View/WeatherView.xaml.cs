using DEINT_Ej9_El_tiempo.MVVM.ViewModels;

namespace DEINT_Ej9_El_tiempo.MVVM.View;

public partial class WeatherView : ContentPage
{
	public WeatherView()
	{
		InitializeComponent();
		BindingContext = new WeatherViewModel();
	}
}